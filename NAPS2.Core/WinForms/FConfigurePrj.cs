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

namespace NAPS2.WinForms
{
    public partial class FConfigurePrj : FormBase
    {
        
        private readonly FDesktop fdesktop;
        private readonly ImageSettingsContainer imageSettingsContainer;
        private readonly RecoveryManager recoveryManager;
        private List<ProjectSettings> settingList;

        public FConfigurePrj(FDesktop fdesktop, ImageSettingsContainer imageSettingsContainer, RecoveryManager recoveryManager)
        {
            this.fdesktop = fdesktop;
            this.imageSettingsContainer = imageSettingsContainer;
            this.recoveryManager = recoveryManager;
           
            InitializeComponent();
            settingList = imageSettingsContainer.ProjectConfigs.ToList();
           
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
            var form = FormFactory.Create<FProjectName>();
            BackgroundForm.UseImmersiveDarkMode(form.Handle, fdesktop.darkMode);
            form.setFileName(FDesktop.projectName); // The "old" filename will be set
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                FDesktop.projectName = form.getFileName();
                ImageSettingsContainer.ProjectSettings.ProjectName = form.getFileName();
                   
                recoveryManager.Save();               
            }

        }

        private void bt_ExportConfig_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<FExport>();
                       
                
               
            BackgroundForm.UseImmersiveDarkMode(form.Handle, fdesktop.darkMode);

            if (form.ShowDialog() == DialogResult.OK)
            {
  
                
            }
        }

        private void LB_ConfigList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Bt_New_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<FProjectName>();
            var activeConf = new ProjectSettings();
            activeConf = ImageSettingsContainer.ProjectSettings.ShallowCopy();
            BackgroundForm.UseImmersiveDarkMode(form.Handle, fdesktop.darkMode);
            //form.setFileName(ImageSettingsContainer.ProjectSettings.Name); //The "old" filename will be set
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                LB_ConfigList.Items.Add(new ListViewItem().Name = form.getFileName());
                activeConf.Name = form.getFileName();
                imageSettingsContainer.ProjectConfigs.Add(activeConf);

            }
        }

        private void BT_Apply_Click(object sender, EventArgs e)
        {
            ImageSettingsContainer.ProjectSettings = imageSettingsContainer.ProjectConfigs[LB_ConfigList.SelectedIndex];
        }

        private void BT_Remove_Click(object sender, EventArgs e)
        {
            if (LB_ConfigList.Items.Count > 0)
            {
                LB_ConfigList.Items.RemoveAt(LB_ConfigList.SelectedIndex);
                   imageSettingsContainer.ProjectConfigs.RemoveAt(LB_ConfigList.SelectedIndex);
            }
        }

        private void BT_OK_Click(object sender, EventArgs e)
        {

        }

        private void TB_Rename_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<FProjectName>();
            BackgroundForm.UseImmersiveDarkMode(form.Handle, fdesktop.darkMode);
            form.setFileName(imageSettingsContainer.ProjectConfigs[LB_ConfigList.SelectedIndex].Name); //The "old" filename will be set
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                LB_ConfigList.Items[LB_ConfigList.SelectedIndex] = form.getFileName();
                imageSettingsContainer.ProjectConfigs[LB_ConfigList.SelectedIndex].Name = form.getFileName();
            }

        }
    }
}
