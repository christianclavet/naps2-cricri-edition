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

namespace NAPS2.WinForms
{
    public partial class FExport : FormBase
    {
        
        public FExport()
        {
            InitializeComponent();
            
        }

        public string projectName { get; set; }

        public void setName(string name) 
        {
            projectName = name;
            tb_exportFilename.Text = name+".csv";
        }

        private void BTN_File_Click(object sender, EventArgs e)
        {

        }

        private void btn_Expression_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<FPlaceholders>();
            form.FileName = tb_CSVExpression.Text;
            if (form.ShowDialog() == DialogResult.OK)
            {
                tb_CSVExpression.Text = form.FileName;
            }
        }

        private void tb_ExportPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void cb_CSVEnabler_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = cb_CSVEnabler.Checked;
        }

        private void tb_CSVExpression_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_exportFilename_TextChanged(object sender, EventArgs e)
        {

        }

        private void BTN_Cancel_Click(object sender, EventArgs e)
        {

        }

        private void BTN_Export_Click(object sender, EventArgs e)
        {

        }
    }
}
