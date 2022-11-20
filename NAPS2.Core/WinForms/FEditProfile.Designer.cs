using System;
using System.Collections.Generic;
using System.Linq;

namespace NAPS2.WinForms
{
    partial class FEditProfile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FEditProfile));
            this.txtDevice = new System.Windows.Forms.TextBox();
            this.lbl_device = new System.Windows.Forms.Label();
            this.btnChooseDevice = new System.Windows.Forms.Button();
            this.lbl_papersource = new System.Windows.Forms.Label();
            this.cmbSource = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.panelUI = new System.Windows.Forms.Panel();
            this.rdbConfig = new System.Windows.Forms.RadioButton();
            this.rdbNative = new System.Windows.Forms.RadioButton();
            this.lbl_bitdepth = new System.Windows.Forms.Label();
            this.cmbDepth = new System.Windows.Forms.ComboBox();
            this.lbl_pagesize = new System.Windows.Forms.Label();
            this.cmbPage = new System.Windows.Forms.ComboBox();
            this.cmbResolution = new System.Windows.Forms.ComboBox();
            this.lbl_resolution = new System.Windows.Forms.Label();
            this.lbl_brightness = new System.Windows.Forms.Label();
            this.trBrightness = new System.Windows.Forms.TrackBar();
            this.lbl_contrast = new System.Windows.Forms.Label();
            this.trContrast = new System.Windows.Forms.TrackBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pctIcon = new System.Windows.Forms.PictureBox();
            this.lbl_displayname = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cmbAlign = new System.Windows.Forms.ComboBox();
            this.lbl_horizontalalign = new System.Windows.Forms.Label();
            this.cmbScale = new System.Windows.Forms.ComboBox();
            this.lbl_scale = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdTWAIN = new System.Windows.Forms.RadioButton();
            this.rdWIA = new System.Windows.Forms.RadioButton();
            this.rdSANE = new System.Windows.Forms.RadioButton();
            this.txtBrightness = new System.Windows.Forms.TextBox();
            this.txtContrast = new System.Windows.Forms.TextBox();
            this.ilProfileIcons = new NAPS2.WinForms.ILProfileIcons(this.components);
            this.cbAutoSave = new System.Windows.Forms.CheckBox();
            this.linkAutoSaveSettings = new System.Windows.Forms.LinkLabel();
            this.btnAdvanced = new System.Windows.Forms.Button();
            this.btnNetwork = new System.Windows.Forms.Button();
            this.InfoDisplayCaps = new System.Windows.Forms.RichTextBox();
            this.lab_Cap = new System.Windows.Forms.Label();
            this.cmbAutoRotation = new System.Windows.Forms.ComboBox();
            this.lab_AutoRotate = new System.Windows.Forms.Label();
            this.cmbAutoDeskew = new System.Windows.Forms.ComboBox();
            this.lab_autoDeskew = new System.Windows.Forms.Label();
            this.cmbDoubleFeedDet = new System.Windows.Forms.ComboBox();
            this.lab_DoubleFeedDet = new System.Windows.Forms.Label();
            this.cmbDoubleFeedAct = new System.Windows.Forms.ComboBox();
            this.lab_DoubleFeedAct = new System.Windows.Forms.Label();
            this.cmbDoubleSensitivity = new System.Windows.Forms.ComboBox();
            this.lbl_DoubleSensivity = new System.Windows.Forms.Label();
            this.cmbAutoBorderDetection = new System.Windows.Forms.ComboBox();
            this.lbl_AutoBorderDetect = new System.Windows.Forms.Label();
            this.cmbPaperType = new System.Windows.Forms.ComboBox();
            this.LBL_Paper = new System.Windows.Forms.Label();
            this.panelUI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctIcon)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDevice
            // 
            resources.ApplyResources(this.txtDevice, "txtDevice");
            this.txtDevice.Name = "txtDevice";
            this.txtDevice.ReadOnly = true;
            this.txtDevice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDevice_KeyDown);
            // 
            // lbl_device
            // 
            resources.ApplyResources(this.lbl_device, "lbl_device");
            this.lbl_device.Name = "lbl_device";
            // 
            // btnChooseDevice
            // 
            resources.ApplyResources(this.btnChooseDevice, "btnChooseDevice");
            this.btnChooseDevice.Name = "btnChooseDevice";
            this.btnChooseDevice.UseVisualStyleBackColor = true;
            this.btnChooseDevice.Click += new System.EventHandler(this.btnChooseDevice_Click);
            // 
            // lbl_papersource
            // 
            resources.ApplyResources(this.lbl_papersource, "lbl_papersource");
            this.lbl_papersource.Name = "lbl_papersource";
            // 
            // cmbSource
            // 
            this.cmbSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSource.FormattingEnabled = true;
            resources.ApplyResources(this.cmbSource, "cmbSource");
            this.cmbSource.Name = "cmbSource";
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panelUI
            // 
            this.panelUI.Controls.Add(this.rdbConfig);
            this.panelUI.Controls.Add(this.rdbNative);
            resources.ApplyResources(this.panelUI, "panelUI");
            this.panelUI.Name = "panelUI";
            // 
            // rdbConfig
            // 
            resources.ApplyResources(this.rdbConfig, "rdbConfig");
            this.rdbConfig.Name = "rdbConfig";
            this.rdbConfig.TabStop = true;
            this.rdbConfig.UseVisualStyleBackColor = true;
            this.rdbConfig.CheckedChanged += new System.EventHandler(this.rdbConfig_CheckedChanged);
            // 
            // rdbNative
            // 
            resources.ApplyResources(this.rdbNative, "rdbNative");
            this.rdbNative.Name = "rdbNative";
            this.rdbNative.TabStop = true;
            this.rdbNative.UseVisualStyleBackColor = true;
            this.rdbNative.CheckedChanged += new System.EventHandler(this.rdbNativeWIA_CheckedChanged);
            // 
            // lbl_bitdepth
            // 
            resources.ApplyResources(this.lbl_bitdepth, "lbl_bitdepth");
            this.lbl_bitdepth.Name = "lbl_bitdepth";
            // 
            // cmbDepth
            // 
            this.cmbDepth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbDepth, "cmbDepth");
            this.cmbDepth.FormattingEnabled = true;
            this.cmbDepth.Name = "cmbDepth";
            // 
            // lbl_pagesize
            // 
            resources.ApplyResources(this.lbl_pagesize, "lbl_pagesize");
            this.lbl_pagesize.Name = "lbl_pagesize";
            // 
            // cmbPage
            // 
            this.cmbPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbPage, "cmbPage");
            this.cmbPage.FormattingEnabled = true;
            this.cmbPage.Name = "cmbPage";
            this.cmbPage.SelectedIndexChanged += new System.EventHandler(this.cmbPage_SelectedIndexChanged);
            // 
            // cmbResolution
            // 
            this.cmbResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbResolution, "cmbResolution");
            this.cmbResolution.FormattingEnabled = true;
            this.cmbResolution.Name = "cmbResolution";
            // 
            // lbl_resolution
            // 
            resources.ApplyResources(this.lbl_resolution, "lbl_resolution");
            this.lbl_resolution.Name = "lbl_resolution";
            // 
            // lbl_brightness
            // 
            resources.ApplyResources(this.lbl_brightness, "lbl_brightness");
            this.lbl_brightness.Name = "lbl_brightness";
            // 
            // trBrightness
            // 
            resources.ApplyResources(this.trBrightness, "trBrightness");
            this.trBrightness.Maximum = 1000;
            this.trBrightness.Minimum = -1000;
            this.trBrightness.Name = "trBrightness";
            this.trBrightness.TickFrequency = 200;
            this.trBrightness.Scroll += new System.EventHandler(this.trBrightness_Scroll);
            // 
            // lbl_contrast
            // 
            resources.ApplyResources(this.lbl_contrast, "lbl_contrast");
            this.lbl_contrast.Name = "lbl_contrast";
            // 
            // trContrast
            // 
            resources.ApplyResources(this.trContrast, "trContrast");
            this.trContrast.Maximum = 1000;
            this.trContrast.Minimum = -1000;
            this.trContrast.Name = "trContrast";
            this.trContrast.TickFrequency = 200;
            this.trContrast.Scroll += new System.EventHandler(this.trContrast_Scroll);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pctIcon
            // 
            resources.ApplyResources(this.pctIcon, "pctIcon");
            this.pctIcon.Name = "pctIcon";
            this.pctIcon.TabStop = false;
            // 
            // lbl_displayname
            // 
            resources.ApplyResources(this.lbl_displayname, "lbl_displayname");
            this.lbl_displayname.Name = "lbl_displayname";
            // 
            // txtName
            // 
            resources.ApplyResources(this.txtName, "txtName");
            this.txtName.Name = "txtName";
            // 
            // cmbAlign
            // 
            this.cmbAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbAlign, "cmbAlign");
            this.cmbAlign.FormattingEnabled = true;
            this.cmbAlign.Name = "cmbAlign";
            // 
            // lbl_horizontalalign
            // 
            resources.ApplyResources(this.lbl_horizontalalign, "lbl_horizontalalign");
            this.lbl_horizontalalign.Name = "lbl_horizontalalign";
            // 
            // cmbScale
            // 
            this.cmbScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbScale, "cmbScale");
            this.cmbScale.FormattingEnabled = true;
            this.cmbScale.Name = "cmbScale";
            // 
            // lbl_scale
            // 
            resources.ApplyResources(this.lbl_scale, "lbl_scale");
            this.lbl_scale.Name = "lbl_scale";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdTWAIN);
            this.panel2.Controls.Add(this.rdWIA);
            this.panel2.Controls.Add(this.rdSANE);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // rdTWAIN
            // 
            resources.ApplyResources(this.rdTWAIN, "rdTWAIN");
            this.rdTWAIN.Name = "rdTWAIN";
            this.rdTWAIN.TabStop = true;
            this.rdTWAIN.UseVisualStyleBackColor = true;
            this.rdTWAIN.CheckedChanged += new System.EventHandler(this.rdDriver_CheckedChanged);
            // 
            // rdWIA
            // 
            resources.ApplyResources(this.rdWIA, "rdWIA");
            this.rdWIA.Name = "rdWIA";
            this.rdWIA.TabStop = true;
            this.rdWIA.UseVisualStyleBackColor = true;
            this.rdWIA.CheckedChanged += new System.EventHandler(this.rdDriver_CheckedChanged);
            // 
            // rdSANE
            // 
            resources.ApplyResources(this.rdSANE, "rdSANE");
            this.rdSANE.Name = "rdSANE";
            this.rdSANE.TabStop = true;
            this.rdSANE.UseVisualStyleBackColor = true;
            this.rdSANE.CheckedChanged += new System.EventHandler(this.rdDriver_CheckedChanged);
            // 
            // txtBrightness
            // 
            resources.ApplyResources(this.txtBrightness, "txtBrightness");
            this.txtBrightness.Name = "txtBrightness";
            this.txtBrightness.TextChanged += new System.EventHandler(this.txtBrightness_TextChanged);
            // 
            // txtContrast
            // 
            resources.ApplyResources(this.txtContrast, "txtContrast");
            this.txtContrast.Name = "txtContrast";
            this.txtContrast.TextChanged += new System.EventHandler(this.txtContrast_TextChanged);
            // 
            // cbAutoSave
            // 
            resources.ApplyResources(this.cbAutoSave, "cbAutoSave");
            this.cbAutoSave.Name = "cbAutoSave";
            this.cbAutoSave.UseVisualStyleBackColor = true;
            this.cbAutoSave.CheckedChanged += new System.EventHandler(this.cbAutoSave_CheckedChanged);
            // 
            // linkAutoSaveSettings
            // 
            resources.ApplyResources(this.linkAutoSaveSettings, "linkAutoSaveSettings");
            this.linkAutoSaveSettings.Name = "linkAutoSaveSettings";
            this.linkAutoSaveSettings.TabStop = true;
            this.linkAutoSaveSettings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAutoSaveSettings_LinkClicked);
            // 
            // btnAdvanced
            // 
            resources.ApplyResources(this.btnAdvanced, "btnAdvanced");
            this.btnAdvanced.Name = "btnAdvanced";
            this.btnAdvanced.UseVisualStyleBackColor = true;
            this.btnAdvanced.Click += new System.EventHandler(this.btnAdvanced_Click);
            // 
            // btnNetwork
            // 
            resources.ApplyResources(this.btnNetwork, "btnNetwork");
            this.btnNetwork.Image = global::NAPS2.Icons.wireless16;
            this.btnNetwork.Name = "btnNetwork";
            this.btnNetwork.UseVisualStyleBackColor = true;
            this.btnNetwork.Click += new System.EventHandler(this.btnNetwork_Click);
            // 
            // InfoDisplayCaps
            // 
            resources.ApplyResources(this.InfoDisplayCaps, "InfoDisplayCaps");
            this.InfoDisplayCaps.Name = "InfoDisplayCaps";
            this.InfoDisplayCaps.ReadOnly = true;
            this.InfoDisplayCaps.TextChanged += new System.EventHandler(this.InfoDisplayCaps_TextChanged);
            // 
            // lab_Cap
            // 
            resources.ApplyResources(this.lab_Cap, "lab_Cap");
            this.lab_Cap.Name = "lab_Cap";
            // 
            // cmbAutoRotation
            // 
            this.cmbAutoRotation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbAutoRotation, "cmbAutoRotation");
            this.cmbAutoRotation.FormattingEnabled = true;
            this.cmbAutoRotation.Items.AddRange(new object[] {
            resources.GetString("cmbAutoRotation.Items"),
            resources.GetString("cmbAutoRotation.Items1")});
            this.cmbAutoRotation.Name = "cmbAutoRotation";
            this.cmbAutoRotation.SelectedIndexChanged += new System.EventHandler(this.cmbAutoRotation_SelectedIndexChanged);
            // 
            // lab_AutoRotate
            // 
            resources.ApplyResources(this.lab_AutoRotate, "lab_AutoRotate");
            this.lab_AutoRotate.Name = "lab_AutoRotate";
            // 
            // cmbAutoDeskew
            // 
            this.cmbAutoDeskew.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbAutoDeskew, "cmbAutoDeskew");
            this.cmbAutoDeskew.FormattingEnabled = true;
            this.cmbAutoDeskew.Items.AddRange(new object[] {
            resources.GetString("cmbAutoDeskew.Items"),
            resources.GetString("cmbAutoDeskew.Items1")});
            this.cmbAutoDeskew.Name = "cmbAutoDeskew";
            this.cmbAutoDeskew.SelectedIndexChanged += new System.EventHandler(this.cmbAutoDeskew_SelectedIndexChanged);
            // 
            // lab_autoDeskew
            // 
            resources.ApplyResources(this.lab_autoDeskew, "lab_autoDeskew");
            this.lab_autoDeskew.Name = "lab_autoDeskew";
            // 
            // cmbDoubleFeedDet
            // 
            this.cmbDoubleFeedDet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbDoubleFeedDet, "cmbDoubleFeedDet");
            this.cmbDoubleFeedDet.FormattingEnabled = true;
            this.cmbDoubleFeedDet.Items.AddRange(new object[] {
            resources.GetString("cmbDoubleFeedDet.Items"),
            resources.GetString("cmbDoubleFeedDet.Items1"),
            resources.GetString("cmbDoubleFeedDet.Items2")});
            this.cmbDoubleFeedDet.Name = "cmbDoubleFeedDet";
            this.cmbDoubleFeedDet.SelectedIndexChanged += new System.EventHandler(this.cmbDoubleFeedDet_SelectedIndexChanged);
            // 
            // lab_DoubleFeedDet
            // 
            resources.ApplyResources(this.lab_DoubleFeedDet, "lab_DoubleFeedDet");
            this.lab_DoubleFeedDet.Name = "lab_DoubleFeedDet";
            // 
            // cmbDoubleFeedAct
            // 
            this.cmbDoubleFeedAct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbDoubleFeedAct, "cmbDoubleFeedAct");
            this.cmbDoubleFeedAct.FormattingEnabled = true;
            this.cmbDoubleFeedAct.Items.AddRange(new object[] {
            resources.GetString("cmbDoubleFeedAct.Items"),
            resources.GetString("cmbDoubleFeedAct.Items1"),
            resources.GetString("cmbDoubleFeedAct.Items2")});
            this.cmbDoubleFeedAct.Name = "cmbDoubleFeedAct";
            this.cmbDoubleFeedAct.SelectedIndexChanged += new System.EventHandler(this.cmbDoubleFeedAct_SelectedIndexChanged);
            // 
            // lab_DoubleFeedAct
            // 
            resources.ApplyResources(this.lab_DoubleFeedAct, "lab_DoubleFeedAct");
            this.lab_DoubleFeedAct.Name = "lab_DoubleFeedAct";
            // 
            // cmbDoubleSensitivity
            // 
            resources.ApplyResources(this.cmbDoubleSensitivity, "cmbDoubleSensitivity");
            this.cmbDoubleSensitivity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDoubleSensitivity.FormattingEnabled = true;
            this.cmbDoubleSensitivity.Items.AddRange(new object[] {
            resources.GetString("cmbDoubleSensitivity.Items"),
            resources.GetString("cmbDoubleSensitivity.Items1"),
            resources.GetString("cmbDoubleSensitivity.Items2")});
            this.cmbDoubleSensitivity.Name = "cmbDoubleSensitivity";
            this.cmbDoubleSensitivity.SelectedIndexChanged += new System.EventHandler(this.cmbDoubleSensitivity_SelectedIndexChanged);
            // 
            // lbl_DoubleSensivity
            // 
            resources.ApplyResources(this.lbl_DoubleSensivity, "lbl_DoubleSensivity");
            this.lbl_DoubleSensivity.Name = "lbl_DoubleSensivity";
            // 
            // cmbAutoBorderDetection
            // 
            resources.ApplyResources(this.cmbAutoBorderDetection, "cmbAutoBorderDetection");
            this.cmbAutoBorderDetection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAutoBorderDetection.FormattingEnabled = true;
            this.cmbAutoBorderDetection.Items.AddRange(new object[] {
            resources.GetString("cmbAutoBorderDetection.Items"),
            resources.GetString("cmbAutoBorderDetection.Items1")});
            this.cmbAutoBorderDetection.Name = "cmbAutoBorderDetection";
            this.cmbAutoBorderDetection.SelectedIndexChanged += new System.EventHandler(this.cmbAutoBorderDetection_SelectedIndexChanged);
            // 
            // lbl_AutoBorderDetect
            // 
            resources.ApplyResources(this.lbl_AutoBorderDetect, "lbl_AutoBorderDetect");
            this.lbl_AutoBorderDetect.Name = "lbl_AutoBorderDetect";
            // 
            // cmbPaperType
            // 
            this.cmbPaperType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbPaperType, "cmbPaperType");
            this.cmbPaperType.FormattingEnabled = true;
            this.cmbPaperType.Items.AddRange(new object[] {
            resources.GetString("cmbPaperType.Items"),
            resources.GetString("cmbPaperType.Items1"),
            resources.GetString("cmbPaperType.Items2"),
            resources.GetString("cmbPaperType.Items3"),
            resources.GetString("cmbPaperType.Items4")});
            this.cmbPaperType.Name = "cmbPaperType";
            this.cmbPaperType.SelectedIndexChanged += new System.EventHandler(this.cmbPaperType_SelectedIndexChanged);
            // 
            // LBL_Paper
            // 
            resources.ApplyResources(this.LBL_Paper, "LBL_Paper");
            this.LBL_Paper.Name = "LBL_Paper";
            // 
            // FEditProfile
            // 
            this.AcceptButton = this.btnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.cmbPaperType);
            this.Controls.Add(this.LBL_Paper);
            this.Controls.Add(this.cmbAutoBorderDetection);
            this.Controls.Add(this.lbl_AutoBorderDetect);
            this.Controls.Add(this.cmbDoubleSensitivity);
            this.Controls.Add(this.lbl_DoubleSensivity);
            this.Controls.Add(this.cmbDoubleFeedAct);
            this.Controls.Add(this.lab_DoubleFeedAct);
            this.Controls.Add(this.cmbDoubleFeedDet);
            this.Controls.Add(this.lab_DoubleFeedDet);
            this.Controls.Add(this.cmbAutoDeskew);
            this.Controls.Add(this.lab_autoDeskew);
            this.Controls.Add(this.cmbAutoRotation);
            this.Controls.Add(this.lab_AutoRotate);
            this.Controls.Add(this.lab_Cap);
            this.Controls.Add(this.InfoDisplayCaps);
            this.Controls.Add(this.btnNetwork);
            this.Controls.Add(this.btnAdvanced);
            this.Controls.Add(this.linkAutoSaveSettings);
            this.Controls.Add(this.cbAutoSave);
            this.Controls.Add(this.txtContrast);
            this.Controls.Add(this.txtBrightness);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cmbScale);
            this.Controls.Add(this.lbl_scale);
            this.Controls.Add(this.cmbAlign);
            this.Controls.Add(this.lbl_horizontalalign);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lbl_displayname);
            this.Controls.Add(this.pctIcon);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.trContrast);
            this.Controls.Add(this.lbl_contrast);
            this.Controls.Add(this.trBrightness);
            this.Controls.Add(this.lbl_brightness);
            this.Controls.Add(this.cmbResolution);
            this.Controls.Add(this.lbl_resolution);
            this.Controls.Add(this.cmbPage);
            this.Controls.Add(this.lbl_pagesize);
            this.Controls.Add(this.cmbDepth);
            this.Controls.Add(this.lbl_bitdepth);
            this.Controls.Add(this.panelUI);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cmbSource);
            this.Controls.Add(this.lbl_papersource);
            this.Controls.Add(this.btnChooseDevice);
            this.Controls.Add(this.lbl_device);
            this.Controls.Add(this.txtDevice);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FEditProfile";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.panelUI.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctIcon)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDevice;
        private System.Windows.Forms.Label lbl_device;
        private System.Windows.Forms.Button btnChooseDevice;
        private System.Windows.Forms.Label lbl_papersource;
        private System.Windows.Forms.ComboBox cmbSource;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel panelUI;
        private System.Windows.Forms.RadioButton rdbConfig;
        private System.Windows.Forms.RadioButton rdbNative;
        private System.Windows.Forms.Label lbl_bitdepth;
        private System.Windows.Forms.ComboBox cmbDepth;
        private System.Windows.Forms.Label lbl_pagesize;
        private System.Windows.Forms.ComboBox cmbPage;
        private System.Windows.Forms.ComboBox cmbResolution;
        private System.Windows.Forms.Label lbl_resolution;
        private System.Windows.Forms.Label lbl_brightness;
        private System.Windows.Forms.TrackBar trBrightness;
        private System.Windows.Forms.Label lbl_contrast;
        private System.Windows.Forms.TrackBar trContrast;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox pctIcon;
        private System.Windows.Forms.Label lbl_displayname;
        private System.Windows.Forms.TextBox txtName;
        private ILProfileIcons ilProfileIcons;
        private System.Windows.Forms.ComboBox cmbAlign;
        private System.Windows.Forms.Label lbl_horizontalalign;
        private System.Windows.Forms.ComboBox cmbScale;
        private System.Windows.Forms.Label lbl_scale;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdTWAIN;
        private System.Windows.Forms.RadioButton rdWIA;
        private System.Windows.Forms.TextBox txtBrightness;
        private System.Windows.Forms.TextBox txtContrast;
        private System.Windows.Forms.CheckBox cbAutoSave;
        private System.Windows.Forms.LinkLabel linkAutoSaveSettings;
        private System.Windows.Forms.Button btnAdvanced;
        private System.Windows.Forms.RadioButton rdSANE;
        private System.Windows.Forms.Button btnNetwork;
        private System.Windows.Forms.RichTextBox InfoDisplayCaps;
        private System.Windows.Forms.Label lab_Cap;
        private System.Windows.Forms.ComboBox cmbAutoRotation;
        private System.Windows.Forms.Label lab_AutoRotate;
        private System.Windows.Forms.ComboBox cmbAutoDeskew;
        private System.Windows.Forms.Label lab_autoDeskew;
        private System.Windows.Forms.ComboBox cmbDoubleFeedDet;
        private System.Windows.Forms.Label lab_DoubleFeedDet;
        private System.Windows.Forms.ComboBox cmbDoubleFeedAct;
        private System.Windows.Forms.Label lab_DoubleFeedAct;
        private System.Windows.Forms.ComboBox cmbDoubleSensitivity;
        private System.Windows.Forms.Label lbl_DoubleSensivity;
        private System.Windows.Forms.ComboBox cmbAutoBorderDetection;
        private System.Windows.Forms.Label lbl_AutoBorderDetect;
        private System.Windows.Forms.ComboBox cmbPaperType;
        private System.Windows.Forms.Label LBL_Paper;
    }
}
