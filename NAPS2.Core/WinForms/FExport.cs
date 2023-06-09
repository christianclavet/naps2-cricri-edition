using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAPS2.Config;
using NAPS2.ImportExport;
using NAPS2.Operation;
using NAPS2.Recovery;
using NAPS2.Scan.Images;
using NAPS2.WinForms;
using NAPS2;
using CsvHelper;
using NAPS2.Util;
using NAPS2.ImportExport.Images;
using System.IO;

namespace NAPS2.WinForms
{
    public partial class FExport : FormBase
    {
        private readonly FileNamePlaceholders fileNamePlaceholders;
        private readonly WinFormsExportHelper exportHelper;
        private readonly ChangeTracker changeTracker;
        private readonly DialogHelper dialogHelper;
        private readonly FDesktop fdesktop;
        private readonly ImageSettingsContainer imageSettingsContainer;

        private string filename;
        private string projectName;
      
        private readonly RecoveryIndex recoveryIndex;
        
        
       
        public FExport(FDesktop fdesktop, ImageSettingsContainer imageSettingsContainer, FileNamePlaceholders fileNamePlaceholders, WinFormsExportHelper exportHelper, DialogHelper dialogHelper, ChangeTracker changeTracker, RecoveryIndex recoveryIndex)
        {
            this.fdesktop = fdesktop;
            this.fileNamePlaceholders = fileNamePlaceholders;
            this.exportHelper = exportHelper;
            this.changeTracker = changeTracker;
            this.dialogHelper = dialogHelper;
            this.recoveryIndex = recoveryIndex;
            this.imageSettingsContainer = imageSettingsContainer;
          
            InitializeComponent();

            projectName = imageSettingsContainer.ImageSettings.ProjectName;
            tb_ExportPath.Text = imageSettingsContainer.ImageSettings.DefaultFileName;
            tb_CSVExpression.Text = imageSettingsContainer.ImageSettings.CSVExpression;
            tb_exportFilename.Text = imageSettingsContainer.ImageSettings.CSVFileName;
            cb_CSVEnabler.Checked = imageSettingsContainer.ImageSettings.UseCSVExport;
        }

        public NotificationManager notify { get; set; }

        private void BTN_File_Click(object sender, EventArgs e)
        {
            if (dialogHelper.PromptToSaveImage(tb_ExportPath.Text, out string newPath))
            {
                tb_ExportPath.Text = newPath;
                filename = newPath;
            }

        }

        private void btn_Expression_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<FPlaceholders>();
            form.FileName = tb_ExportPath.Text;
            if (form.ShowDialog() == DialogResult.OK)
            {
                tb_ExportPath.Text = form.FileName;
            }
        }

        private void tb_ExportPath_TextChanged(object sender, EventArgs e)
        {
            if (projectName == null) 
                return;
            
            filename = tb_ExportPath.Text;
            var fileExample = fileNamePlaceholders.SubstitutePlaceholders(tb_ExportPath.Text, DateTime.Now, true);
            var file = Path.GetFileName(fileExample);
            fileExample = Path.Combine(Path.GetDirectoryName(fileExample), projectName);
            fileExample = Path.Combine(fileExample,file);
            LBL_Exemple.Text = fileExample;
        }

        private void cb_CSVEnabler_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = cb_CSVEnabler.Checked;
        }

        private void tb_CSVExpression_TextChanged(object sender, EventArgs e)
        {
            if (filename == null)
                return;

            string text = tb_CSVExpression.Text.Replace("$(filename)", fileNamePlaceholders.SubstitutePlaceholders(filename, DateTime.Now, true));
            text = text.Replace("$(barcode)", "1234-5678");
            text = text.Replace("$(sheetside)", "1=front-2=back");
            lbl_meta.Text = text;
        }

        private void tb_exportFilename_TextChanged(object sender, EventArgs e)
        {

        }

        private void BTN_Cancel_Click(object sender, EventArgs e)
        {
            imageSettingsContainer.ImageSettings = new ImageSettings
            {
                UseCSVExport = false,
                SkipSavePrompt = false,
            };
            Close();
        }

        private void BTN_Export_Click(object sender, EventArgs e)
        {
            imageSettingsContainer.ImageSettings = new ImageSettings()
            {
                DefaultFileName = tb_ExportPath.Text,
                CSVExpression = tb_CSVExpression.Text,
                CSVFileName = tb_exportFilename.Text,
                UseCSVExport = cb_CSVEnabler.Checked,
                ProjectName = this.projectName,
            };
           
            Close();
           
        }
        private async void SaveImages(List<ScannedImage> images)
        {            
            if (await exportHelper.SaveImages(images, notify))
            {

               changeTracker.Made();
               
            }
        }
    }
}
