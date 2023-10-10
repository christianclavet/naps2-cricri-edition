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

        private string filename = "";
        private string projectName = "";
        private string final_filename = "";
        private string final_extension = "";
       
        public FExport(ImageSettingsContainer imageSettingsContainer, FileNamePlaceholders fileNamePlaceholders, DialogHelper dialogHelper)
        {
            this.fileNamePlaceholders = fileNamePlaceholders;
            this.imageSettingsContainer = imageSettingsContainer;
            this.dialogHelper = dialogHelper;

            ImageSettingsContainer.ProjectSettings = imageSettingsContainer.Project_Settings.Clone();

            InitializeComponent();

            //Set values in the GUI

            bool forceCSVName = true; //Flag to force the name of the batch as the name of the CSV file (default). Later user might want to change it.
            string tempstring = Path.GetExtension(ImageSettingsContainer.ProjectSettings.CSVFileName);
            if (ImageSettingsContainer.ProjectSettings.CSVFileName==null)
            { 
                tempstring = ".csv";
            }

            //Create the filetypes
            CB_Filetype.Items.Add("Jpeg file (.jpg)");
            CB_Filetype.Items.Add("PNG file (.png)");
            CB_Filetype.Items.Add("TIFF file (.tif)");

            setExtensionGUI();



            projectName = ImageSettingsContainer.ProjectSettings.BatchName;
            if (projectName == "")
                projectName = FDesktop.projectName;

            tb_ExportPath.Text = Path.GetDirectoryName(ImageSettingsContainer.ProjectSettings.DefaultFileName);
            filename = Path.GetFileNameWithoutExtension(ImageSettingsContainer.ProjectSettings.DefaultFileName);
            
            tb_CSVExpression.Text = ImageSettingsContainer.ProjectSettings.CSVExpression;
            TB_filename.Text = Path.GetFileNameWithoutExtension(ImageSettingsContainer.ProjectSettings.DefaultFileName);

            final_filename = Path.Combine(tb_ExportPath.Text,TB_filename.Text) + final_extension;

            if (forceCSVName)
                tb_exportFilename.Text = projectName+tempstring;
            else
                tb_exportFilename.Text = ImageSettingsContainer.ProjectSettings.CSVFileName;

            cb_CSVEnabler.Checked = ImageSettingsContainer.ProjectSettings.UseCSVExport;

            //Create the expressions
            LB_Expressions.Items.Add("$(filename)");
            LB_Expressions.Items.Add("$(sheetside)");
            LB_Expressions.Items.Add("$(barcode)");
            Expression_add.Enabled = false;

            if (tb_ExportPath.Text.Length > 0)
            {
                BTN_OK.Enabled = true;
            }
            else 
            {
                BTN_OK.Enabled = false;
            }
            
            
        }

        private void setExtensionGUI()
        {
            final_extension = Path.GetExtension(ImageSettingsContainer.ProjectSettings.DefaultFileName);
            if (final_extension == "")
            {
                final_extension = ".jpg";
                CB_Filetype.SelectedIndex = 0;
            }

            if (final_extension == ".jpg")
                CB_Filetype.SelectedIndex = 0;

            if (final_extension == ".png")
                CB_Filetype.SelectedIndex = 1;

            if (final_extension == ".tif")
                CB_Filetype.SelectedIndex = 2;

        }

        private void BTN_File_Click(object sender, EventArgs e)
        {
            if (dialogHelper.PromptToSaveImage(final_filename, out string newPath))
            {
                filename = newPath;
                tb_ExportPath.Text = Path.GetDirectoryName(newPath);
                var file2 = Path.Combine(Path.GetDirectoryName(filename), projectName);
                file2 = Path.Combine(file2,Path.GetFileName(filename));
                final_filename = Path.Combine(tb_ExportPath.Text, TB_filename.Text) + final_extension;
                LBL_Exemple.Text = fileNamePlaceholders.SubstitutePlaceholders(file2, DateTime.Now, true);
                if (tb_ExportPath.Text.Length > 0)
                {
                    BTN_OK.Enabled = true;
                }
            }

        }

        private void Btn_Expression_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<FPlaceholders>();
            form.FileName = TB_filename.Text;
            if (form.ShowDialog() == DialogResult.OK)
            {
                TB_filename.Text = form.FileName;
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

            final_filename = Path.Combine(tb_ExportPath.Text, TB_filename.Text) + final_extension;
        }
        private void tb_ExportPath_TextChanged(object sender, EventArgs e)
        {
            var file = fileNamePlaceholders.SubstitutePlaceholders(TB_filename.Text+final_extension, DateTime.Now, true);
            var path = tb_ExportPath.Text;
            path = Path.Combine(path, projectName);
            path = Path.Combine(path, Path.GetFileNameWithoutExtension(file)+final_extension);
            LBL_Exemple.Text = path;

            final_filename = Path.Combine(tb_ExportPath.Text, TB_filename.Text) + final_extension;
            if (tb_ExportPath.Text.Length > 0)
            {
                BTN_OK.Enabled = true;
            }
        }

        private void cb_CSVEnabler_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = cb_CSVEnabler.Checked;
        }

        private void tb_CSVExpression_TextChanged(object sender, EventArgs e)
        {
            CreatePreviewExpression();
        }

        private void CreatePreviewExpression()
        {
            string text = tb_CSVExpression.Text.Replace("$(filename)", Path.GetFileNameWithoutExtension(fileNamePlaceholders.SubstitutePlaceholders(filename, DateTime.Now, true)) + final_extension);
            text = text.Replace("$(barcode)", "1234-5678");
            text = text.Replace("$(sheetside)", "1=front-2=back");
            lbl_meta.Text = text;
        }

        private void tb_exportFilename_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void Expression_add_Click(object sender, EventArgs e)
        {
            if (tb_CSVExpression.Text.Length > 0) 
            {
                tb_CSVExpression.Text += "," + LB_Expressions.Text;
            } else 
                tb_CSVExpression.Text += LB_Expressions.Text;


        }

        private void LB_Expressions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LB_Expressions.SelectedIndex != -1)
            {
                Expression_add.Enabled = true;
            } else

                Expression_add.Enabled = false;

        }

        private void CB_Filetype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_Filetype.SelectedIndex == 0) 
            {
                final_extension = ".jpg";
            }
            if (CB_Filetype.SelectedIndex == 1)
            {
                final_extension = ".png";
            }
            if (CB_Filetype.SelectedIndex == 2)
            {
                final_extension = ".tif";
            }

            var file = fileNamePlaceholders.SubstitutePlaceholders(TB_filename.Text + final_extension, DateTime.Now, true);
            
            var path = Path.Combine(tb_ExportPath.Text, projectName);
            path = Path.Combine(path, file);
            LBL_Exemple.Text = path;
            final_filename = Path.Combine(tb_ExportPath.Text, TB_filename.Text) + final_extension;

            CreatePreviewExpression();
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

            imageSettingsContainer.Project_Settings = new ProjectSettings
            {
                DefaultFileName = final_filename,
                CSVExpression = tb_CSVExpression.Text,
                CSVFileName = tb_exportFilename.Text,
                UseCSVExport = cb_CSVEnabler.Checked,
                BatchName = this.projectName,
                Name = imageSettingsContainer.Project_Settings.Name,
            };

            ImageSettingsContainer.ProjectSettings = imageSettingsContainer.Project_Settings.Clone();

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
