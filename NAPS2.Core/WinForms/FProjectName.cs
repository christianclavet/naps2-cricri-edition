using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NAPS2.WinForms
{
    public partial class FProjectName : FormBase
    {
        public FProjectName()
        {
            RestoreFormState = false;
            InitializeComponent();
            AcceptButton = btnAccept;
            CancelButton = btnCancel;
        }

        public void SetData(int imageCount, DateTime scannedDateTime)
        {
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnRecover_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public string getFileName()
        {
            return inputTextBox.Text;
        }

        public void setFileName(string text) 
        {
            inputTextBox.Text = text;
        }
    }
}
