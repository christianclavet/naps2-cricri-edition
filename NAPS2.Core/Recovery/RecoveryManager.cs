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
using ZXing;

namespace NAPS2.Recovery
{
    public class RecoveryManager
    {
        private readonly IFormFactory formFactory;
        private readonly ThumbnailRenderer thumbnailRenderer;
        private readonly IOperationProgress operationProgress;
       
        public RecoveryManager(IFormFactory formFactory, ThumbnailRenderer thumbnailRenderer, IOperationProgress operationProgress)
        {
            this.formFactory = formFactory;
            this.thumbnailRenderer = thumbnailRenderer;
            this.operationProgress = operationProgress;
        }

        public void RecoverScannedImages(Action<ScannedImage> imageCallback, DirectoryInfo dir)
        {
            var recovery = new RecoveryOperation(formFactory, thumbnailRenderer);
            
            if (recovery.Start(imageCallback, dir))
            {                
                operationProgress.ShowProgress(recovery);
            }
        }

        public class RecoveryOperation : OperationBase
        {
            private readonly IFormFactory formFactory;
            private readonly ThumbnailRenderer thumbnailRenderer;

            private FileStream lockFile;
            private DirectoryInfo folderToRecoverFrom;
            private RecoveryIndexManager recoveryIndexManager;
            public int imageCount;
            private DateTime scannedDateTime;

            public RecoveryOperation(IFormFactory formFactory, ThumbnailRenderer thumbnailRenderer)
            {
                this.formFactory = formFactory;
                this.thumbnailRenderer = thumbnailRenderer;

                ProgressTitle = MiscResources.ImportProgress;
                AllowCancel = true;
                AllowBackground = false;
            }

            public bool Start(Action<ScannedImage> imageCallback, DirectoryInfo dir)
            {
                Status = new OperationStatus
                {
                    StatusText = MiscResources.Recovering
                };

                folderToRecoverFrom = dir;
                if (folderToRecoverFrom == null)
                {
                    return false;
                }
                try
                {
                    recoveryIndexManager = new RecoveryIndexManager(folderToRecoverFrom);
                    imageCount = recoveryIndexManager.Index.Images.Count;
                    scannedDateTime = folderToRecoverFrom.LastWriteTime;
                    if (imageCount == 0)
                    {
                        // If there are no images, do nothing and remove the folder for cleanup
                        ReleaseFolderLock();
                        DeleteFolder();
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
                }
                catch (Exception)
                {
                    ReleaseFolderLock();
                    throw;
                }
                return false;
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
