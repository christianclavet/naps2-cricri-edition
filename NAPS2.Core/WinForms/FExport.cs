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
        private string final_filename;
        private string final_extension;
        
        
       
        public FExport(ImageSettingsContainer imageSettingsContainer, FileNamePlaceholders fileNamePlaceholders, DialogHelper dialogHelper)
        {
            this.fileNamePlaceholders = fileNamePlaceholders;
            this.imageSettingsContainer = imageSettingsContainer;
            this.dialogHelper = dialogHelper;

            InitializeComponent();

            //Set values in the GUI

            bool forceCSVName = true;
            string tempstring = Path.GetExtension(ImageSettingsContainer.ProjectSettings.CSVFileName);
            if (ImageSettingsContainer.ProjectSettings.CSVFileName==null)
            { 
                tempstring = ".csv";
            }

            //Create the filetypes
            CB_Filetype.Items.Add("Jpeg file (.jpg)");
            CB_Filetype.Items.Add("PNG file (.png)");
            CB_Filetype.Items.Add("TIFF file (.tif)");
            final_extension = Path.GetExtension(ImageSettingsContainer.ProjectSettings.DefaultFileName);
            if (final_extension == "") 
            {
                final_extension = ".jpg";
                CB_Filetype.SelectedIndex = 0;
            }
                    

            projectName = ImageSettingsContainer.ProjectSettings.BatchName;
            if (projectName == "")
                projectName = FDesktop.projectName;

            tb_ExportPath.Text = Path.GetDirectoryName(ImageSettingsContainer.ProjectSettings.DefaultFileName);
            filename = Path.GetFileNameWithoutExtension(ImageSettingsContainer.ProjectSettings.DefaultFileName);
            
            tb_CSVExpression.Text = ImageSettingsContainer.ProjectSettings.CSVExpression;
            TB_filename.Text = Path.GetFileNameWithoutExtension(ImageSettingsContainer.ProjectSettings.DefaultFileName);

            final_filename = tb_ExportPath.Text + TB_filename.Text + final_extension;
            
            if (forceCSVName)
                tb_exportFilename.Text = projectName+tempstring;
            else
                tb_exportFilename.Text = ImageSettingsContainer.ProjectSettings.CSVFileName;

            cb_CSVEnabler.Checked = ImageSettingsContainer.ProjectSettings.UseCSVExport;

            //Create the expressions
            LB_Expressions.Items.Add("$(filename)");
            LB_Expressions.Items.Add("$(sheetside)");
            LB_Expressions.Items.Add("$(barcode)");
            
           
            
        }

        private void BTN_File_Click(object sender, EventArgs e)
        {
            if (dialogHelper.PromptToSaveImage(final_filename, out string newPath))
            {
                filename = newPath;
                tb_ExportPath.Text = Path.GetDirectoryName(newPath);
                var file2 = Path.Combine(Path.GetDirectoryName(filename), projectName);
                file2 = Path.Combine(file2,Path.GetFileName(filename));
                final_filename = file2;
                LBL_Exemple.Text = fileNamePlaceholders.SubstitutePlaceholders(final_filename, DateTime.Now, true);
            }

        }

        private void btn_Expression_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<FPlaceholders>();
            form.FileName = TB_filename.Text;
            if (form.ShowDialog() == DialogResult.OK)
            {
                TB_filename.Text = form.FileName;
                filename = TB_filename.Text;
            }
            
        }
        private void TB_filename_TextChanged(object sender, EventArgs e)
        {
            filename = TB_filename.Text+final_extension;
            var fileExample = fileNamePlaceholders.SubstitutePlaceholders(TB_filename.Text, DateTime.Now, true);
            var file = Path.GetFileName(fileExample);
            fileExample = Path.Combine(tb_ExportPath.Text, projectName);
            fileExample = Path.Combine(fileExample, Path.GetFileNameWithoutExtension(file) + final_extension);
            LBL_Exemple.Text = fileExample;
        }
        private void tb_ExportPath_TextChanged(object sender, EventArgs e)
        {
            var file = fileNamePlaceholders.SubstitutePlaceholders(TB_filename.Text+final_extension, DateTime.Now, true);
            var path = tb_ExportPath.Text;
            path = Path.Combine(path, projectName);
            path = Path.Combine(path, Path.GetFileNameWithoutExtension(file)+final_extension);
            LBL_Exemple.Text = path;
        }

        private void cb_CSVEnabler_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = cb_CSVEnabler.Checked;
        }

        private void tb_CSVExpression_TextChanged(object sender, EventArgs e)
        {

            string text = tb_CSVExpression.Text.Replace("$(filename)", Path.GetFileName(fileNamePlaceholders.SubstitutePlaceholders(filename, DateTime.Now, true)+final_extension));
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
            ImageSettingsContainer.ProjectSettings.DefaultFileName = final_filename;
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

        private void Expression_add_Click(object sender, EventArgs e)
        {

        }

        private void LB_Expressions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CB_Filetype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
