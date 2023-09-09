using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using NAPS2.Logging;
using NAPS2.Platform;
using NAPS2.Scan.Exceptions;
using NAPS2.Scan.Images;
using NAPS2.WinForms;
using NTwain;
using NTwain.Data;
using NAPS2.Util;
using Castle.Components.DictionaryAdapter.Xml;
using CsvHelper.Configuration;
using NAPS2.ClientServer;
using System.Xml.Linq;
using PdfSharp;
using NAPS2.Config;

namespace NAPS2.Scan.Twain
{
    public class TwainWrapper
    {
        private static readonly TWIdentity TwainAppId = TWIdentity.CreateFromAssembly(DataGroups.Image | DataGroups.Control, Assembly.GetEntryAssembly());

        private readonly IFormFactory formFactory;
        private readonly IBlankDetector blankDetector;
        private readonly ScannedImageHelper scannedImageHelper;

        static TwainWrapper()
        {
            // Path to the folder containing the 64-bit twaindsm.dll relative to NAPS2.Core.dll
            const string lib64Dir = "64";
            if (Environment.Is64BitProcess && PlatformCompat.System.CanUseWin32)
            {
                var location = Assembly.GetExecutingAssembly().Location;
                var coreDllDir = System.IO.Path.GetDirectoryName(location);
                if (coreDllDir != null)
                {
                    Win32.SetDllDirectory(System.IO.Path.Combine(coreDllDir, lib64Dir));
                }
            }
#if DEBUG
            PlatformInfo.Current.Log.IsDebugEnabled = true;
#endif
        }

        public TwainWrapper(IFormFactory formFactory, IBlankDetector blankDetector, ScannedImageHelper scannedImageHelper, IProfileManager profileManager)
        {
            this.formFactory = formFactory;
            this.blankDetector = blankDetector;
            this.scannedImageHelper = scannedImageHelper;            
        }

        public List<ScanDevice> GetDeviceList(TwainImpl twainImpl)
        {
            var deviceList = InternalGetDeviceList(twainImpl);
            if (twainImpl == TwainImpl.Default && deviceList.Count == 0)
            {
                // Fall back to OldDsm in case of no devices
                // This is primarily for Citrix support, which requires using twain_32.dll for TWAIN passthrough
                deviceList = InternalGetDeviceList(TwainImpl.OldDsm);
            }
            return deviceList;
        }

        private static List<ScanDevice> InternalGetDeviceList(TwainImpl twainImpl)
        {
            PlatformInfo.Current.PreferNewDSM = twainImpl != TwainImpl.OldDsm;
            var session = new TwainSession(TwainAppId);
            session.Open();
            try
            {
                return session.GetSources().Select(ds => new ScanDevice(ds.Name, ds.Name)).ToList();
            }
            finally
            {
                try
                {
                    session.Close();
                }
                catch (Exception e)
                {
                    Log.ErrorException("Error closing TWAIN session", e);
                }
            }
        }

        // Trying to get the capabilities with a button
        public string GetCaps(TwainImpl twainImpl, ScanDevice scanDevice)
        {
            PlatformInfo.Current.PreferNewDSM = twainImpl != TwainImpl.OldDsm;
            var session = new TwainSession(TwainAppId);
            session.Open();
            
            DataSource ds = session.FirstOrDefault(x => x.Name == scanDevice.ID);
            ds.Open();
            try
            {
                string caps = null;
                IEnumerable<CapabilityId> support = ds.Capabilities.CapSupportedCaps.GetValues();
                foreach (var result2 in support)
                {
                    caps += result2.ToString() + "\n";
                }
                return caps;

            }
            finally
            {
                try
                {
                    ds.Close();
                    session.Close();
                }
                catch (Exception e)
                {
                    Log.ErrorException("Error closing TWAIN session", e);
                }
            }
            
 
        }

        public void Scan(IWin32Window dialogParent, ScanDevice scanDevice, ScanProfile scanProfile, ScanParams scanParams,
            CancellationToken cancelToken, ScannedImageSource.Concrete source, Action<ScannedImage, ScanParams, string> runBackgroundOcr)
        {
            try
            {
                InternalScan(scanProfile.TwainImpl, dialogParent, scanDevice, scanProfile, scanParams, cancelToken, source, runBackgroundOcr);
            }
            catch (DeviceNotFoundException)
            {
                if (scanProfile.TwainImpl == TwainImpl.Default)
                {
                    // Fall back to OldDsm in case of no devices
                    // This is primarily for Citrix support, which requires using twain_32.dll for TWAIN passthrough
                    InternalScan(TwainImpl.OldDsm, dialogParent, scanDevice, scanProfile, scanParams, cancelToken, source, runBackgroundOcr);
                }
                else
                {
                    throw;
                }
            }
        }

        private void InternalScan(TwainImpl twainImpl, IWin32Window dialogParent, ScanDevice scanDevice, ScanProfile scanProfile, ScanParams scanParams,
            CancellationToken cancelToken, ScannedImageSource.Concrete source, Action<ScannedImage, ScanParams, string> runBackgroundOcr)
        {
            if (dialogParent == null)
            {
                dialogParent = new BackgroundForm();
            }
            if (twainImpl == TwainImpl.Legacy)
            {
                Legacy.TwainApi.Scan(scanProfile, scanDevice, dialogParent, formFactory, source);
                return;
            }

            PlatformInfo.Current.PreferNewDSM = twainImpl != TwainImpl.OldDsm;
            var session = new TwainSession(TwainAppId);
            var twainForm = Invoker.Current.InvokeGet(() => scanParams.NoUI ? null : formFactory.Create<FTwainGui>());
            Exception error = null;
            bool cancel = false;
            DataSource ds = null;
            var waitHandle = new AutoResetEvent(false);

            int pageNumber = 0;
            int sheetSide = 0;

            session.TransferReady += (sender, eventArgs) =>
            {
                Debug.WriteLine("NAPS2.TW - TransferReady");
                if (cancel)
                {
                    eventArgs.CancelAll = true;
                }

                //Try to close the TWAIN UI when starting the scan since the input as been done. -CC
                if (!scanParams.NoUI)
                {
                    Invoker.Current.Invoke(() => twainForm.Close());
                }
            };
            session.DataTransferred += (sender, eventArgs) =>
            {
                try
                {
                    Debug.WriteLine("NAPS2.TW - DataTransferred");
                    pageNumber++; 
               
                    using (var output = twainImpl == TwainImpl.MemXfer
                                        ? GetBitmapFromMemXFer(eventArgs.MemoryData, eventArgs.ImageInfo)
                                        : Image.FromStream(eventArgs.GetNativeImageStream()))
                    {
                        using (var result = scannedImageHelper.PostProcessStep1(output, scanProfile))
                        {
                            if (blankDetector.ExcludePage(result, scanProfile))
                            {
                                return;
                            }
                           
                            /*
                            Log.Error("Cameras:" + ds.Capabilities.CapCameraSide.GetCurrent().ConvertToString());
                            Log.Error("Barcode enabled?" + ds.Capabilities.ICapBarcodeDetectionEnabled.GetCurrent().ConvertToString());

                            IEnumerable<BarcodeType> barTypes = ds.Capabilities.ICapSupportedBarcodeTypes.GetValues();
                            foreach (var result1 in barTypes)
                            {
                                Log.Error("-> " + result1.ToString() + ": ");
                            }
                            */

                            if ((sheetSide == 2 || sheetSide==0) && ds.Capabilities.CapCameraSide.GetCurrent().ConvertToString() == "Both")
                            {
                                //Log.Error("Current side of camera: Front");
                                if (pageNumber%2 != 0) sheetSide = 1;
                            }
                            else if (sheetSide == 1 && ds.Capabilities.CapCameraSide.GetCurrent().ConvertToString() == "Both")
                            {
                                //Log.Error("Current side of camera: Back");
                                if (pageNumber%2 == 0) sheetSide = 2;
                            }

                            var bitDepth = output.PixelFormat == PixelFormat.Format1bppIndexed
                                ? ScanBitDepth.BlackWhite
                                : ScanBitDepth.C24Bit;
                            var image = new ScannedImage(result, bitDepth, scanProfile.MaxQuality, scanProfile.Quality);                            
                            
                            if (scanParams.DetectPatchCodes)
                            {
                                foreach (var patchCodeInfo in eventArgs.GetExtImageInfo(ExtendedImageInfo.PatchCode))
                                {
                                    if (patchCodeInfo.ReturnCode == ReturnCode.Success)
                                    {
                                        image.PatchCode = GetPatchCode(patchCodeInfo);
                                        image.BarCodeData = GetBarCode();
                                       // Debug.WriteLine("\n\nBARCODE BARCODE BARCODE : " + image.PatchCode + "\n\n");
                                    }
                                }
                            }

                            //Barcode reading not working directly from twain. Only from the lib.
                            /*foreach (var barCodeInfo in eventArgs.GetExtImageInfo(ExtendedImageInfo.PageSide))
                            {
                                
                                if (barCodeInfo.ReturnCode == ReturnCode.Success)
                                {
                                    foreach (var result2 in barCodeInfo.ReadValues())
                                    {
                                        Log.Error("Page side info: " + result2.ToString() + ": ");
                                    }
                                    image.BarCodeData = barCodeInfo.ReadValues().FirstOrDefault().ToString();
                                    Debug.WriteLine("\n\n Page Side: "+image.BarCodeData+"\n\n");
                                }
                            }*/
                            image.RecoveryIndexImage.SheetSide = sheetSide;
                            image.SheetSide = sheetSide;

                            scannedImageHelper.PostProcessStep2(image, result, scanProfile, scanParams, pageNumber);
                            string tempPath = scannedImageHelper.SaveForBackgroundOcr(result, scanParams);
                            runBackgroundOcr(image, scanParams, tempPath);
                            source.Put(image);
                        
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("NAPS2.TW - DataTransferred - Error");
                    error = ex;
                    cancel = true;
                    StopTwain();
                }
            };
            session.TransferError += (sender, eventArgs) =>
            {
                Debug.WriteLine("NAPS2.TW - TransferError");
                if (eventArgs.Exception != null)
                {
                    error = eventArgs.Exception;
                }
                else if (eventArgs.SourceStatus != null)
                {
                    Log.Error("TWAIN Transfer Error. Return code = {0}; condition code = {1}; data = {2}.",
                        eventArgs.ReturnCode, eventArgs.SourceStatus.ConditionCode, eventArgs.SourceStatus.Data);
                }
                else
                {
                    Log.Error("TWAIN Transfer Error. Return code = {0}.", eventArgs.ReturnCode);
                }
                cancel = true;
                StopTwain();
            };
            session.SourceDisabled += (sender, eventArgs) =>
            {
                Debug.WriteLine("NAPS2.TW - SourceDisabled");
                StopTwain();
            };

            void StopTwain()
            {
                waitHandle.Set();
                if (!scanParams.NoUI)
                {
                    Invoker.Current.Invoke(() => twainForm.Close());
                }
            }

            void InitTwain()
            {
                try
                {
                    var windowHandle = (Invoker.Current as Form)?.Handle;
                    ReturnCode rc = windowHandle != null ? session.Open(new WindowsFormsMessageLoopHook(windowHandle.Value)) : session.Open();
                    if (rc != ReturnCode.Success)
                    {
                        Debug.WriteLine("NAPS2.TW - Could not open session - {0}", rc);
                        StopTwain();
                        return;
                    }
                    ds = session.FirstOrDefault(x => x.Name == scanDevice.ID);
                    if (ds == null)
                    {
                        Debug.WriteLine("NAPS2.TW - Could not find DS - DS count = {0}", session.Count());
                        throw new DeviceNotFoundException();
                    }
                    rc = ds.Open();
                    if (rc != ReturnCode.Success)
                    {
                        Debug.WriteLine("NAPS2.TW - Could not open DS - {0}", rc);
                        StopTwain();
                        return;
                    }
                    ConfigureDS(ds, scanProfile, scanParams);
                    var ui = scanProfile.UseNativeUI ? SourceEnableMode.ShowUI : SourceEnableMode.NoUI;
                    Debug.WriteLine("NAPS2.TW - Enabling DS");
                    rc = scanParams.NoUI ? ds.Enable(ui, true, windowHandle ?? IntPtr.Zero) : ds.Enable(ui, true, twainForm.Handle);
                    Debug.WriteLine("NAPS2.TW - Enable finished");
                    if (rc != ReturnCode.Success)
                    {
                        Debug.WriteLine("NAPS2.TW - Enable failed - {0}, rc");
                        StopTwain();
                    }
                    else
                    {
                        cancelToken.Register(() =>
                        {
                            Debug.WriteLine("NAPS2.TW - User Cancel");
                            cancel = true;
                            session.ForceStepDown(5);
                        });
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("NAPS2.TW - Error");
                    error = ex;
                    StopTwain();
                }
            }

            if (!scanParams.NoUI)
            {
                twainForm.Shown += (sender, eventArgs) => { InitTwain(); };
                twainForm.Closed += (sender, args) => waitHandle.Set();
            }

            if (scanParams.NoUI)
            {
                Debug.WriteLine("NAPS2.TW - Init with no form");
                Invoker.Current.Invoke(InitTwain);
            }
            else if (!scanParams.Modal)
            {
                Debug.WriteLine("NAPS2.TW - Init with non-modal form");
                Invoker.Current.Invoke(() => twainForm.Show(dialogParent));
            }
            else
            {
                Debug.WriteLine("NAPS2.TW - Init with modal form");
                Invoker.Current.Invoke(() => twainForm.ShowDialog(dialogParent));
            }
            waitHandle.WaitOne();
            Debug.WriteLine("NAPS2.TW - Operation complete");

            if (ds != null && session.IsSourceOpen)
            {
                Debug.WriteLine("NAPS2.TW - Closing DS");
                ds.Close();
            }
            if (session.IsDsmOpen)
            {
                Debug.WriteLine("NAPS2.TW - Closing session");
                session.Close();
            }

            if (error != null)
            {
                Debug.WriteLine("NAPS2.TW - Throwing error - {0}", error);
                if (error is ScanDriverException)
                {
                    throw error;
                }
                throw new ScanDriverUnknownException(error);
            }
        }

        private static Bitmap GetBitmapFromMemXFer(byte[] memoryData, TWImageInfo imageInfo)
        {
            int bytesPerPixel = memoryData.Length / (imageInfo.ImageWidth * imageInfo.ImageLength);
            PixelFormat pixelFormat = bytesPerPixel == 0 ? PixelFormat.Format1bppIndexed : PixelFormat.Format24bppRgb;
            int imageWidth = imageInfo.ImageWidth;
            int imageHeight = imageInfo.ImageLength; 
            var bitmap = new Bitmap(imageWidth, imageHeight, pixelFormat);
            var data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, bitmap.PixelFormat);
            try
            {
                byte[] source = memoryData;
                if (bytesPerPixel == 1)
                {
                    // No 8-bit greyscale format, so we have to transform into 24-bit
                    int rowWidth = data.Stride;
                    int originalRowWidth = source.Length / imageHeight;
                    byte[] source2 = new byte[rowWidth * imageHeight];
                    for (int row = 0; row < imageHeight; row++)
                    {
                        for (int col = 0; col < imageWidth; col++)
                        {
                            source2[row * rowWidth + col * 3] = source[row * originalRowWidth + col];
                            source2[row * rowWidth + col * 3 + 1] = source[row * originalRowWidth + col];
                            source2[row * rowWidth + col * 3 + 2] = source[row * originalRowWidth + col];
                        }
                    }
                    source = source2;
                }
                else if (bytesPerPixel == 3)
                {
                    // Colors are provided as BGR, they need to be swapped to RGB
                    int rowWidth = data.Stride;
                    for (int row = 0; row < imageHeight; row++)
                    {
                        for (int col = 0; col < imageWidth; col++)
                        {
                            (source[row * rowWidth + col * 3], source[row * rowWidth + col * 3 + 2]) =
                                (source[row * rowWidth + col * 3 + 2], source[row * rowWidth + col * 3]);
                        }
                    }
                }
                Marshal.Copy(source, 0, data.Scan0, source.Length);
            }
            finally
            {
                bitmap.UnlockBits(data);
            }
            return bitmap;
        }

        private static PatchCode GetPatchCode(TWInfo patchCodeInfo)
        {
            switch ((NTwain.Data.PatchCode)patchCodeInfo.Item)
            {
                case NTwain.Data.PatchCode.Patch1:
                    return PatchCode.Patch1;
                case NTwain.Data.PatchCode.Patch2:
                    return PatchCode.Patch2;
                case NTwain.Data.PatchCode.Patch3:
                    return PatchCode.Patch3;
                case NTwain.Data.PatchCode.Patch4:
                    return PatchCode.Patch4;
                case NTwain.Data.PatchCode.Patch6:
                    return PatchCode.Patch6;
                case NTwain.Data.PatchCode.PatchT:
                    return PatchCode.PatchT;
                default:
                    throw new ArgumentException();
            }
        }

        private static string GetBarCode()
        {
            return NTwain.Data.ExtendedImageInfo.BarcodeText.ToString();
        }

        private void ConfigureDS(DataSource ds, ScanProfile scanProfile, ScanParams scanParams)
        {
            /*
            var Manu = ds.Manufacturer+": "+ds.Name;
            // Test to force autosize the page scanned
            if (ds.Capabilities.ICapAutoSize.IsSupported)
                Log.Error("Capability: Device support autosize:," + Manu);
            else
                Log.Error("Capability: this device doesnt support autosize," + Manu);

            // Test to see if the scanning device can auto-rotate images
            if (ds.Capabilities.ICapAutomaticRotate.IsSupported)
                Log.Error("Capability: Device support auto-rotate," + Manu);
            else
                Log.Error("Capability: this device doesnt support auto-rotate,"+Manu);

            // Test to see if the scanning device can detect borders
            if (ds.Capabilities.ICapAutomaticBorderDetection.IsSupported)
                Log.Error("Capability: Device support border detection" + Manu);
            else
                Log.Error("Capability: this device doesnt support border dectection" + Manu);

            // Test to see if the scanning device can do deskew
            if (ds.Capabilities.ICapAutomaticDeskew.IsSupported)
                Log.Error("Capability: Device support deskew" + Manu);
            else
                Log.Error("Capability: this device doesnt support deskew" + Manu);

            // Test to see if the scanning device can support duplex scanning
            if (ds.Capabilities.CapDuplexEnabled.IsSupported)
                Log.Error("Capability: Device support duplex" + Manu);
            else
                Log.Error("Capability: this device doesnt support duplex" + Manu);

            if (ds.Capabilities.CapDoubleFeedDetection.IsSupported)
                Log.Error("Capability: This device support Double Feed detection" + Manu);
            else
                Log.Error("Capability: This device does not support Double Feed detection" + Manu);

            //Need to change this for rescan. (1-2 pages), -1 mean all the pages in the feeder.*/

            //try to enable barcode capability
            ds.Capabilities.ICapBarcodeDetectionEnabled.SetValue(BoolType.True);

            if (!scanParams.RescanMode)
                ds.Capabilities.CapXferCount.SetValue(-1);
            else
                ds.Capabilities.CapXferCount.SetValue(1);

            if (scanProfile.UseNativeUI)
            {
                return;
            }

            // Transfer Mode
            if (scanProfile.TwainImpl == TwainImpl.MemXfer)
            {
                ds.Capabilities.ICapXferMech.SetValue(XferMech.Memory);
            }

            // Hide UI for console
            if (scanParams.NoUI)
            {
                ds.Capabilities.CapIndicators.SetValue(BoolType.False);
            }
            // Double feed detection. Only set the caps if the setting are not on NONE.
            if (scanProfile.DoubleFeedType >0)
            { 
                if (scanProfile.DoubleFeedType == 2)
                    ds.Capabilities.CapDoubleFeedDetection.SetValue(DoubleFeedDetection.Ultrasonic);

                if (scanProfile.DoubleFeedType == 1)
                    ds.Capabilities.CapDoubleFeedDetection.SetValue(DoubleFeedDetection.Infrared);

                if (scanProfile.DoubleFeedAction == 0)
                    ds.Capabilities.CapDoubleFeedDetectionResponse.SetValue(DoubleFeedDetectionResponse.Stop);
                if (scanProfile.DoubleFeedAction == 1)
                    ds.Capabilities.CapDoubleFeedDetectionResponse.SetValue(DoubleFeedDetectionResponse.StopAndWait);
                if (scanProfile.DoubleFeedAction == 2)
                    ds.Capabilities.CapDoubleFeedDetectionResponse.SetValue(DoubleFeedDetectionResponse.Sound | DoubleFeedDetectionResponse.Stop);
                // Double Feed Intensity setting
                if (scanProfile.DoubleFeedSensivity == 0)
                    ds.Capabilities.CapDoubleFeedDetectionSensitivity.SetValue(DoubleFeedDetectionSensitivity.Low);
                if (scanProfile.DoubleFeedSensivity == 1)
                    ds.Capabilities.CapDoubleFeedDetectionSensitivity.SetValue(DoubleFeedDetectionSensitivity.Medium);
                if (scanProfile.DoubleFeedSensivity == 2)
                    ds.Capabilities.CapDoubleFeedDetectionSensitivity.SetValue(DoubleFeedDetectionSensitivity.High);
            }

            // Paper Source
            switch (scanProfile.PaperSource)
            {
                case ScanSource.Glass:
                    ds.Capabilities.CapFeederEnabled.SetValue(BoolType.False);
                    ds.Capabilities.CapDuplexEnabled.SetValue(BoolType.False);
                    ds.Capabilities.ICapAutomaticDeskew.SetValue(BoolType.True);
                    if (scanProfile.AutoBorderDetection)
                        ds.Capabilities.ICapAutomaticBorderDetection.SetValue(BoolType.True);
                    else
                        ds.Capabilities.ICapAutomaticBorderDetection.SetValue(BoolType.False);
                    break;

                case ScanSource.Feeder:
                    ds.Capabilities.CapFeederEnabled.SetValue(BoolType.True);
                    ds.Capabilities.CapDuplexEnabled.SetValue(BoolType.False);
                    
                    if (scanProfile.AutoBorderDetection)
                        ds.Capabilities.ICapAutomaticBorderDetection.SetValue(BoolType.True);
                    else
                        ds.Capabilities.ICapAutomaticBorderDetection.SetValue(BoolType.False);

                    if (scanProfile.AutoPageDeskew)
                        ds.Capabilities.ICapAutomaticDeskew.SetValue(BoolType.True);
                    else
                        ds.Capabilities.ICapAutomaticDeskew.SetValue(BoolType.False);

                    if (scanProfile.AutoPageRotation)
                        ds.Capabilities.ICapAutomaticRotate.SetValue(BoolType.True);
                    else
                        ds.Capabilities.ICapAutomaticRotate.SetValue(BoolType.False);
                    
                    if (scanProfile.DoubleFeedType == 0)
                        ds.Capabilities.CapDoubleFeedDetection.SetValue(DoubleFeedDetection.Ultrasonic);

                    if (scanProfile.DoubleFeedType == 2)
                        ds.Capabilities.CapDoubleFeedDetection.SetValue(DoubleFeedDetection.Infrared);
                    
                    if (scanProfile.DoubleFeedAction == 0)
                        ds.Capabilities.CapDoubleFeedDetectionResponse.SetValue(DoubleFeedDetectionResponse.Stop);
                    if (scanProfile.DoubleFeedAction == 1)
                        ds.Capabilities.CapDoubleFeedDetectionResponse.SetValue(DoubleFeedDetectionResponse.StopAndWait);
                    if (scanProfile.DoubleFeedAction == 2)
                        ds.Capabilities.CapDoubleFeedDetectionResponse.SetValue(DoubleFeedDetectionResponse.Sound | DoubleFeedDetectionResponse.Stop);
                    // Double Feed Intensity setting
                    if (scanProfile.DoubleFeedSensivity == 0)
                        ds.Capabilities.CapDoubleFeedDetectionSensitivity.SetValue(DoubleFeedDetectionSensitivity.Low);
                    if (scanProfile.DoubleFeedSensivity == 1)
                        ds.Capabilities.CapDoubleFeedDetectionSensitivity.SetValue(DoubleFeedDetectionSensitivity.Medium);
                    if (scanProfile.DoubleFeedSensivity == 2)
                        ds.Capabilities.CapDoubleFeedDetectionSensitivity.SetValue(DoubleFeedDetectionSensitivity.High);

                    if (scanProfile.PaperType == 0)
                        ds.Capabilities.CapPaperHandling.SetValue(PaperHandling.Normal);
                    if (scanProfile.PaperType == 1)
                        ds.Capabilities.CapPaperHandling.SetValue(PaperHandling.Fragile);
                    if (scanProfile.PaperType == 2)
                        ds.Capabilities.CapPaperHandling.SetValue(PaperHandling.Thick);
                    if (scanProfile.PaperType == 3)
                        ds.Capabilities.CapPaperHandling.SetValue(PaperHandling.Trifold);
                    if (scanProfile.PaperType == 4)
                        ds.Capabilities.CapPaperHandling.SetValue(PaperHandling.Photograph);

                    break;

                case ScanSource.Duplex:
                   
                    ds.Capabilities.CapFeederEnabled.SetValue(BoolType.True);
                    ds.Capabilities.CapDuplexEnabled.SetValue(BoolType.True);
                    

                    if (scanProfile.AutoBorderDetection)
                        ds.Capabilities.ICapAutomaticBorderDetection.SetValue(BoolType.True);
                    else
                        ds.Capabilities.ICapAutomaticBorderDetection.SetValue(BoolType.False);
                    
                    if (scanProfile.AutoPageDeskew)
                        ds.Capabilities.ICapAutomaticDeskew.SetValue(BoolType.True);
                    else
                        ds.Capabilities.ICapAutomaticDeskew.SetValue(BoolType.False);

                    if (scanProfile.AutoPageRotation)
                        ds.Capabilities.ICapAutomaticRotate.SetValue(BoolType.True);
                    else
                        ds.Capabilities.ICapAutomaticRotate.SetValue(BoolType.False);
                    // Double Feed Cap
                    if (scanProfile.DoubleFeedType == 0)
                        ds.Capabilities.CapDoubleFeedDetection.SetValue(DoubleFeedDetection.Ultrasonic);

                    if (scanProfile.DoubleFeedType == 2)
                        ds.Capabilities.CapDoubleFeedDetection.SetValue(DoubleFeedDetection.Infrared);

                    // Double Feed Cap
                    if (scanProfile.DoubleFeedAction == 0)
                        ds.Capabilities.CapDoubleFeedDetectionResponse.SetValue(DoubleFeedDetectionResponse.Stop);
                    if (scanProfile.DoubleFeedAction == 1)
                        ds.Capabilities.CapDoubleFeedDetectionResponse.SetValue(DoubleFeedDetectionResponse.StopAndWait);
                    if (scanProfile.DoubleFeedAction == 2)
                        ds.Capabilities.CapDoubleFeedDetectionResponse.SetValue(DoubleFeedDetectionResponse.Sound | DoubleFeedDetectionResponse.Stop);

                    // Double Feed Intensity setting
                    if (scanProfile.DoubleFeedSensivity == 0)
                        ds.Capabilities.CapDoubleFeedDetectionSensitivity.SetValue(DoubleFeedDetectionSensitivity.Low);
                    
                    if (scanProfile.DoubleFeedSensivity == 1)
                        ds.Capabilities.CapDoubleFeedDetectionSensitivity.SetValue(DoubleFeedDetectionSensitivity.Medium);

                    if (scanProfile.DoubleFeedSensivity == 2)
                        ds.Capabilities.CapDoubleFeedDetectionSensitivity.SetValue(DoubleFeedDetectionSensitivity.High);

                    if (scanProfile.PaperType == 0)
                        ds.Capabilities.CapPaperHandling.SetValue(PaperHandling.Normal);
                    if (scanProfile.PaperType == 1)
                        ds.Capabilities.CapPaperHandling.SetValue(PaperHandling.Fragile);
                    if (scanProfile.PaperType == 2)
                        ds.Capabilities.CapPaperHandling.SetValue(PaperHandling.Thick);
                    if (scanProfile.PaperType == 3)
                        ds.Capabilities.CapPaperHandling.SetValue(PaperHandling.Trifold);
                    if (scanProfile.PaperType == 4)
                        ds.Capabilities.CapPaperHandling.SetValue(PaperHandling.Photograph);


                    break;
            }

            // Bit Depth
            switch (scanProfile.BitDepth)
            {
                case ScanBitDepth.C24Bit:
                    ds.Capabilities.ICapPixelType.SetValue(PixelType.RGB);
                    break;
                case ScanBitDepth.Grayscale:
                    ds.Capabilities.ICapPixelType.SetValue(PixelType.Gray);
                    break;
                case ScanBitDepth.BlackWhite:
                    ds.Capabilities.ICapPixelType.SetValue(PixelType.BlackWhite);
                    break;
            }

            // Page Size, Horizontal Align
            PageDimensions pageDimensions = scanProfile.PageSize.PageDimensions() ?? scanProfile.CustomPageSize;
            if (pageDimensions == null)
            {
                throw new InvalidOperationException("No page size specified");
            }
            float pageWidth = pageDimensions.WidthInThousandthsOfAnInch() / 1000.0f;
            float pageHeight = pageDimensions.HeightInThousandthsOfAnInch() / 1000.0f;
            var pageMaxWidthFixed = ds.Capabilities.ICapPhysicalWidth.GetCurrent();
            float pageMaxWidth = pageMaxWidthFixed.Whole + (pageMaxWidthFixed.Fraction / (float)UInt16.MaxValue);

            float horizontalOffset = 0.0f;
            if (scanProfile.PageAlign == ScanHorizontalAlign.Center)
                horizontalOffset = (pageMaxWidth - pageWidth) / 2;
            else if (scanProfile.PageAlign == ScanHorizontalAlign.Left)
                horizontalOffset = (pageMaxWidth - pageWidth);

            ds.Capabilities.ICapUnits.SetValue(Unit.Inches);
            ds.DGImage.ImageLayout.Get(out TWImageLayout imageLayout);
            imageLayout.Frame = new TWFrame
            {
                Left = horizontalOffset,
                Right = horizontalOffset + pageWidth,
                Top = 0,
                Bottom = pageHeight
            };
            ds.DGImage.ImageLayout.Set(imageLayout);

            // Brightness, Contrast
            // Conveniently, the range of values used in settings (-1000 to +1000) is the same range TWAIN supports
            if (!scanProfile.BrightnessContrastAfterScan)
            {
                ds.Capabilities.ICapBrightness.SetValue(scanProfile.Brightness);
                ds.Capabilities.ICapContrast.SetValue(scanProfile.Contrast);
            }

            // Resolution
            int dpi = scanProfile.Resolution.ToIntDpi();
            ds.Capabilities.ICapXResolution.SetValue(dpi);
            ds.Capabilities.ICapYResolution.SetValue(dpi);

            // Patch codes
            if (scanParams.DetectPatchCodes)
            {
                ds.Capabilities.ICapPatchCodeDetectionEnabled.SetValue(BoolType.True);
            }

        }
    }
}
