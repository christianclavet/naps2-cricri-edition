using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAPS2.Config;
using NAPS2.ImportExport;
using NAPS2.ImportExport.Email;
using NAPS2.ImportExport.Images;
using NAPS2.ImportExport.Pdf;
using NAPS2.Lang.Resources;
using NAPS2.Ocr;
using NAPS2.Operation;
using NAPS2.Scan.Images;
using NAPS2.Util;

namespace NAPS2.WinForms
{
    public class WinFormsExportHelper(PdfSettingsContainer pdfSettingsContainer, ImageSettingsContainer imageSettingsContainer, EmailSettingsContainer emailSettingsContainer, DialogHelper dialogHelper, FileNamePlaceholders fileNamePlaceholders, ChangeTracker changeTracker, IOperationFactory operationFactory, IFormFactory formFactory, OcrManager ocrManager, IEmailProviderFactory emailProviderFactory, IOperationProgress operationProgress, IUserConfigManager userConfigManager)
    {
        private readonly PdfSettingsContainer pdfSettingsContainer = pdfSettingsContainer;
        private readonly ImageSettingsContainer imageSettingsContainer = imageSettingsContainer;
        private readonly EmailSettingsContainer emailSettingsContainer = emailSettingsContainer;
        private readonly DialogHelper dialogHelper = dialogHelper;
        private readonly FileNamePlaceholders fileNamePlaceholders = fileNamePlaceholders;
        private readonly ChangeTracker changeTracker = changeTracker;
        private readonly IOperationFactory operationFactory = operationFactory;
        private readonly IFormFactory formFactory = formFactory;
        private readonly OcrManager ocrManager = ocrManager;
        private readonly IEmailProviderFactory emailProviderFactory = emailProviderFactory;
        private readonly IOperationProgress operationProgress = operationProgress;
        private readonly IUserConfigManager userConfigManager = userConfigManager;

        public async Task<bool> SavePDF(List<ScannedImage> images, ISaveNotify notify, int doc = 0)
        {
            if (images.Any())
            {
                userConfigManager.Load();
                var lastPath = (userConfigManager.Config.LastPath);
                // In case there is nothing yet in the last path, use the C:\drive
                if (lastPath == null)
                    lastPath = "C:\\";

                string savePath = Path.Combine(lastPath, FDesktop.projectName);

                if (doc == 0)
                {
                    //if (pdfSettings.SkipSavePrompt && Path.IsPathRooted(pdfSettings.DefaultFileName))
                    //pdfSettings.DefaultFileName
                    
                    string input = savePath;
                        
                   if (!dialogHelper.PromptToSavePdf(input, out savePath))
                   {
                       return false;
                   }
                   else
                   {
                       userConfigManager.Config.LastPath = Path.GetDirectoryName(savePath);
                       userConfigManager.Save();
                   }
                    
                }

                //append the document number to the file since they are the following documents...
                if (doc > 0)
                    savePath = savePath + "_" + ((doc+1).ToString("d4")) + ".pdf";


                var changeToken = changeTracker.State;
                string firstFileSaved = await ExportPDF(savePath, images, false, null);
                if (firstFileSaved != null)
                {
                    //Don't change the tracker since the project is not saved (backed up)
                    //changeTracker.Saved(changeToken);
                    notify?.PdfSaved(firstFileSaved);
                    return true;
                }
            }
            return false;
        }

        public async Task<string> ExportPDF(string filename, List<ScannedImage> images, bool email, EmailMessage emailMessage)
        {
            var op = operationFactory.Create<SavePdfOperation>();

            var pdfSettings = pdfSettingsContainer.PdfSettings;
            pdfSettings.Metadata.Creator = MiscResources.NAPS2;
            if (op.Start(filename, DateTime.Now, images, pdfSettings, ocrManager.DefaultParams, email, emailMessage))
            {
                operationProgress.ShowProgress(op);
            }
            return await op.Success ? op.FirstFileSaved : null;
        }

        public async Task<bool> SaveImages(List<ScannedImage> images, ISaveNotify notify, bool bypassprompt = false)
        {
            if (images.Any())
            {
                //string savePath;

                userConfigManager.Load();
                string savePath = Path.Combine(userConfigManager.Config.LastPath, FDesktop.projectName);

                var imageSettings = imageSettingsContainer.ImageSettings;
                if (imageSettings.SkipSavePrompt && Path.IsPathRooted(imageSettings.DefaultFileName))
                {
                    if (!(imageSettings.DefaultFileName == ""))
                        savePath = imageSettings.DefaultFileName;
                    else
                        savePath = FDesktop.projectName;
                }
                else if (!dialogHelper.PromptToSaveImage(savePath, out savePath))
                {
                   return false;
                }
              
                var op = operationFactory.Create<SaveImagesOperation>();
                var changeToken = changeTracker.State;
                
                if (op.Start(savePath, DateTime.Now, images))
                {
                    operationProgress.ShowProgress(op);
                }
                if (await op.Success)
                {
                    //Don't change the tracker since the project is not saved (backed up)
                    //changeTracker.Saved(changeToken);
                    notify?.ImagesSaved(images.Count, op.FirstFileSaved);
                    return true;
                }
            }
            return false;
        }
        public async Task<bool> SaveProjectImages(List<ScannedImage> images, ISaveNotify notify, bool bypassprompt = false)
        {
            if (images.Any())
            {
                //string savePath;

                userConfigManager.Load();
                string savePath = Path.Combine(userConfigManager.Config.LastPath, FDesktop.projectName);

                var imageSettings = imageSettingsContainer.ImageSettings;
                //ImageSettingsContainer.ProjectSettings.UseCSVExport == false
                if (Path.IsPathRooted(ImageSettingsContainer.ProjectSettings.DefaultFileName))
                {
                     savePath = ImageSettingsContainer.ProjectSettings.DefaultFileName;
                }
                else if (!dialogHelper.PromptToSaveImage(ImageSettingsContainer.ProjectSettings.DefaultFileName, out savePath))
                {
                    return false;
                }
                
                var op = operationFactory.Create<SaveImagesOperationProject>();
                var changeToken = changeTracker.State;
                op.imageSettings = imageSettings;
                if (op.Start(savePath, DateTime.Now, images))
                {
                    operationProgress.ShowProgress(op);
                }
                if (await op.Success)
                {
                    //Don't change the tracker since the project is not saved (backed up)
                    //changeTracker.Saved(changeToken);
                    notify?.ImagesSaved(images.Count, op.FirstFileSaved);
                    return true;
                }
            }
            return false;
        }
        public async Task<bool> EmailPDF(List<ScannedImage> images)
        {
            if (!images.Any())
            {
                return false;
            }

            if (userConfigManager.Config.EmailSetup == null)
            {
                // First run; prompt for a 
                var form = formFactory.Create<FEmailProvider>();
                if (form.ShowDialog() != DialogResult.OK)
                {
                    return false;
                }
            }

            var emailSettings = emailSettingsContainer.EmailSettings;
            var invalidChars = new HashSet<char>(Path.GetInvalidFileNameChars());
            var attachmentName = new string(emailSettings.AttachmentName.Where(x => !invalidChars.Contains(x)).ToArray());
            if (string.IsNullOrEmpty(attachmentName))
            {
                attachmentName = "Scan.pdf";
            }
            if (!attachmentName.EndsWith(".pdf", StringComparison.InvariantCultureIgnoreCase))
            {
                attachmentName += ".pdf";
            }
            attachmentName = fileNamePlaceholders.SubstitutePlaceholders(attachmentName, DateTime.Now, false);

            var tempFolder = new DirectoryInfo(Path.Combine(Paths.Temp, Path.GetRandomFileName()));
            tempFolder.Create();
            try
            {
                string targetPath = Path.Combine(tempFolder.FullName, attachmentName);
                var changeToken = changeTracker.State;

                var message = new EmailMessage();
                if (await ExportPDF(targetPath, images, true, message) != null)
                {
                    //Don't change the tracker since the project is not saved (backed up)
                    //changeTracker.Saved(changeToken);
                    return true;
                }
            }
            finally
            {
                tempFolder.Delete(true);
            }
            return false;
        }

    }
}
