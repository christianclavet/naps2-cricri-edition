﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAPS2.Lang.Resources;
using NAPS2.Logging;
using NAPS2.Operation;
using NAPS2.Images;
using NAPS2.Images.Storage;
using NAPS2.Images.Transforms;
using NAPS2.WinForms;

namespace NAPS2.Recovery
{
    public class RecoveryManager
    {
        private readonly IFormFactory formFactory;
        private readonly ImageRenderer imageRenderer;
        private readonly OperationProgress operationProgress;

        public RecoveryManager(IFormFactory formFactory, ImageRenderer imageRenderer, OperationProgress operationProgress)
        {
            this.formFactory = formFactory;
            this.imageRenderer = imageRenderer;
            this.operationProgress = operationProgress;
        }

        public void RecoverScannedImages(Action<ScannedImage> imageCallback)
        {
            var op = new RecoveryOperation(formFactory, imageRenderer);
            if (op.Start(imageCallback))
            {
                operationProgress.ShowProgress(op);
            }
        }

        private class RecoveryOperation : OperationBase
        {
            private readonly IFormFactory formFactory;
            private readonly ImageRenderer imageRenderer;

            private FileStream lockFile;
            private DirectoryInfo folderToRecoverFrom;
            private RecoveryIndexManager recoveryIndexManager;
            private int imageCount;
            private DateTime scannedDateTime;

            public RecoveryOperation(IFormFactory formFactory, ImageRenderer imageRenderer)
            {
                this.formFactory = formFactory;
                this.imageRenderer = imageRenderer;

                ProgressTitle = MiscResources.ImportProgress;
                AllowCancel = true;
                AllowBackground = true;
            }

            public bool Start(Action<ScannedImage> imageCallback)
            {
                Status = new OperationStatus
                {
                    StatusText = MiscResources.Recovering
                };

                folderToRecoverFrom = FindAndLockFolderToRecoverFrom();
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
                        // If there are no images, do nothing. Don't delete the folder in case the index was corrupted somehow.
                        ReleaseFolderLock();
                        return false;
                    }
                    switch (PromptToRecover())
                    {
                        case DialogResult.Yes: // Recover
                            RunAsync(async () =>
                            {
                                try
                                {
                                    if (await DoRecover(imageCallback))
                                    {
                                        ReleaseFolderLock();
                                        DeleteFolder();
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
                        case DialogResult.No: // Delete
                            ReleaseFolderLock();
                            DeleteFolder();
                            break;
                        default: // Not Now
                            ReleaseFolderLock();
                            break;
                    }
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
                        string newPath = FileStorageManager.Current.NextFilePath();
                        File.Copy(imagePath, newPath);
                        scannedImage = new ScannedImage(new PdfFileStorage(newPath));
                    }
                    else
                    {
                        using (var bitmap = StorageManager.ImageFactory.Decode(imagePath))
                        {
                            scannedImage = new ScannedImage(bitmap, indexImage.BitDepth, indexImage.HighQuality, -1);
                        }
                    }
                    foreach (var transform in indexImage.TransformList)
                    {
                        scannedImage.AddTransform(transform);
                    }
                    scannedImage.SetThumbnail(Transform.Perform(await imageRenderer.Render(scannedImage), new ThumbnailTransform()));
                    imageCallback(scannedImage);

                    Status.CurrentProgress++;
                    InvokeStatusChanged();
                }
                return true;
            }

            private DialogResult PromptToRecover()
            {
                var recoveryPromptForm = formFactory.Create<FRecover>();
                recoveryPromptForm.SetData(imageCount, scannedDateTime);
                return recoveryPromptForm.ShowDialog();
            }

            private void DeleteFolder()
            {
                try
                {
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

            private void ReleaseFolderLock()
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
                    string lockFilePath = Path.Combine(recoveryFolder.FullName, RecoveryStorageManager.LOCK_FILE_NAME);
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