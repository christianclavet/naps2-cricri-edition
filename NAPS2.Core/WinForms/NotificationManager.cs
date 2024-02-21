﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NAPS2.Config;
using NAPS2.Operation;
using NAPS2.Update;
using NAPS2.Util;
using Org.BouncyCastle.Asn1.X509;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NAPS2.WinForms
{
    public class NotificationManager(AppConfigManager appConfigManager) : ISaveNotify
    {
        private const int PADDING_X = 25, PADDING_Y = 25;
        private const int SPACING_Y = 20;

        private readonly AppConfigManager appConfigManager = appConfigManager;

        private readonly List<NotifyWidgetBase> slots = [];
        private FormBase parentForm;
        private FormBase desktopForm;

        public FormBase DesktopForm
        {
            get => desktopForm;
            set
            {
                desktopForm = value;
               
                //desktopForm.Resize += desktopForm_Resize;
            }
        }

        public FormBase ParentForm
        {
            get => parentForm;
            set
            {
                parentForm = value;
                parentForm.Resize += ParentForm_Resize;
            }
        }

        public void PdfSaved(string path)
        {
            Show(new PdfSavedNotifyWidget(path));
        }

        public void ImagesSaved(int imageCount, string path)
        {
            if (imageCount == 1)
            {
                Show(new OneImageSavedNotifyWidget(path));
            }
            else if (imageCount > 1)
            {
                Show(new ImagesSavedNotifyWidget(imageCount, path));
            }
        }

        public void DonatePrompt()
        {
            Show(new DonatePromptNotifyWidget());
        }

        public void OperationProgress(IOperationProgress opModalProgress, IOperation op)
        {
            //OperationProgressNotifyWidget Display = new OperationProgressNotifyWidget(opModalProgress, op);
            Show(new OperationProgressNotifyWidget(opModalProgress, op));
            
        }

        public void UpdateAvailable(UpdateChecker updateChecker, UpdateInfo update)
        {
            Show(new UpdateAvailableNotifyWidget(updateChecker, update));
        }

        public void Rebuild()
        {
            var old = slots.ToList();
            slots.Clear();
            for (int i = 0; i < old.Count; i++)
            {
                if (old[i] != null)
                {
                    Show(old[i].Clone());
                }
            }
        }

        private void Show(NotifyWidgetBase n)
        {
            //This code might prevent the appearance of the widget. Temporary down for testing.
            /*if (appConfigManager.Config.DisableSaveNotifications && n is NotifyWidget)
            {
                return;
            }*/
            
            int slot = FillNextSlot(n);
            n.Location = GetPosition(n, slot);
            n.Resize += ParentForm_Resize;
            n.BringToFront();
            n.HideNotify += (sender, args) => ClearSlot(n);

            n.Invoke(new MethodInvoker(delegate
            {
                n.ShowNotify();
            }));
            
        }

        private void ParentForm_Resize(object sender, EventArgs e)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (slots[i] != null)
                {
                    slots[i].Location = GetPosition(slots[i], i);
                }
            }
        }

        private void ClearSlot(NotifyWidgetBase n)
        {
            var index = slots.IndexOf(n);
            if (index != -1)
            {
                parentForm.Controls.Remove(n);
                slots[index] = null;
            }
        }

        private int FillNextSlot(NotifyWidgetBase n)
        {
            var index = slots.IndexOf(null);
            if (index == -1)
            {
                index = slots.Count;
                slots.Add(n);
            }
            else
            {
                slots[index] = n;
            }
            FDesktop.GetInstance().Controls.Add(n);
            //parentForm.Controls.Add(n);
            return index;
        }

        private Point GetPosition(NotifyWidgetBase n, int slot)
        {
            return new Point(parentForm.ClientSize.Width - n.Width - PADDING_X,
                parentForm.ClientSize.Height - n.Height - PADDING_Y - (n.Height + SPACING_Y) * slot);
        }
    }
}
