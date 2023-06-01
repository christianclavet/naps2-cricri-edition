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
using NTwain.Data;

namespace NAPS2.WinForms
{
    public partial class FExport : FormBase
    {
        private readonly FileNamePlaceholders fileNamePlaceholders;
        private readonly WinFormsExportHelper exportHelper;
        private readonly FDesktop fdesktop;
        private readonly ChangeTracker changeTracker;
        private readonly DialogHelper dialogHelper;
        private readonly ImageSettingsContainer imageSettingsContainer;
        private string filename;



        public FExport(FDesktop fdesktop, FileNamePlaceholders fileNamePlaceholders, WinFormsExportHelper exportHelper, DialogHelper dialogHelper, ChangeTracker changeTracker, ImageSettingsContainer imageSettingsContainer)
        {
            this.fileNamePlaceholders = fileNamePlaceholders;
            this.exportHelper = exportHelper;
            this.fdesktop = fdesktop;
            this.changeTracker = changeTracker;
            this.dialogHelper = dialogHelper;
            this.imageSettingsContainer = imageSettingsContainer;
            InitializeComponent();
            
        }

        public string projectName { get; set; }

        public NotificationManager notify { get; set; }

        public ScannedImageList imagesList { get; set; }


        public void setName(string name) 
        {
            projectName = name;
            tb_ExportPath.Text = "$(nnnnnnnn).jpg";
            filename = tb_ExportPath.Text;
            tb_exportFilename.Text = name + ".csv";
            tb_CSVExpression.Text = "$(filename)";
        }

        private void BTN_File_Click(object sender, EventArgs e)
        {
            if (dialogHelper.PromptToSaveImage(tb_ExportPath.Text, out string newPath))
            {
                tb_ExportPath.Text = newPath;
                filename = newPath;
                imageSettingsContainer.ImageSettings = new ImageSettings
                {
                    DefaultFileName = newPath,
                    SkipSavePrompt = true,                               
                };
            }

        }

        private void btn_Expression_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<FPlaceholders>();
            form.FileName = tb_ExportPath.Text;
            if (form.ShowDialog() == DialogResult.OK)
            {
                tb_ExportPath.Text = form.FileName; //fileNamePlaceholders.SubstitutePlaceholders(form.FileName,DateTime.Now,true);
                imageSettingsContainer.ImageSettings = new ImageSettings
                {
                    DefaultFileName = form.FileName,
                    SkipSavePrompt = true,

                };
            }
        }

        private void tb_ExportPath_TextChanged(object sender, EventArgs e)
        {
            LBL_Exemple.Text = fileNamePlaceholders.SubstitutePlaceholders(tb_ExportPath.Text, DateTime.Now, true);
            filename = tb_ExportPath.Text;
            imageSettingsContainer.ImageSettings = new ImageSettings
            {
                DefaultFileName = tb_ExportPath.Text,
                SkipSavePrompt = true,

            };
        }

        private void cb_CSVEnabler_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = cb_CSVEnabler.Checked;
        }

        private void tb_CSVExpression_TextChanged(object sender, EventArgs e)
        {
            string text = tb_CSVExpression.Text.Replace("$(filename)", fileNamePlaceholders.SubstitutePlaceholders(filename, DateTime.Now, true));
            text = text.Replace("$(barcode)", "1234-5678");
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
            imageSettingsContainer.ImageSettings = new ImageSettings
            {
                DefaultFileName = tb_ExportPath.Text,
                CSVExpression = tb_CSVExpression.Text,
                CSVFileName = tb_exportFilename.Text,
                SkipSavePrompt = true,
                UseCSVExport = cb_CSVEnabler.Checked,
            };

            SaveImages(imagesList.Images);

            imageSettingsContainer.ImageSettings = new ImageSettings
            {
                UseCSVExport = false,
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
