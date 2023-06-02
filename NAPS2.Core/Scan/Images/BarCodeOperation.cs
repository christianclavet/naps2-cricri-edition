using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using NAPS2.Lang.Resources;
using NAPS2.Operation;
using NAPS2.Scan.Images.Transforms;
using NAPS2.Scan;
using NAPS2.Util;
using NAPS2.Recovery;

namespace NAPS2.Scan.Images
{
    public class barCodeOperation : OperationBase
    {
        private readonly ScannedImageRenderer scannedImageRenderer;

        public barCodeOperation(ScannedImageRenderer scannedImageRenderer)
        {
            this.scannedImageRenderer = scannedImageRenderer;
    
            AllowCancel = true;
            AllowBackground = true;
        }

        public bool Start(ICollection<ScannedImage> images)
        {
            ProgressTitle = MiscResources.BarcodeTitle;
            Status = new OperationStatus
            {
                StatusText = MiscResources.BarcodeProgress,
                MaxProgress = images.Count,
     
            };
            
            RunAsync(() =>
            {
                var memoryLimitingSem = new Semaphore(4, 4);
                Pipeline.For(images).StepParallel(img =>
                {
                    if (CancelToken.IsCancellationRequested)
                    {
                        return null;
                    }
                    memoryLimitingSem.WaitOne();
                    Bitmap bitmap = scannedImageRenderer.Render(img).Result;
                    try
                    {
                        if (CancelToken.IsCancellationRequested)
                        {
                            return null;
                        }
                        
                      
                        lock (img)
                        {
                            img.BarCodeData = PatchCodeDetector.DetectBarcode(bitmap);
                            if (img.BarCodeData != null) 
                            {
                                img.RecoveryIndexImage.BarCode = img.BarCodeData;
                                img.Update(img.BarCodeData);
                            }
                        }

                        // The final pipeline step is pretty fast, so updating progress here is more accurate
                        lock (this)
                        {
                            Status.CurrentProgress += 1;
                        }
                        InvokeStatusChanged();

                        return Tuple.Create(img);
                    }
                    finally
                    {
                        bitmap.Dispose();
                        memoryLimitingSem.Release();
                    }
                }).Run();
                return !CancelToken.IsCancellationRequested;
            });

            return true;
        }
    }
}
