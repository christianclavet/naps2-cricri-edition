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
            resources.ApplyResources(this.BT_ExportConfig, "BT_ExportConfig");
            this.BT_ExportConfig.Name = "BT_ExportConfig";
            this.BT_ExportConfig.UseVisualStyleBackColor = true;
            this.BT_ExportConfig.Click += new System.EventHandler(this.bt_ExportConfig_Click);
            // 
            // FConfigurePrj
            // 
            this.AcceptButton = this.BT_OK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.BT_ExportConfig);
            this.Controls.Add(this.BT_cancel);
            this.Controls.Add(this.BT_OK);
            this.Controls.Add(this.BT_chgProjectName);
            this.Name = "FConfigurePrj";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BT_chgProjectName;
        private System.Windows.Forms.Button BT_OK;
        private System.Windows.Forms.Button BT_cancel;
        private System.Windows.Forms.Button BT_ExportConfig;
    }
}