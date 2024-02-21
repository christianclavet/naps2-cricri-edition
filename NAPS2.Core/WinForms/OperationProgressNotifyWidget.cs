using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NAPS2.Operation;

namespace NAPS2.WinForms
{
    public partial class OperationProgressNotifyWidget : NotifyWidgetBase
    {
        private readonly IOperationProgress operationProgress;
        private readonly IOperation op;

        public OperationProgressNotifyWidget(IOperationProgress operationProgress, IOperation op)
        {
            InitializeComponent();

            this.operationProgress = operationProgress;
            this.op = op;

            cancelToolStripMenuItem.Visible = op.AllowCancel;
            op.StatusChanged += Op_StatusChanged;
            op.Finished += Op_Finished;

            this.ForeColor = FDesktop.getCurrentModeFore();
            this.BackColor = FDesktop.getCurrentModeBack();
        }

        public override void ShowNotify() => DisplayProgress();

        public override NotifyWidgetBase Clone() => new OperationProgressNotifyWidget(operationProgress, op);

        private void DisplayProgress()
        {
            //Should create a handle for the window if not present (another tread)
            if (!this.IsHandleCreated)
            {
                this.CreateHandle();
            }

            var lblNumberRight = lblNumber.Right;
            lblTitle.Invoke(new MethodInvoker(delegate
            {
                WinFormsOperationProgress.RenderStatus(op, lblTitle, lblNumber, progressBar);
            }));

            if (op.Status?.IndeterminateProgress != true)
            {
                // Don't display the number if the progress bar is precise
                // Otherwise, the widget will be too cluttered
                // The number is only shown for OcrOperation at the moment
                lblNumber.Invoke(new MethodInvoker(delegate
                {
                    lblNumber.Text = "";
                }));
            }
            lblNumber.Invoke(new MethodInvoker(delegate
            {
                lblNumber.Left = lblNumberRight - lblNumber.Width;
                Width = Math.Max(Width, lblTitle.Width + lblNumber.Width + 22);
                Height = Math.Max(Height, lblTitle.Height + 35);
            }));
        }

        private void DoHideNotify()
        {
            op.StatusChanged -= Op_StatusChanged;
            op.Finished -= Op_Finished;
            InvokeHideNotify();
        }

        private void Op_StatusChanged(object sender, EventArgs e)
        {
            //SafeInvoke(DisplayProgress);
            Invoke(DisplayProgress);
        }

        private void Op_Finished(object sender, EventArgs e)
        {
            DoHideNotify();
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            op.Cancel();
            cancelToolStripMenuItem.Enabled = false;
        }

        private void OperationProgressNotifyWidget_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DoHideNotify();
                operationProgress.ShowModalProgress(op);
            }
        }
    }
}
