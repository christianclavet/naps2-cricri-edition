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
using System.IO;
using System.Drawing.Drawing2D;
using System.Diagnostics.PerformanceData;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NAPS2.WinForms
{
    public partial class FConfigurePrj : FormBase
    {
        
        private readonly FDesktop fdesktop;
        private readonly RecoveryManager recoveryManager;
        private readonly ProjectConfigManager projectConfigManager;
        private readonly ImageSettingsContainer imageSettingsContainer;
        private List<ProjectSettings> settingList;

        public FConfigurePrj(FDesktop fdesktop, RecoveryManager recoveryManager, ProjectConfigManager projectConfigManager, ImageSettingsContainer imageSettingsContainer)
        {
            this.fdesktop = fdesktop;
            this.recoveryManager = recoveryManager;
            this.projectConfigManager = projectConfigManager;
            this.imageSettingsContainer = imageSettingsContainer;
           
            InitializeComponent();
            settingList = projectConfigManager.Settings;
            ImageSettingsContainer.ProjectSettings = imageSettingsContainer.Project_Settings.Clone();
            TB_ConfigName.Text = imageSettingsContainer.Project_Settings.Name;

            if (settingList != null ) 
            { 
                foreach (var value in settingList)
                {
                    LB_ConfigList.Items.Add(new ListViewItem().Name = value.Name);
                }
            }
        }

        private void bt_chgProjectName_Click(object sender, EventArgs e)
        {
            //rename the current batch
            var form = FormFactory.Create<FProjectName>();
            BackgroundForm.UseImmersiveDarkMode(form.Handle, FDesktop.darkMode);
            form.setFileName(FDesktop.projectName); // The "old" filename will be set
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                FDesktop.projectName = form.getFileName();
                ImageSettingsContainer.ProjectSettings.BatchName = form.getFileName();
                imageSettingsContainer.Project_Settings.BatchName = form.getFileName();
                   
                recoveryManager.Save();
            }

        }

        private void bt_ExportConfig_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<FExport>();                
            BackgroundForm.UseImmersiveDarkMode(form.Handle, FDesktop.darkMode);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                UpdateConfig();
                projectConfigManager.Save();
                ImageSettingsContainer.ProjectSettings = imageSettingsContainer.Project_Settings.Clone();
                
            }
        }

        private void LB_ConfigList_SelectedIndexChanged(object sender, EventArgs e)
        {
           TB_ConfigName.Text = imageSettingsContainer.Project_Settings.Name;
        }

        private void Bt_New_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<FProjectName>();
            BackgroundForm.UseImmersiveDarkMode(form.Handle, FDesktop.darkMode);

            form.setFileName(imageSettingsContainer.Project_Settings.Name);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                LB_ConfigList.Items.Add(new ListViewItem().Name = form.getFileName());

                var currentConfig = imageSettingsContainer.Project_Settings;
                currentConfig.Name = form.getFileName();
                currentConfig.BatchName = "";
                projectConfigManager.Settings.Add(currentConfig.Clone());
                projectConfigManager.Save();

                TB_ConfigName.Text = imageSettingsContainer.Project_Settings.Name;
            }
        }

        private void BT_Apply_Click(object sender, EventArgs e)
        {
            var savedConfig = projectConfigManager.Settings[LB_ConfigList.SelectedIndex].Clone();
            savedConfig.BatchName = FDesktop.projectName;
            ImageSettingsContainer.ProjectSettings = savedConfig.Clone();
            imageSettingsContainer.Project_Settings = savedConfig.Clone();
            TB_ConfigName.Text = imageSettingsContainer.Project_Settings.Name;
            projectConfigManager.Save();
        }

        private void BT_Remove_Click(object sender, EventArgs e)
        {
            if (LB_ConfigList.Items.Count > 0)
            {
                var index = LB_ConfigList.SelectedIndex;
                if (index < 0)
                    return;

                LB_ConfigList.Items.RemoveAt(index);
                projectConfigManager.Settings.RemoveAt(index);
                projectConfigManager.Save();
            }
        }

        private void BT_OK_Click(object sender, EventArgs e)
        {

        }

        private void TB_Rename_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<FProjectName>();
            BackgroundForm.UseImmersiveDarkMode(form.Handle, FDesktop.darkMode);

            form.setFileName(projectConfigManager.Settings[LB_ConfigList.SelectedIndex].Name); //The "old" filename will be set
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                LB_ConfigList.Items[LB_ConfigList.SelectedIndex] = form.getFileName();
                projectConfigManager.Settings[LB_ConfigList.SelectedIndex].Name = form.getFileName();
                projectConfigManager.Save();
            }

        }

        private void UpdateConfig()
        {
            var index = LB_ConfigList.SelectedIndex;
            if (index < 0)
                return;

            /*for (int i = 0; i < LB_ConfigList.Items.Count; i++)
            {
                if (LB_ConfigList.Items[i].ToString() == (string)imageSettingsContainer.Project_Settings.Name)
                    index = i;
            }*/

            string title = (string)LB_ConfigList.Items[index];
            projectConfigManager.Settings[index] = imageSettingsContainer.Project_Settings.Clone();
            projectConfigManager.Settings[index].Name = title;
            projectConfigManager.Save();


        }

        private void BTN_Update_Click(object sender, EventArgs e)
        {
            UpdateConfig();
        }
    }
}
