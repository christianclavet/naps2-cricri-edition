using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NAPS2.Config;
using NAPS2.Ocr;
using NAPS2.Operation;
using NAPS2.Scan.Images.Transforms;
using NAPS2.Util;
using ImageMagick;
using System.Windows.Forms;
using ImageMagick.Formats;
using NAPS2.ImportExport.Images;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using NAPS2.WinForms;

namespace NAPS2.Scan.Images
{
    public class ScannedImageHelper
    {
    
        public static string SaveSmallestBitmap(Bitmap sourceImage, ScanBitDepth bitDepth, bool highQuality, int quality, out ImageFormat imageFormat)
        {
            // Store the image in as little space as possible
            if (sourceImage.PixelFormat == PixelFormat.Format1bppIndexed)
            {
                // Already encoded as 1-bit
                imageFormat = ImageFormat.Png;
                return EncodePng(sourceImage);
            }
            else if (bitDepth == ScanBitDepth.BlackWhite)
            {
                // Convert to a 1-bit bitmap before saving to help compression
                // This is lossless and takes up minimal storage (best of both worlds), so highQuality is irrelevant
                using (var bitmap = BitmapHelper.CopyToBpp(sourceImage, 1))
                {
                    imageFormat = ImageFormat.Png;
                    return EncodePng(bitmap);
                }
                // Note that if a black and white image comes from native WIA, bitDepth is unknown,
                // so the image will be png-encoded below instead of using a 1-bit bitmap
            }
            else if (highQuality)
            {
                // Store as PNG
                // Lossless, but some images (color/grayscale) take up lots of storage
                imageFormat = ImageFormat.Png;
                return EncodePng(sourceImage);
            }
            else if (Equals(sourceImage.RawFormat, ImageFormat.Jpeg))
            {
                // Store as JPEG
                // Since the image was originally in JPEG format, PNG is unlikely to have size benefits
                imageFormat = ImageFormat.Jpeg;
                return EncodeJpeg(sourceImage, quality);
            }
            else
            {
                // Store as PNG/JPEG depending on which is smaller
                var pngEncoded = EncodePng(sourceImage);
                var jpegEncoded = EncodeJpeg(sourceImage, quality);
                if (new FileInfo(pngEncoded).Length <= new FileInfo(jpegEncoded).Length)
                {
                    // Probably a black and white image (from native WIA, so bitDepth is unknown), which PNG compresses well vs. JPEG
                    File.Delete(jpegEncoded);
                    imageFormat = ImageFormat.Png;
                    return pngEncoded;
                }
                else
                {
                    // Probably a color or grayscale image, which JPEG compresses well vs. PNG
                    File.Delete(pngEncoded);
                    imageFormat = ImageFormat.Jpeg;
                    return jpegEncoded;
                }
            }
        }

        private static string GetTempFilePath()
        {
            return Path.Combine(Paths.Temp, Path.GetRandomFileName());
        }

        private static string EncodePng(Bitmap bitmap)
        {
            var tempFilePath = GetTempFilePath();
            bitmap.Save(tempFilePath, ImageFormat.Png);
            return tempFilePath;
        }

        private static string EncodeJpeg(Bitmap bitmap, int quality)
        {
            var tempFilePath = GetTempFilePath();
            if (quality == -1)
            {
                bitmap.Save(tempFilePath, ImageFormat.Jpeg);
            }
            else
            {
                quality = Math.Max(Math.Min(quality, 100), 0);
                var encoder = ImageCodecInfo.GetImageEncoders().First(x => x.FormatID == ImageFormat.Jpeg.Guid);
                var encoderParams = new EncoderParameters(1);
                encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, quality);
                bitmap.Save(tempFilePath, encoder, encoderParams);
            }
            return tempFilePath;
        }

        public static ScannedImageHelper getInstance()
        {
            return instance;
        }

        private static ScannedImageHelper instance;
        private readonly ThumbnailRenderer thumbnailRenderer;
        private readonly ScannedImageRenderer scannedImageRenderer;
        private readonly IOperationFactory operationFactory;
        private readonly IOperationProgress operationProgress;
        private readonly AppConfigManager appConfigManager;
        private readonly IUserConfigManager userConfigManager;
        private readonly OcrRequestQueue ocrRequestQueue;
        private readonly OcrManager ocrManager;

        public ScannedImageHelper(ThumbnailRenderer thumbnailRenderer, ScannedImageRenderer scannedImageRenderer, IOperationFactory operationFactory, IOperationProgress operationProgress, AppConfigManager appConfigManager, IUserConfigManager userConfigManager, OcrRequestQueue ocrRequestQueue, OcrManager ocrManager)
        {
            this.thumbnailRenderer = thumbnailRenderer;
            this.scannedImageRenderer = scannedImageRenderer;
            this.operationFactory = operationFactory;
            this.operationProgress = operationProgress;
            this.appConfigManager = appConfigManager;
            this.userConfigManager = userConfigManager;
            this.ocrRequestQueue = ocrRequestQueue;
            this.ocrManager = ocrManager;
            
            instance = this;
        }

        public Bitmap PostProcessStep1(Image output, ScanProfile profile, bool supportsNativeUI = true)
        {
            double scaleFactor = 1;
            if (!profile.UseNativeUI || !supportsNativeUI)
            {
                scaleFactor = profile.AfterScanScale.ToIntScaleFactor();
            }
            var result = ImageScaleHelper.ScaleImage(output, scaleFactor);

            if ((!profile.UseNativeUI || !supportsNativeUI) && (profile.ForcePageSize || profile.ForcePageSizeCrop))
            {
                float width = output.Width / output.HorizontalResolution;
                float height = output.Height / output.VerticalResolution;
                if (float.IsNaN(width) || float.IsNaN(height))
                {
                    width = output.Width;
                    height = output.Height;
                }
                PageDimensions pageDimensions = profile.PageSize.PageDimensions() ?? profile.CustomPageSize;
                if (pageDimensions.Width > pageDimensions.Height && width < height)
                {
                    if (profile.ForcePageSizeCrop)
                    {
                        result = new CropTransform
                        {
                            Right = (int) ((width - (float) pageDimensions.HeightInInches()) * output.HorizontalResolution),
                            Bottom = (int) ((height - (float) pageDimensions.WidthInInches()) * output.VerticalResolution)
                        }.Perform(result);
                    }
                    else
                    {
                        result.SafeSetResolution((float) (output.Width / pageDimensions.HeightInInches()),
                            (float) (output.Height / pageDimensions.WidthInInches()));
                    }
                }
                else
                {
                    if (profile.ForcePageSizeCrop)
                    {
                        result = new CropTransform
                        {
                            Right = (int) ((width - (float) pageDimensions.WidthInInches()) * output.HorizontalResolution),
                            Bottom = (int) ((height - (float) pageDimensions.HeightInInches()) * output.VerticalResolution)
                        }.Perform(result);
                    }
                    else
                    {
                        result.SafeSetResolution((float)(output.Width / pageDimensions.WidthInInches()), (float)(output.Height / pageDimensions.HeightInInches()));
                    }
                }
            }

            return result;
        }

        public void PostProcessStep2(ScannedImage image, Bitmap bitmap, ScanProfile profile, ScanParams scanParams, int pageNumber, bool supportsNativeUI = true)
        {
            if (!scanParams.NoThumbnails)
            {
                image.SetThumbnail(thumbnailRenderer.RenderThumbnail(bitmap));
            }
            if (scanParams.SkipPostProcessing)
            {
                return;
            }
            if ((!profile.UseNativeUI || !supportsNativeUI) && profile.BrightnessContrastAfterScan)
            {
                if (profile.Brightness != 0)
                {
                    AddTransformAndUpdateThumbnail(image, ref bitmap, new BrightnessTransform { Brightness = profile.Brightness });
                }
                if (profile.Contrast != 0)
                {
                    AddTransformAndUpdateThumbnail(image, ref bitmap, new TrueContrastTransform { Contrast = profile.Contrast });
                }
            }
            if (profile.FlipDuplexedPages && pageNumber % 2 == 0)
            {
                AddTransformAndUpdateThumbnail(image, ref bitmap, new RotationTransform(RotateFlipType.Rotate180FlipNone));
            }
            if (profile.AutoDeskew)
            {
                var op = operationFactory.Create<DeskewOperation>();
                if (op.Start(new[] { image }))
                {
                    operationProgress.ShowProgress(op);
                    op.Wait();
                }
            }
            if (scanParams.DetectPatchCodes && image.PatchCode == PatchCode.None)
            {
                image.PatchCode = PatchCodeDetector.Detect(bitmap);
            }
        }

        public bool ShouldDoBackgroundOcr(ScanParams scanParams)
        {
            bool ocrEnabled = ocrManager.DefaultParams != null;
            bool afterScanning = appConfigManager.Config.OcrState == OcrState.Enabled && appConfigManager.Config.OcrDefaultAfterScanning
                                 || appConfigManager.Config.OcrState == OcrState.UserConfig &&
                                 (userConfigManager.Config.OcrAfterScanning ?? appConfigManager.Config.OcrDefaultAfterScanning);
            return scanParams.DoOcr ?? (ocrEnabled && afterScanning);
        }

        public string SaveForBackgroundOcr(Bitmap bitmap, ScanParams scanParams)
        {
            if (ShouldDoBackgroundOcr(scanParams))
            {
                string tempPath = Path.Combine(Paths.Temp, Path.GetRandomFileName());
                bitmap.Save(tempPath);
                return tempPath;
            }
            return null;
        }

        public void RunBackgroundOcr(ScannedImage image, ScanParams scanParams, string tempPath)
        {
            if (ShouldDoBackgroundOcr(scanParams))
            {
                using (var snapshot = image.Preserve())
                {
                    if (scanParams.DoOcr == true)
                    {
                        ocrRequestQueue.QueueForeground(null, snapshot, tempPath, scanParams.OcrParams, scanParams.OcrCancelToken).AssertNoAwait();
                    }
                    else
                    {
                        ocrRequestQueue.QueueBackground(snapshot, tempPath, scanParams.OcrParams);
                    }
                }
            }
        }

        private void AddTransformAndUpdateThumbnail(ScannedImage image, ref Bitmap bitmap, Transform transform)
        {
            image.AddTransform(transform);
            var thumbnail = image.GetThumbnail();
            if (thumbnail != null)
            {
                bitmap = transform.Perform(bitmap);
                image.SetThumbnail(thumbnailRenderer.RenderThumbnail(bitmap));
            }
        }

        public static async void TestImageMagick(ScannedImage source)
        {
            //Bitmap bitmap = scanImageRender.Render(source).Result;
            var m = new MagickFactory();
            //Getting the scannedImageRenderer will apply all the transforms on the picture.
            Bitmap bit = await instance.scannedImageRenderer.Render(source);

            using (MagickImage image = new MagickImage(m.Image.Create(bit)))
            {
                image.Settings.Compression = CompressionMethod.JPEG;
                //image.Settings.Depth = 24;
                image.Quality = 76;

                //image.Density = new Density(300, 300);
                image.Format = MagickFormat.Tiff;
                // Save frame as tiff with JPG compression method.
               
                image.Write("TIFF_SINGLE.tiff");
                image.Write("TIFF_SINGLE.jpg");

                //Try to create a 2 pages tiff
                using (var album = new MagickImageCollection())
                {

                    album.Add(image);
                    using (var image2 = image.Clone())
                    {
                        image2.AutoLevel();
                        image2.AutoOrient();
                        image2.AutoGamma();
                        album.Add(image2);
                        album.Write("TIFF_MULTI.TIF");
                    }
                }
            }
            MessageBox.Show("TEST COMPLETED");
        }
    }
}
