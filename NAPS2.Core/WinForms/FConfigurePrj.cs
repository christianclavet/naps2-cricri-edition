﻿using System;
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

namespace NAPS2.WinForms
{
    public partial class FConfigurePrj : FormBase
    {
        
        private readonly FDesktop fdesktop;
        private readonly ImageSettingsContainer imageSettingsContainer;

        public FConfigurePrj(FDesktop fdesktop, ImageSettingsContainer imageSettingsContainer)
        {
            this.fdesktop = fdesktop;
            this.imageSettingsContainer = imageSettingsContainer;
            
            InitializeComponent();
        }

        private void bt_chgProjectName_Click(object sender, EventArgs e)
        {
            //fdesktop.changeProjectName();
            var form = FormFactory.Create<FProjectName>();
            BackgroundForm.UseImmersiveDarkMode(form.Handle, fdesktop.darkMode);
            form.setFileName(fdesktop.projectName); // The "old" filename will be set
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                fdesktop.projectName = form.getFileName();
                imageSettingsContainer.ImageSettings = new ImageSettings()
                {
                    ProjectName = form.getFileName(),
                };
                //fdesktop.UpdateToolbar(); // Display the changes TODO: Have to change the way it's saved
            }

        }

        private void bt_ExportConfig_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<FExport>();
            form.SetData();

            //form.setName(fdesktop.projectName);
            //form.notify = fdesktop.notify;
            //form.imagesList = imageList;
            
                
               
            BackgroundForm.UseImmersiveDarkMode(form.Handle, fdesktop.darkMode);

            if (form.ShowDialog() == DialogResult.OK)
            {
  
                
            }
        }
    }
}
