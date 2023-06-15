using System;
using System.Windows.Forms;
using NAPS2.ImportExport;
using NAPS2.ImportExport.Images;
using System.IO;

namespace NAPS2.WinForms
{
    public partial class FExport : FormBase
    {
        private readonly FileNamePlaceholders fileNamePlaceholders;
        private readonly ImageSettingsContainer imageSettingsContainer;
        private readonly DialogHelper dialogHelper;

        private string filename;
        private string projectName;
        
        
       
        public FExport(ImageSettingsContainer imageSettingsContainer, FileNamePlaceholders fileNamePlaceholders, DialogHelper dialogHelper)
        {
            this.fileNamePlaceholders = fileNamePlaceholders;
            this.imageSettingsContainer = imageSettingsContainer;
            this.dialogHelper = dialogHelper;
          
            InitializeComponent();

            projectName = ImageSettingsContainer.ProjectSettings.BatchName;
            tb_ExportPath.Text = ImageSettingsContainer.ProjectSettings.DefaultFileName;
            tb_CSVExpression.Text = ImageSettingsContainer.ProjectSettings.CSVExpression;
            tb_exportFilename.Text = ImageSettingsContainer.ProjectSettings.CSVFileName;
            cb_CSVEnabler.Checked = ImageSettingsContainer.ProjectSettings.UseCSVExport;
        }

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
            fileExample = Path.Combine(fileExample, file);
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

            string text = tb_CSVExpression.Text.Replace("$(filename)", Path.GetFileName(fileNamePlaceholders.SubstitutePlaceholders(filename, DateTime.Now, true)));
            text = text.Replace("$(barcode)", "1234-5678");
            text = text.Replace("$(sheetside)", "1=front-2=back");
            lbl_meta.Text = text;
        }

        private void tb_exportFilename_TextChanged(object sender, EventArgs e)
        {

        }

        private void BTN_Cancel_Click(object sender, EventArgs e)
        {     
            //Force back the prompt to normal
            imageSettingsContainer.ImageSettings = new ImageSettings
            {
                SkipSavePrompt = false,
                TiffCompression = imageSettingsContainer.ImageSettings.TiffCompression,
                JpegQuality = imageSettingsContainer.ImageSettings.JpegQuality,
            };
            Close();
        }

        private void BTN_Export_Click(object sender, EventArgs e)
        {
            ImageSettingsContainer.ProjectSettings.DefaultFileName = tb_ExportPath.Text;
            ImageSettingsContainer.ProjectSettings.CSVExpression = tb_CSVExpression.Text;
            ImageSettingsContainer.ProjectSettings.CSVFileName = tb_exportFilename.Text;
            ImageSettingsContainer.ProjectSettings.UseCSVExport = cb_CSVEnabler.Checked;
            ImageSettingsContainer.ProjectSettings.BatchName = this.projectName;
            
            //Force the save prompt to be skipped
            imageSettingsContainer.ImageSettings = new ImageSettings
            {
                SkipSavePrompt = true,
                TiffCompression = imageSettingsContainer.ImageSettings.TiffCompression,
                JpegQuality = imageSettingsContainer.ImageSettings.JpegQuality,
            };

            Close();
        }
    }
}
