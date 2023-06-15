using NAPS2.Config;
using NAPS2.ImportExport.Images;
using NAPS2.Recovery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NAPS2.WinForms
{
    public partial class FProjectName : FormBase
    {
        private readonly FDesktop fdesktop;
        private readonly ImageSettingsContainer imageSettingsContainer;
        private readonly RecoveryManager recoveryManager;
        private readonly ProjectConfigManager projectConfigManager;
        private List<ProjectSettings> settingList;
        public FProjectName(FDesktop fdesktop, ImageSettingsContainer imageSettingsContainer, RecoveryManager recoveryManager, ProjectConfigManager projectConfigManager)
        {
            RestoreFormState = false;
            InitializeComponent();
            AcceptButton = btnAccept;
            CancelButton = btnCancel;

            this.fdesktop = fdesktop;
            this.imageSettingsContainer = imageSettingsContainer;
            this.recoveryManager = recoveryManager;
            this.projectConfigManager = projectConfigManager;

            settingList = projectConfigManager.Settings;

            GB_Project.Hide();

            Description.Hide();
            LBL_desc.Hide();
            

            if (settingList != null)
            {
                foreach (var value in settingList)
                {
                    CB_ProjectType.Items.Add(new ListViewItem().Name = value.Name);
                }
            }

            //InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnRecover_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public string getFileName()
        {
            return inputTextBox.Text;
        }

        public void setFileName(string text) 
        {
            inputTextBox.Text = text;
        }

        private void CB_ProjectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var activeProj = projectConfigManager.Settings[CB_ProjectType.SelectedIndex].Clone();
            activeProj.BatchName = FDesktop.projectName;
            ImageSettingsContainer.ProjectSettings = activeProj.Clone();
        }

        public void ShowProjects(bool visible)
        {
            if (visible)
                GB_Project.Show();
            else
                GB_Project.Hide();
        }

        private void Description_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
