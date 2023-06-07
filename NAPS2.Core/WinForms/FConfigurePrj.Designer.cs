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
            this.bt_chgProjectName = new System.Windows.Forms.Button();
            this.bt_OK = new System.Windows.Forms.Button();
            this.Bt_cancel = new System.Windows.Forms.Button();
            this.bt_ExportConfig = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_chgProjectName
            // 
            resources.ApplyResources(this.bt_chgProjectName, "bt_chgProjectName");
            this.bt_chgProjectName.Name = "bt_chgProjectName";
            this.bt_chgProjectName.UseVisualStyleBackColor = true;
            this.bt_chgProjectName.Click += new System.EventHandler(this.bt_chgProjectName_Click);
            // 
            // bt_OK
            // 
            this.bt_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.bt_OK, "bt_OK");
            this.bt_OK.Name = "bt_OK";
            this.bt_OK.UseVisualStyleBackColor = true;
            // 
            // Bt_cancel
            // 
            this.Bt_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.Bt_cancel, "Bt_cancel");
            this.Bt_cancel.Name = "Bt_cancel";
            this.Bt_cancel.UseVisualStyleBackColor = true;
            // 
            // bt_ExportConfig
            // 
            resources.ApplyResources(this.bt_ExportConfig, "bt_ExportConfig");
            this.bt_ExportConfig.Name = "bt_ExportConfig";
            this.bt_ExportConfig.UseVisualStyleBackColor = true;
            this.bt_ExportConfig.Click += new System.EventHandler(this.bt_ExportConfig_Click);
            // 
            // FConfigurePrj
            // 
            this.AcceptButton = this.bt_OK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.bt_ExportConfig);
            this.Controls.Add(this.Bt_cancel);
            this.Controls.Add(this.bt_OK);
            this.Controls.Add(this.bt_chgProjectName);
            this.Name = "FConfigurePrj";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_chgProjectName;
        private System.Windows.Forms.Button bt_OK;
        private System.Windows.Forms.Button Bt_cancel;
        private System.Windows.Forms.Button bt_ExportConfig;
    }
}