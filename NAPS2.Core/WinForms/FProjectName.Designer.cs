namespace NAPS2.WinForms
{
    partial class FProjectName
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FProjectName));
            this.lblPrompt_filename = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.GB_Project = new System.Windows.Forms.GroupBox();
            this.CB_ProjectType = new System.Windows.Forms.ComboBox();
            this.LBL_desc = new System.Windows.Forms.Label();
            this.Description = new System.Windows.Forms.TextBox();
            this.GB_Project.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPrompt_filename
            // 
            resources.ApplyResources(this.lblPrompt_filename, "lblPrompt_filename");
            this.lblPrompt_filename.Name = "lblPrompt_filename";
            // 
            // btnAccept
            // 
            resources.ApplyResources(this.btnAccept, "btnAccept");
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnRecover_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // inputTextBox
            // 
            this.inputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.inputTextBox, "inputTextBox");
            this.inputTextBox.Name = "inputTextBox";
            // 
            // GB_Project
            // 
            this.GB_Project.Controls.Add(this.CB_ProjectType);
            resources.ApplyResources(this.GB_Project, "GB_Project");
            this.GB_Project.Name = "GB_Project";
            this.GB_Project.TabStop = false;
            // 
            // CB_ProjectType
            // 
            this.CB_ProjectType.FormattingEnabled = true;
            resources.ApplyResources(this.CB_ProjectType, "CB_ProjectType");
            this.CB_ProjectType.Name = "CB_ProjectType";
            this.CB_ProjectType.SelectedIndexChanged += new System.EventHandler(this.CB_ProjectType_SelectedIndexChanged);
            // 
            // LBL_desc
            // 
            resources.ApplyResources(this.LBL_desc, "LBL_desc");
            this.LBL_desc.Name = "LBL_desc";
            // 
            // Description
            // 
            this.Description.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.Description, "Description");
            this.Description.Name = "Description";
            this.Description.TextChanged += new System.EventHandler(this.Description_TextChanged);
            // 
            // FProjectName
            // 
            this.AcceptButton = this.btnAccept;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.Description);
            this.Controls.Add(this.LBL_desc);
            this.Controls.Add(this.GB_Project);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblPrompt_filename);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FProjectName";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.GB_Project.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPrompt_filename;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.GroupBox GB_Project;
        private System.Windows.Forms.Label LBL_desc;
        private System.Windows.Forms.TextBox Description;
        private System.Windows.Forms.ComboBox CB_ProjectType;
    }
}