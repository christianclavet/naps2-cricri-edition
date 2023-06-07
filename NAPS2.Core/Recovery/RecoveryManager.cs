using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAPS2.Lang.Resources;
using NAPS2.Logging;
using NAPS2.Operation;
using NAPS2.Scan.Images;
using NAPS2.Util;
using NAPS2.WinForms;

namespace NAPS2.Recovery
{
    public class RecoveryManager
    {
        public static DirectoryInfo folderToRecoverFrom;
        private readonly IFormFactory formFactory;
        private readonly ThumbnailRenderer thumbnailRenderer;
        private readonly IOperationProgress operationProgress;
       
        public RecoveryManager(IFormFactory formFactory, ThumbnailRenderer thumbnailRenderer, IOperationProgress operationProgress)
        {
            
            this.formFactory = formFactory;
            this.thumbnailRenderer = thumbnailRenderer;
            this.operationProgress = operationProgress;
        }
        public void setFolder(DirectoryInfo info)
        {
            folderToRecoverFrom = info;
        }

        public void RecoverScannedImages(Action<ScannedImage> imageCallback)
        {

            var op = new RecoveryOperation(formFactory, thumbnailRenderer);
            op.setFolder(folderToRecoverFrom);

            if (op.Start(imageCallback))
            {
                operationProgress.ShowProgress(op);
                                  
            }
        }

        public class RecoveryOperation : OperationBase
        {
            private readonly IFormFactory formFactory;
            private readonly ThumbnailRenderer thumbnailRenderer;

            private FileStream lockFile;
            public static DirectoryInfo folderToRecoverFrom;
            private RecoveryIndexManager recoveryIndexManager;
            public int imageCount;
            private DateTime scannedDateTime;
            private bool cleanup;

            public void setFolder(DirectoryInfo info)
            { 
                folderToRecoverFrom = info;
            }

            public RecoveryOperation(IFormFactory formFactory, ThumbnailRenderer thumbnailRenderer)
            {
                this.formFactory = formFactory;
                this.thumbnailRenderer = thumbnailRenderer;

                ProgressTitle = MiscResources.ImportProgress;
                
                AllowCancel = true;
                AllowBackground = false;
                cleanup = false;
                folderToRecoverFrom = null;
            }

            public bool Start(Action<ScannedImage> imageCallback)
            {
                Status = new OperationStatus();
                if (Status != null)
                {
                    Status.StatusText = MiscResources.Recovering;
                }
                
                try
                {
                    if (folderToRecoverFrom == null)
                    {
                        folderToRecoverFrom = FindAndLockFolderToRecoverFrom();
                        cleanup = true;
                    }
                    recoveryIndexManager = new RecoveryIndexManager(folderToRecoverFrom);
                    imageCount = recoveryIndexManager.Index.Images.Count;
                    scannedDateTime = folderToRecoverFrom.LastWriteTime;
                    if (cleanup)
                    {
                        if (imageCount == 0)
                        {
                            // If there are no images, do nothing and remove the folder for cleanup
                            ReleaseFolderLock();
                            DeleteFolder();
                            return false;
                        }
                        return false;
                    }
                    RunAsync(async () =>
                    {
                        try
                        {

                            if (await DoRecover(imageCallback))
                            {
                                // Theses are not recovered but used as loading a previous projet, so no delete
                                ReleaseFolderLock();
                                GC.Collect();
                                //DeleteFolder();
                                return true;
                            }
                            return false;
                        }
                        finally
                        {
                            ReleaseFolderLock();
                            GC.Collect();
                        }
                    });
                    return true;
                }
                catch (Exception)
                {
                    ReleaseFolderLock();
                    throw;
                }
               
            }

            private async Task<bool> DoRecover(Action<ScannedImage> imageCallback)
            {
                Status.MaxProgress = recoveryIndexManager.Index.Images.Count;
                InvokeStatusChanged();

                foreach (RecoveryIndexImage indexImage in recoveryIndexManager.Index.Images)
                {
                    if (CancelToken.IsCancellationRequested)
                    {
                        return false;
                    }

                    string imagePath = Path.Combine(folderToRecoverFrom.FullName, indexImage.FileName);
                    ScannedImage scannedImage;
                    if (".pdf".Equals(Path.GetExtension(imagePath), StringComparison.InvariantCultureIgnoreCase))
                    {
                        scannedImage = ScannedImage.FromSinglePagePdf(imagePath, true);
                    }
                    else
                    {
                        using (var bitmap = new Bitmap(imagePath))
                        {
                            scannedImage = new ScannedImage(bitmap, indexImage.BitDepth, indexImage.HighQuality, -1);
                            scannedImage.BarCodeData = indexImage.BarCode;
                            scannedImage.SheetSide = indexImage.SheetSide;
                        }
                    }
                    foreach (var transform in indexImage.TransformList)
                    {
                        scannedImage.AddTransform(transform);
                    }
                    scannedImage.SetThumbnail(await thumbnailRenderer.RenderThumbnail(scannedImage));
                    imageCallback(scannedImage);
                    Status.StatusText = string.Format(MiscResources.ActiveOperations, Path.GetFileName(indexImage.FileName));
                    Status.CurrentProgress++;
                    this.OnProgress(Status.CurrentProgress, Status.MaxProgress);
                    InvokeStatusChanged();
                }
                return true;
            }

            public void DeleteFolder()
            {
                try
                {
                    ReleaseFolderLock();
                    //Only delete the folder if the temporary .lock file is present. Don't delete any other folder.
                    if (File.Exists(Path.Combine(folderToRecoverFrom.FullName, ".lock")))
                        folderToRecoverFrom.Delete(true);
                }
                catch (Exception ex)
                {
                    Log.ErrorException("Error deleting recovery folder.", ex);
                }
            }

            private DirectoryInfo FindAndLockFolderToRecoverFrom()
            {
                // Find the most recent recovery folder that can be locked (i.e. isn't in use already)
                return new DirectoryInfo(Paths.Recovery)
                    .EnumerateDirectories()
                    .OrderByDescending(x => x.LastWriteTime)
                    .FirstOrDefault(TryLockRecoveryFolder);
            }

            public void ReleaseFolderLock()
            {
                // Unlock the recover folder
                if (lockFile != null)
                {
                    lockFile.Dispose();
                    lockFile = null;
                }
            }

            private bool TryLockRecoveryFolder(DirectoryInfo recoveryFolder)
            {
                try
                {
                    string lockFilePath = Path.Combine(recoveryFolder.FullName, RecoveryImage.LOCK_FILE_NAME);
                    lockFile = new FileStream(lockFilePath, FileMode.Open);
                    return true;
                }
                catch (Exception)
                {
                    // Some problem, e.g. the folder is already locked
                    return false;
                }
            }
        }
    }
}
