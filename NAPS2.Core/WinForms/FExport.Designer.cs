namespace NAPS2.WinForms
{
    partial class FExport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FExport));
            this.tb_CSVExpression = new System.Windows.Forms.TextBox();
            this.btn_Expression = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_meta = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_FilenameCSV = new System.Windows.Forms.Label();
            this.tb_exportFilename = new System.Windows.Forms.TextBox();
            this.cb_CSVEnabler = new System.Windows.Forms.CheckBox();
            this.tb_ExportPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BTN_OK = new System.Windows.Forms.Button();
            this.BTN_Cancel = new System.Windows.Forms.Button();
            this.BTN_File = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.LBL_Exemple = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_CSVExpression
            // 
            resources.ApplyResources(this.tb_CSVExpression, "tb_CSVExpression");
            this.tb_CSVExpression.Name = "tb_CSVExpression";
            this.tb_CSVExpression.TextChanged += new System.EventHandler(this.tb_CSVExpression_TextChanged);
            // 
            // btn_Expression
            // 
            resources.ApplyResources(this.btn_Expression, "btn_Expression");
            this.btn_Expression.Name = "btn_Expression";
            this.btn_Expression.UseVisualStyleBackColor = true;
            this.btn_Expression.Click += new System.EventHandler(this.btn_Expression_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_meta);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lbl_FilenameCSV);
            this.groupBox1.Controls.Add(this.tb_exportFilename);
            this.groupBox1.Controls.Add(this.tb_CSVExpression);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // lbl_meta
            // 
            resources.ApplyResources(this.lbl_meta, "lbl_meta");
            this.lbl_meta.Name = "lbl_meta";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // lbl_FilenameCSV
            // 
            resources.ApplyResources(this.lbl_FilenameCSV, "lbl_FilenameCSV");
            this.lbl_FilenameCSV.Name = "lbl_FilenameCSV";
            // 
            // tb_exportFilename
            // 
            resources.ApplyResources(this.tb_exportFilename, "tb_exportFilename");
            this.tb_exportFilename.Name = "tb_exportFilename";
            this.tb_exportFilename.TextChanged += new System.EventHandler(this.tb_exportFilename_TextChanged);
            // 
            // cb_CSVEnabler
            // 
            resources.ApplyResources(this.cb_CSVEnabler, "cb_CSVEnabler");
            this.cb_CSVEnabler.Name = "cb_CSVEnabler";
            this.cb_CSVEnabler.UseVisualStyleBackColor = true;
            this.cb_CSVEnabler.CheckedChanged += new System.EventHandler(this.cb_CSVEnabler_CheckedChanged);
            // 
            // tb_ExportPath
            // 
            resources.ApplyResources(this.tb_ExportPath, "tb_ExportPath");
            this.tb_ExportPath.Name = "tb_ExportPath";
            this.tb_ExportPath.TextChanged += new System.EventHandler(this.tb_ExportPath_TextChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // BTN_OK
            // 
            resources.ApplyResources(this.BTN_OK, "BTN_OK");
            this.BTN_OK.Name = "BTN_OK";
            this.BTN_OK.UseVisualStyleBackColor = true;
            this.BTN_OK.Click += new System.EventHandler(this.BTN_Export_Click);
            // 
            // BTN_Cancel
            // 
            this.BTN_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.BTN_Cancel, "BTN_Cancel");
            this.BTN_Cancel.Name = "BTN_Cancel";
            this.BTN_Cancel.UseVisualStyleBackColor = true;
            this.BTN_Cancel.Click += new System.EventHandler(this.BTN_Cancel_Click);
            // 
            // BTN_File
            // 
            resources.ApplyResources(this.BTN_File, "BTN_File");
            this.BTN_File.Image = global::NAPS2.Icons.diskette;
            this.BTN_File.Name = "BTN_File";
            this.BTN_File.UseVisualStyleBackColor = true;
            this.BTN_File.Click += new System.EventHandler(this.BTN_File_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // LBL_Exemple
            // 
            resources.ApplyResources(this.LBL_Exemple, "LBL_Exemple");
            this.LBL_Exemple.Name = "LBL_Exemple";
            this.LBL_Exemple.UseMnemonic = false;
            // 
            // FExport
            // 
            this.AcceptButton = this.BTN_OK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.BTN_Cancel;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.LBL_Exemple);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BTN_File);
            this.Controls.Add(this.BTN_Cancel);
            this.Controls.Add(this.BTN_OK);
            this.Controls.Add(this.btn_Expression);
            this.Controls.Add(this.cb_CSVEnabler);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tb_ExportPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FExport";
            this.ShowInTaskbar = false;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_CSVExpression;
        private System.Windows.Forms.Button btn_Expression;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cb_CSVEnabler;
        private System.Windows.Forms.Label lbl_FilenameCSV;
        private System.Windows.Forms.TextBox tb_ExportPath;
        private System.Windows.Forms.TextBox tb_exportFilename;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTN_OK;
        private System.Windows.Forms.Button BTN_Cancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BTN_File;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LBL_Exemple;
        private System.Windows.Forms.Label lbl_meta;
        private System.Windows.Forms.Label label1;
    }
}