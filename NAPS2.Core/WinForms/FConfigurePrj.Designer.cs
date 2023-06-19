namespace NAPS2.WinForms
{
    partial class FConfigurePrj
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FConfigurePrj));
            this.BT_chgProjectName = new System.Windows.Forms.Button();
            this.BT_OK = new System.Windows.Forms.Button();
            this.BT_cancel = new System.Windows.Forms.Button();
            this.BT_ExportConfig = new System.Windows.Forms.Button();
            this.LB_ConfigList = new System.Windows.Forms.ListBox();
            this.Bt_New = new System.Windows.Forms.Button();
            this.BT_Apply = new System.Windows.Forms.Button();
            this.BT_Remove = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BTN_Update = new System.Windows.Forms.Button();
            this.TB_Rename = new System.Windows.Forms.Button();
            this.TB_ConfigName = new System.Windows.Forms.TextBox();
            this.LBL_Name = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BT_chgProjectName
            // 
            resources.ApplyResources(this.BT_chgProjectName, "BT_chgProjectName");
            this.BT_chgProjectName.Name = "BT_chgProjectName";
            this.BT_chgProjectName.UseVisualStyleBackColor = true;
            this.BT_chgProjectName.Click += new System.EventHandler(this.bt_chgProjectName_Click);
            // 
            // BT_OK
            // 
            this.BT_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.BT_OK, "BT_OK");
            this.BT_OK.Name = "BT_OK";
            this.BT_OK.UseVisualStyleBackColor = true;
            this.BT_OK.Click += new System.EventHandler(this.BT_OK_Click);
            // 
            // BT_cancel
            // 
            this.BT_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.BT_cancel, "BT_cancel");
            this.BT_cancel.Name = "BT_cancel";
            this.BT_cancel.UseVisualStyleBackColor = true;
            // 
            // BT_ExportConfig
            // 
            this.BT_ExportConfig.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            resources.ApplyResources(this.BT_ExportConfig, "BT_ExportConfig");
            this.BT_ExportConfig.Name = "BT_ExportConfig";
            this.BT_ExportConfig.UseVisualStyleBackColor = false;
            this.BT_ExportConfig.Click += new System.EventHandler(this.bt_ExportConfig_Click);
            // 
            // LB_ConfigList
            // 
            resources.ApplyResources(this.LB_ConfigList, "LB_ConfigList");
            this.LB_ConfigList.FormattingEnabled = true;
            this.LB_ConfigList.MultiColumn = true;
            this.LB_ConfigList.Name = "LB_ConfigList";
            this.LB_ConfigList.Sorted = true;
            this.LB_ConfigList.SelectedIndexChanged += new System.EventHandler(this.LB_ConfigList_SelectedIndexChanged);
            // 
            // Bt_New
            // 
            resources.ApplyResources(this.Bt_New, "Bt_New");
            this.Bt_New.Name = "Bt_New";
            this.Bt_New.UseVisualStyleBackColor = true;
            this.Bt_New.Click += new System.EventHandler(this.Bt_New_Click);
            // 
            // BT_Apply
            // 
            resources.ApplyResources(this.BT_Apply, "BT_Apply");
            this.BT_Apply.Name = "BT_Apply";
            this.BT_Apply.UseVisualStyleBackColor = true;
            this.BT_Apply.Click += new System.EventHandler(this.BT_Apply_Click);
            // 
            // BT_Remove
            // 
            this.BT_Remove.BackColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.BT_Remove, "BT_Remove");
            this.BT_Remove.Name = "BT_Remove";
            this.BT_Remove.UseVisualStyleBackColor = false;
            this.BT_Remove.Click += new System.EventHandler(this.BT_Remove_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BTN_Update);
            this.groupBox1.Controls.Add(this.TB_Rename);
            this.groupBox1.Controls.Add(this.LB_ConfigList);
            this.groupBox1.Controls.Add(this.BT_Remove);
            this.groupBox1.Controls.Add(this.Bt_New);
            this.groupBox1.Controls.Add(this.BT_Apply);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // BTN_Update
            // 
            resources.ApplyResources(this.BTN_Update, "BTN_Update");
            this.BTN_Update.Name = "BTN_Update";
            this.BTN_Update.UseVisualStyleBackColor = true;
            this.BTN_Update.Click += new System.EventHandler(this.BTN_Update_Click);
            // 
            // TB_Rename
            // 
            resources.ApplyResources(this.TB_Rename, "TB_Rename");
            this.TB_Rename.Name = "TB_Rename";
            this.TB_Rename.UseVisualStyleBackColor = true;
            this.TB_Rename.Click += new System.EventHandler(this.TB_Rename_Click);
            // 
            // TB_ConfigName
            // 
            this.TB_ConfigName.AllowDrop = true;
            this.TB_ConfigName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.TB_ConfigName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.TB_ConfigName, "TB_ConfigName");
            this.TB_ConfigName.ForeColor = System.Drawing.SystemColors.Info;
            this.TB_ConfigName.Name = "TB_ConfigName";
            this.TB_ConfigName.ReadOnly = true;
            // 
            // LBL_Name
            // 
            resources.ApplyResources(this.LBL_Name, "LBL_Name");
            this.LBL_Name.Name = "LBL_Name";
            // 
            // FConfigurePrj
            // 
            this.AcceptButton = this.BT_OK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.BT_cancel;
            this.Controls.Add(this.LBL_Name);
            this.Controls.Add(this.TB_ConfigName);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BT_ExportConfig);
            this.Controls.Add(this.BT_cancel);
            this.Controls.Add(this.BT_OK);
            this.Controls.Add(this.BT_chgProjectName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FConfigurePrj";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BT_chgProjectName;
        private System.Windows.Forms.Button BT_OK;
        private System.Windows.Forms.Button BT_cancel;
        private System.Windows.Forms.Button BT_ExportConfig;
        private System.Windows.Forms.ListBox LB_ConfigList;
        private System.Windows.Forms.Button Bt_New;
        private System.Windows.Forms.Button BT_Apply;
        private System.Windows.Forms.Button BT_Remove;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button TB_Rename;
        private System.Windows.Forms.TextBox TB_ConfigName;
        private System.Windows.Forms.Label LBL_Name;
        private System.Windows.Forms.Button BTN_Update;
    }
}