using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NAPS2.WinForms
{
    public class TiffViewer : UserControl
    {
        private readonly Container components = null;

        private Image image;
        private Image image2;
        private PictureBox pbox;
        private PictureBox pbox2;
        private double xzoom;

        public TiffViewer()
        {
            InitializeComponent();
        }

        public Image Image
        {
            set
            {
                if (value != null)
                {
                    image = value;
                    Zoom = 100;
                }
                else
                {
                    ClearImage();
                    image = null;
                }
            }
        }

        public Image Image2
        {
            set
            {
                if (value != null)
                {
                    image2 = value;
                    Zoom = 100;
                }
                else
                {
                    ClearImage();
                    image2 = null;
                }
            }
        }

        public int ImageWidth => image?.Width ?? 0;

        public int ImageHeight => image?.Height ?? 0;

        public double Zoom
        {
            set
            {
                if (image != null)
                {
                    double maxZoom = Math.Sqrt(1e8 / (image.Width * (double) image.Height)) * 100;
                    xzoom = Math.Max(Math.Min(value, maxZoom), 10);
                    double displayWidth = (image.Width) * (xzoom / 100);
                    double displayHeight = image.Height * (xzoom / 100);
                    if (image.HorizontalResolution > 0 && image.VerticalResolution > 0)
                    {
                        displayHeight *= image.HorizontalResolution / (double)image.VerticalResolution;
                    }
                    pbox.Image = image;
                    if (image2 != null)
                    {
                        pbox2.Image = image2;
                        pbox2.Hide(); // Until it's ready to be used.
                        pbox2.BorderStyle = BorderStyle.FixedSingle;
                        pbox2.Width = (int)displayWidth;
                        pbox.Height = (int)displayHeight;
                    }
                        

                    pbox.BorderStyle = BorderStyle.FixedSingle;
                    pbox.Width = (int)displayWidth;
                    pbox.Height = (int)displayHeight;
                    if (ZoomChanged != null)
                    {
                        pbox.Cursor = HorizontalScroll.Visible || VerticalScroll.Visible ? Cursors.Hand : Cursors.Default;
                        ZoomChanged.Invoke(this, new EventArgs());
                        //pbox2.Anchor = pbox.Anchor + pbox.Width + 5;
                        pbox2.Left = pbox.Right + 5; pbox2.Hide();
                        pbox2.Size = pbox.Size;
                    }
                }
            }
            get => xzoom;
        }

        public event EventHandler<EventArgs> ZoomChanged;

        private void ClearImage()
        {
            pbox.Image = Icons.hourglass_grey;
            pbox.BorderStyle = BorderStyle.None;
            pbox.Width = 32;
            pbox.Height = 32;

            pbox2.Image = Icons.hourglass_grey;
            pbox2.BorderStyle = BorderStyle.None;
            pbox2.Width = 32;
            pbox2.Height = 32;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (ModifierKeys.HasFlag(Keys.Control))
            {
                StepZoom(e.Delta / (double)SystemInformation.MouseWheelScrollDelta);
            }
            else
            {
                base.OnMouseWheel(e);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyCode)
            {
                case Keys.OemMinus:
                    if (e.Control)
                    {
                        StepZoom(-1);
                    }
                    break;
                case Keys.Oemplus:
                    if (e.Control)
                    {
                        StepZoom(1);
                    }
                    break;
            }
        }

        public void StepZoom(double steps)
        {
            Zoom = Math.Round(Zoom * Math.Pow(1.2, steps));
        }

        private Point mousePos;

        private void pbox_MouseDown(object sender, MouseEventArgs e)
        {
            mousePos = e.Location;
        }

        private void pbox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                AutoScrollPosition = new Point(-AutoScrollPosition.X + mousePos.X - e.X, -AutoScrollPosition.Y + mousePos.Y - e.Y);
            }
        }

        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TiffViewer));
            this.pbox = new System.Windows.Forms.PictureBox();
            this.pbox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pbox
            // 
            this.pbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.pbox, "pbox");
            this.pbox.Name = "pbox";
            this.pbox.TabStop = false;
            this.pbox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbox_MouseDown);
            this.pbox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbox_MouseMove);
            // 
            // pbox2
            // 
            this.pbox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.pbox2, "pbox2");
            this.pbox2.Name = "pbox2";
            this.pbox2.TabStop = false;
            // 
            // TiffViewer
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pbox);
            this.Controls.Add(this.pbox2);
            this.Name = "TiffViewer";
            ((System.ComponentModel.ISupportInitialize)(this.pbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox2)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
    }
}
