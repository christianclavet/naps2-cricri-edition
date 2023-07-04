using System;
using System.Collections.Generic;
using System.Linq;

namespace NAPS2.WinForms
{
    partial class FDesktop
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FDesktop));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnZoomMouseCatcher = new System.Windows.Forms.Button();
            this.thumbnailList1 = new NAPS2.WinForms.ThumbnailList();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxView = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tiffViewerCtl1 = new NAPS2.WinForms.TiffViewerCtl();
            this.tStrip = new System.Windows.Forms.ToolStrip();
            this.FileDm = new System.Windows.Forms.ToolStripDropDownButton();
            this.TS_PrjConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.tsPrjNew = new System.Windows.Forms.ToolStripMenuItem();
            this.TS_RenBatch = new System.Windows.Forms.ToolStripMenuItem();
            this.loadProjectTool_TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.closeCurrentProject = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.tsdSavePDF = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSavePDFAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSavePDFSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.tsPDFSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsdSaveImages = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSaveImagesAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSaveImagesSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.tsImageSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsdEmailPDF = new System.Windows.Forms.ToolStripMenuItem();
            this.tsEmailPDFAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsEmailPDFSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tsEmailSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsPdfSettings2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsImport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.tsTools = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsOCR = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.tsLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.tsAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.TS_View = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsShowHideView2 = new System.Windows.Forms.ToolStripMenuItem();
            this.TSI_ToggleDarkMode1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.tsCombo_Profiles = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.tsNewProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsProfiles = new System.Windows.Forms.ToolStripMenuItem();
            this.tsScan = new System.Windows.Forms.ToolStripSplitButton();
            this.tsBatchScan = new System.Windows.Forms.ToolStripMenuItem();
            this.tsInsert = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsdDocument = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsiDocumentAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiDocumentRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.tsdImage = new System.Windows.Forms.ToolStripDropDownButton();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBarCodeCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.tsCrop = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBrightnessContrast = new System.Windows.Forms.ToolStripMenuItem();
            this.tsHueSaturation = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBlackWhite = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSharpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsReset = new System.Windows.Forms.ToolStripMenuItem();
            this.tsdRotate = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsRotateLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.tsRotateRight = new System.Windows.Forms.ToolStripMenuItem();
            this.tsFlip = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDeskew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCustomRotation = new System.Windows.Forms.ToolStripMenuItem();
            this.tsdReorder = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsInterleave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDeinterleave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.tsAltInterleave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAltDeinterleave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsReverse = new System.Windows.Forms.ToolStripMenuItem();
            this.tsReverseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsReverseSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.tt_FDesktop = new System.Windows.Forms.ToolTip(this.components);
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.tStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            resources.ApplyResources(this.toolStripContainer1.ContentPanel, "toolStripContainer1.ContentPanel");
            resources.ApplyResources(this.toolStripContainer1, "toolStripContainer1");
            this.toolStripContainer1.Name = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.tStrip);
            // 
            // statusStrip1
            // 
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusText});
            this.statusStrip1.Name = "statusStrip1";
            // 
            // StatusText
            // 
            this.StatusText.Name = "StatusText";
            resources.ApplyResources(this.StatusText, "StatusText");
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.splitContainer1.Panel1.Controls.Add(this.btnZoomOut);
            this.splitContainer1.Panel1.Controls.Add(this.btnZoomIn);
            this.splitContainer1.Panel1.Controls.Add(this.btnZoomMouseCatcher);
            this.splitContainer1.Panel1.Controls.Add(this.thumbnailList1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.splitContainer1.Panel2.Controls.Add(this.tiffViewerCtl1);
            this.splitContainer1.SplitterMoving += new System.Windows.Forms.SplitterCancelEventHandler(this.splitContainer1_SplitterMoving);
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // btnZoomOut
            // 
            resources.ApplyResources(this.btnZoomOut, "btnZoomOut");
            this.btnZoomOut.BackColor = System.Drawing.Color.White;
            this.btnZoomOut.Image = global::NAPS2.Icons.zoom_out;
            this.btnZoomOut.Name = "btnZoomOut";
            this.tt_FDesktop.SetToolTip(this.btnZoomOut, resources.GetString("btnZoomOut.ToolTip"));
            this.btnZoomOut.UseVisualStyleBackColor = false;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnZoomIn
            // 
            resources.ApplyResources(this.btnZoomIn, "btnZoomIn");
            this.btnZoomIn.BackColor = System.Drawing.Color.White;
            this.btnZoomIn.Image = global::NAPS2.Icons.zoom_in;
            this.btnZoomIn.Name = "btnZoomIn";
            this.tt_FDesktop.SetToolTip(this.btnZoomIn, resources.GetString("btnZoomIn.ToolTip"));
            this.btnZoomIn.UseVisualStyleBackColor = false;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomMouseCatcher
            // 
            this.btnZoomMouseCatcher.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.btnZoomMouseCatcher, "btnZoomMouseCatcher");
            this.btnZoomMouseCatcher.Name = "btnZoomMouseCatcher";
            this.btnZoomMouseCatcher.UseVisualStyleBackColor = false;
            // 
            // thumbnailList1
            // 
            this.thumbnailList1.AllowDrop = true;
            this.thumbnailList1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thumbnailList1.ContextMenuStrip = this.contextMenuStrip;
            resources.ApplyResources(this.thumbnailList1, "thumbnailList1");
            this.thumbnailList1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("thumbnailList1.Groups"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("thumbnailList1.Groups1"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("thumbnailList1.Groups2"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("thumbnailList1.Groups3")))});
            this.thumbnailList1.HideSelection = false;
            this.thumbnailList1.Name = "thumbnailList1";
            this.thumbnailList1.ShowItemToolTips = true;
            this.thumbnailList1.ThumbnailRenderer = null;
            this.thumbnailList1.ThumbnailSize = new System.Drawing.Size(128, 128);
            this.thumbnailList1.UseCompatibleStateImageBehavior = false;
            this.thumbnailList1.ItemActivate += new System.EventHandler(this.thumbnailList1_ItemActivate);
            this.thumbnailList1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.thumbnailList1_ItemDrag);
            this.thumbnailList1.SelectedIndexChanged += new System.EventHandler(this.thumbnailList1_SelectedIndexChanged);
            this.thumbnailList1.DragDrop += new System.Windows.Forms.DragEventHandler(this.thumbnailList1_DragDrop);
            this.thumbnailList1.DragEnter += new System.Windows.Forms.DragEventHandler(this.thumbnailList1_DragEnter);
            this.thumbnailList1.DragOver += new System.Windows.Forms.DragEventHandler(this.thumbnailList1_DragOver);
            this.thumbnailList1.DragLeave += new System.EventHandler(this.thumbnailList1_DragLeave);
            this.thumbnailList1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thumbnailList1_KeyDown);
            this.thumbnailList1.MouseLeave += new System.EventHandler(this.thumbnailList1_MouseLeave);
            this.thumbnailList1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.thumbnailList1_MouseMove);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxView,
            this.ctxSeparator1,
            this.ctxSelectAll,
            this.ctxCopy,
            this.ctxPaste,
            this.ctxSeparator2,
            this.ctxDelete});
            this.contextMenuStrip.Name = "contextMenuStrip";
            resources.ApplyResources(this.contextMenuStrip, "contextMenuStrip");
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // ctxView
            // 
            resources.ApplyResources(this.ctxView, "ctxView");
            this.ctxView.Name = "ctxView";
            this.ctxView.Click += new System.EventHandler(this.ctxView_Click);
            // 
            // ctxSeparator1
            // 
            this.ctxSeparator1.Name = "ctxSeparator1";
            resources.ApplyResources(this.ctxSeparator1, "ctxSeparator1");
            // 
            // ctxSelectAll
            // 
            this.ctxSelectAll.Name = "ctxSelectAll";
            resources.ApplyResources(this.ctxSelectAll, "ctxSelectAll");
            this.ctxSelectAll.Click += new System.EventHandler(this.ctxSelectAll_Click);
            // 
            // ctxCopy
            // 
            this.ctxCopy.Name = "ctxCopy";
            resources.ApplyResources(this.ctxCopy, "ctxCopy");
            this.ctxCopy.Click += new System.EventHandler(this.ctxCopy_Click);
            // 
            // ctxPaste
            // 
            this.ctxPaste.Name = "ctxPaste";
            resources.ApplyResources(this.ctxPaste, "ctxPaste");
            this.ctxPaste.Click += new System.EventHandler(this.ctxPaste_Click);
            // 
            // ctxSeparator2
            // 
            this.ctxSeparator2.Name = "ctxSeparator2";
            resources.ApplyResources(this.ctxSeparator2, "ctxSeparator2");
            // 
            // ctxDelete
            // 
            this.ctxDelete.Name = "ctxDelete";
            resources.ApplyResources(this.ctxDelete, "ctxDelete");
            this.ctxDelete.Click += new System.EventHandler(this.ctxDelete_Click);
            // 
            // tiffViewerCtl1
            // 
            resources.ApplyResources(this.tiffViewerCtl1, "tiffViewerCtl1");
            this.tiffViewerCtl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tiffViewerCtl1.Image = null;
            this.tiffViewerCtl1.Name = "tiffViewerCtl1";
            // 
            // tStrip
            // 
            this.tStrip.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.tStrip, "tStrip");
            this.tStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileDm,
            this.TS_View,
            this.toolStripSeparator18,
            this.tsCombo_Profiles,
            this.tsScan,
            this.tsInsert,
            this.toolStripSeparator4,
            this.tsdDocument,
            this.tsdImage,
            this.tsdRotate,
            this.tsdReorder,
            this.toolStripSeparator2,
            this.tsDelete,
            this.toolStripSeparator3});
            this.tStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tStrip.Name = "tStrip";
            this.tStrip.TabStop = true;
            this.tStrip.DockChanged += new System.EventHandler(this.tStrip_DockChanged);
            // 
            // FileDm
            // 
            this.FileDm.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.FileDm.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TS_PrjConfig,
            this.tsPrjNew,
            this.TS_RenBatch,
            this.loadProjectTool_TSMI,
            this.closeCurrentProject,
            this.toolStripSeparator15,
            this.tsdSavePDF,
            this.tsdSaveImages,
            this.tsdEmailPDF,
            this.toolStripSeparator5,
            this.tsImport,
            this.tsExport,
            this.toolStripSeparator16,
            this.tsTools,
            this.toolStripSeparator17,
            this.tsAbout});
            resources.ApplyResources(this.FileDm, "FileDm");
            this.FileDm.Image = global::NAPS2.Icons.folder_picture;
            this.FileDm.Name = "FileDm";
            // 
            // TS_PrjConfig
            // 
            this.TS_PrjConfig.Image = global::NAPS2.Icons.toolbox;
            this.TS_PrjConfig.Name = "TS_PrjConfig";
            resources.ApplyResources(this.TS_PrjConfig, "TS_PrjConfig");
            this.TS_PrjConfig.Click += new System.EventHandler(this.tsPrjConfig_Click);
            // 
            // tsPrjNew
            // 
            this.tsPrjNew.Image = global::NAPS2.Icons.picture_edit;
            resources.ApplyResources(this.tsPrjNew, "tsPrjNew");
            this.tsPrjNew.Name = "tsPrjNew";
            this.tsPrjNew.Click += new System.EventHandler(this.tsPrjNew_Click);
            // 
            // TS_RenBatch
            // 
            this.TS_RenBatch.Image = global::NAPS2.Icons.diskette;
            this.TS_RenBatch.Name = "TS_RenBatch";
            resources.ApplyResources(this.TS_RenBatch, "TS_RenBatch");
            this.TS_RenBatch.Click += new System.EventHandler(this.TS_SavePrj_Click);
            // 
            // loadProjectTool_TSMI
            // 
            this.loadProjectTool_TSMI.Image = global::NAPS2.Icons.folder_picture;
            this.loadProjectTool_TSMI.Name = "loadProjectTool_TSMI";
            resources.ApplyResources(this.loadProjectTool_TSMI, "loadProjectTool_TSMI");
            this.loadProjectTool_TSMI.Click += new System.EventHandler(this.loadProjectTool_TSMI_Click_1);
            // 
            // closeCurrentProject
            // 
            resources.ApplyResources(this.closeCurrentProject, "closeCurrentProject");
            this.closeCurrentProject.Name = "closeCurrentProject";
            this.closeCurrentProject.Click += new System.EventHandler(this.closeCurrentProjectToolStripMenuItem_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            resources.ApplyResources(this.toolStripSeparator15, "toolStripSeparator15");
            // 
            // tsdSavePDF
            // 
            this.tsdSavePDF.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSavePDFAll,
            this.tsSavePDFSelected,
            this.toolStripSeparator10,
            this.tsPDFSettings});
            this.tsdSavePDF.Image = global::NAPS2.Icons.file_extension_pdf;
            resources.ApplyResources(this.tsdSavePDF, "tsdSavePDF");
            this.tsdSavePDF.Margin = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.tsdSavePDF.Name = "tsdSavePDF";
            this.tsdSavePDF.Click += new System.EventHandler(this.tsdSavePDF_Click);
            // 
            // tsSavePDFAll
            // 
            this.tsSavePDFAll.Name = "tsSavePDFAll";
            resources.ApplyResources(this.tsSavePDFAll, "tsSavePDFAll");
            this.tsSavePDFAll.Click += new System.EventHandler(this.tsSavePDFAll_Click);
            // 
            // tsSavePDFSelected
            // 
            this.tsSavePDFSelected.Name = "tsSavePDFSelected";
            resources.ApplyResources(this.tsSavePDFSelected, "tsSavePDFSelected");
            this.tsSavePDFSelected.Click += new System.EventHandler(this.tsSavePDFSelected_Click_1);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            resources.ApplyResources(this.toolStripSeparator10, "toolStripSeparator10");
            // 
            // tsPDFSettings
            // 
            this.tsPDFSettings.Name = "tsPDFSettings";
            resources.ApplyResources(this.tsPDFSettings, "tsPDFSettings");
            this.tsPDFSettings.Click += new System.EventHandler(this.tsPDFSettings_Click_1);
            // 
            // tsdSaveImages
            // 
            this.tsdSaveImages.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSaveImagesAll,
            this.tsSaveImagesSelected,
            this.toolStripSeparator11,
            this.tsImageSettings});
            this.tsdSaveImages.Image = global::NAPS2.Icons.pictures;
            resources.ApplyResources(this.tsdSaveImages, "tsdSaveImages");
            this.tsdSaveImages.Margin = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.tsdSaveImages.Name = "tsdSaveImages";
            // 
            // tsSaveImagesAll
            // 
            this.tsSaveImagesAll.Name = "tsSaveImagesAll";
            resources.ApplyResources(this.tsSaveImagesAll, "tsSaveImagesAll");
            this.tsSaveImagesAll.Click += new System.EventHandler(this.tsSaveImagesAll_Click_1);
            // 
            // tsSaveImagesSelected
            // 
            this.tsSaveImagesSelected.Name = "tsSaveImagesSelected";
            resources.ApplyResources(this.tsSaveImagesSelected, "tsSaveImagesSelected");
            this.tsSaveImagesSelected.Click += new System.EventHandler(this.tsSaveImagesSelected_Click_1);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            resources.ApplyResources(this.toolStripSeparator11, "toolStripSeparator11");
            // 
            // tsImageSettings
            // 
            this.tsImageSettings.Name = "tsImageSettings";
            resources.ApplyResources(this.tsImageSettings, "tsImageSettings");
            this.tsImageSettings.Click += new System.EventHandler(this.tsImageSettings_Click_1);
            // 
            // tsdEmailPDF
            // 
            this.tsdEmailPDF.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsEmailPDFAll,
            this.tsEmailPDFSelected,
            this.toolStripSeparator9,
            this.tsEmailSettings,
            this.tsPdfSettings2});
            this.tsdEmailPDF.Image = global::NAPS2.Icons.email_attach;
            resources.ApplyResources(this.tsdEmailPDF, "tsdEmailPDF");
            this.tsdEmailPDF.Margin = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.tsdEmailPDF.Name = "tsdEmailPDF";
            // 
            // tsEmailPDFAll
            // 
            this.tsEmailPDFAll.Name = "tsEmailPDFAll";
            resources.ApplyResources(this.tsEmailPDFAll, "tsEmailPDFAll");
            // 
            // tsEmailPDFSelected
            // 
            this.tsEmailPDFSelected.Name = "tsEmailPDFSelected";
            resources.ApplyResources(this.tsEmailPDFSelected, "tsEmailPDFSelected");
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            resources.ApplyResources(this.toolStripSeparator9, "toolStripSeparator9");
            // 
            // tsEmailSettings
            // 
            this.tsEmailSettings.Name = "tsEmailSettings";
            resources.ApplyResources(this.tsEmailSettings, "tsEmailSettings");
            // 
            // tsPdfSettings2
            // 
            this.tsPdfSettings2.Name = "tsPdfSettings2";
            resources.ApplyResources(this.tsPdfSettings2, "tsPdfSettings2");
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // tsImport
            // 
            this.tsImport.Image = global::NAPS2.Icons.folder_picture;
            resources.ApplyResources(this.tsImport, "tsImport");
            this.tsImport.Name = "tsImport";
            this.tsImport.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.tsImport.Click += new System.EventHandler(this.tsImport_Click_1);
            // 
            // tsExport
            // 
            this.tsExport.Image = global::NAPS2.Icons.export;
            this.tsExport.Name = "tsExport";
            resources.ApplyResources(this.tsExport, "tsExport");
            this.tsExport.Click += new System.EventHandler(this.tsExport_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            resources.ApplyResources(this.toolStripSeparator16, "toolStripSeparator16");
            // 
            // tsTools
            // 
            this.tsTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator8,
            this.tsOCR,
            this.toolStripSeparator14,
            this.tsLanguage});
            this.tsTools.Image = global::NAPS2.Icons.toolbox;
            resources.ApplyResources(this.tsTools, "tsTools");
            this.tsTools.Name = "tsTools";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            resources.ApplyResources(this.toolStripSeparator8, "toolStripSeparator8");
            // 
            // tsOCR
            // 
            this.tsOCR.Image = global::NAPS2.Icons.text;
            this.tsOCR.Name = "tsOCR";
            resources.ApplyResources(this.tsOCR, "tsOCR");
            this.tsOCR.Click += new System.EventHandler(this.tsOCR_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            resources.ApplyResources(this.toolStripSeparator14, "toolStripSeparator14");
            // 
            // tsLanguage
            // 
            this.tsLanguage.Image = global::NAPS2.Icons.world;
            this.tsLanguage.Name = "tsLanguage";
            resources.ApplyResources(this.tsLanguage, "tsLanguage");
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            resources.ApplyResources(this.toolStripSeparator17, "toolStripSeparator17");
            // 
            // tsAbout
            // 
            this.tsAbout.Image = global::NAPS2.Icons.information;
            this.tsAbout.Name = "tsAbout";
            resources.ApplyResources(this.tsAbout, "tsAbout");
            this.tsAbout.Click += new System.EventHandler(this.tsAbout_Click);
            // 
            // TS_View
            // 
            this.TS_View.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsShowHideView2,
            this.TSI_ToggleDarkMode1});
            resources.ApplyResources(this.TS_View, "TS_View");
            this.TS_View.Image = global::NAPS2.Icons.pictures;
            this.TS_View.Name = "TS_View";
            // 
            // tsShowHideView2
            // 
            this.tsShowHideView2.Image = global::NAPS2.Icons.view_fullscreen_view1;
            resources.ApplyResources(this.tsShowHideView2, "tsShowHideView2");
            this.tsShowHideView2.Name = "tsShowHideView2";
            this.tsShowHideView2.Click += new System.EventHandler(this.tsShowHideView_Click);
            // 
            // TSI_ToggleDarkMode1
            // 
            this.TSI_ToggleDarkMode1.Image = global::NAPS2.Icons.DarkMode;
            this.TSI_ToggleDarkMode1.Name = "TSI_ToggleDarkMode1";
            resources.ApplyResources(this.TSI_ToggleDarkMode1, "TSI_ToggleDarkMode1");
            this.TSI_ToggleDarkMode1.Click += new System.EventHandler(this.TSI_ToggleDarkMode_Click);
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            resources.ApplyResources(this.toolStripSeparator18, "toolStripSeparator18");
            // 
            // tsCombo_Profiles
            // 
            this.tsCombo_Profiles.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator13,
            this.tsNewProfile,
            this.tsProfiles});
            resources.ApplyResources(this.tsCombo_Profiles, "tsCombo_Profiles");
            this.tsCombo_Profiles.Image = global::NAPS2.Icons.accept;
            this.tsCombo_Profiles.Name = "tsCombo_Profiles";
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            resources.ApplyResources(this.toolStripSeparator13, "toolStripSeparator13");
            // 
            // tsNewProfile
            // 
            this.tsNewProfile.Image = global::NAPS2.Icons.add;
            this.tsNewProfile.Name = "tsNewProfile";
            resources.ApplyResources(this.tsNewProfile, "tsNewProfile");
            this.tsNewProfile.Click += new System.EventHandler(this.tsNewProfile_Click_1);
            // 
            // tsProfiles
            // 
            this.tsProfiles.Image = global::NAPS2.Icons.scanner_48;
            this.tsProfiles.Name = "tsProfiles";
            resources.ApplyResources(this.tsProfiles, "tsProfiles");
            this.tsProfiles.Click += new System.EventHandler(this.tsProfiles_Click);
            // 
            // tsScan
            // 
            this.tsScan.AutoToolTip = false;
            this.tsScan.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBatchScan});
            resources.ApplyResources(this.tsScan, "tsScan");
            this.tsScan.Image = global::NAPS2.Icons.control_play_blue;
            this.tsScan.Margin = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.tsScan.Name = "tsScan";
            this.tsScan.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.tsScan.ButtonClick += new System.EventHandler(this.tsScan_ButtonClick);
            // 
            // tsBatchScan
            // 
            this.tsBatchScan.Image = global::NAPS2.Icons.application_cascade;
            resources.ApplyResources(this.tsBatchScan, "tsBatchScan");
            this.tsBatchScan.Name = "tsBatchScan";
            this.tsBatchScan.Click += new System.EventHandler(this.tsBatchScan_Click);
            // 
            // tsInsert
            // 
            resources.ApplyResources(this.tsInsert, "tsInsert");
            this.tsInsert.Name = "tsInsert";
            this.tsInsert.Click += new System.EventHandler(this.tsInsert_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // tsdDocument
            // 
            this.tsdDocument.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiDocumentAdd,
            this.tsiDocumentRemove});
            this.tsdDocument.Image = global::NAPS2.Icons.folder_directory_files_icon;
            resources.ApplyResources(this.tsdDocument, "tsdDocument");
            this.tsdDocument.Name = "tsdDocument";
            // 
            // tsiDocumentAdd
            // 
            this.tsiDocumentAdd.Image = global::NAPS2.Icons.folder_directory_files_icon_add;
            this.tsiDocumentAdd.Name = "tsiDocumentAdd";
            resources.ApplyResources(this.tsiDocumentAdd, "tsiDocumentAdd");
            this.tsiDocumentAdd.Click += new System.EventHandler(this.tsiDocumentAdd_Click);
            // 
            // tsiDocumentRemove
            // 
            this.tsiDocumentRemove.Image = global::NAPS2.Icons.folder_directory_files_icon_remove;
            this.tsiDocumentRemove.Name = "tsiDocumentRemove";
            resources.ApplyResources(this.tsiDocumentRemove, "tsiDocumentRemove");
            this.tsiDocumentRemove.Click += new System.EventHandler(this.tsiDocumentRemove_Click);
            // 
            // tsdImage
            // 
            this.tsdImage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printToolStripMenuItem,
            this.tsView,
            this.toolStripSeparator6,
            this.tsBarCodeCheck,
            this.toolStripSeparator19,
            this.tsCrop,
            this.tsBrightnessContrast,
            this.tsHueSaturation,
            this.tsBlackWhite,
            this.tsSharpen,
            this.toolStripSeparator7,
            this.tsReset});
            resources.ApplyResources(this.tsdImage, "tsdImage");
            this.tsdImage.Image = global::NAPS2.Icons.picture_edit;
            this.tsdImage.Name = "tsdImage";
            this.tsdImage.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = global::NAPS2.Icons.printer;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            resources.ApplyResources(this.printToolStripMenuItem, "printToolStripMenuItem");
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // tsView
            // 
            this.tsView.Image = global::NAPS2.Icons.image_edit1;
            this.tsView.Name = "tsView";
            resources.ApplyResources(this.tsView, "tsView");
            this.tsView.Click += new System.EventHandler(this.tsView_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // tsBarCodeCheck
            // 
            this.tsBarCodeCheck.Image = global::NAPS2.Icons.barcodePetit;
            this.tsBarCodeCheck.Name = "tsBarCodeCheck";
            resources.ApplyResources(this.tsBarCodeCheck, "tsBarCodeCheck");
            this.tsBarCodeCheck.Click += new System.EventHandler(this.tsBarCodeCheck_Click);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            resources.ApplyResources(this.toolStripSeparator19, "toolStripSeparator19");
            // 
            // tsCrop
            // 
            this.tsCrop.Image = global::NAPS2.Icons.transform_crop1;
            resources.ApplyResources(this.tsCrop, "tsCrop");
            this.tsCrop.Name = "tsCrop";
            this.tsCrop.Click += new System.EventHandler(this.tsCrop_Click);
            // 
            // tsBrightnessContrast
            // 
            this.tsBrightnessContrast.Image = global::NAPS2.Icons.color_adjustment;
            resources.ApplyResources(this.tsBrightnessContrast, "tsBrightnessContrast");
            this.tsBrightnessContrast.Name = "tsBrightnessContrast";
            this.tsBrightnessContrast.Click += new System.EventHandler(this.tsBrightnessContrast_Click);
            // 
            // tsHueSaturation
            // 
            this.tsHueSaturation.Image = global::NAPS2.Icons.color_management1;
            resources.ApplyResources(this.tsHueSaturation, "tsHueSaturation");
            this.tsHueSaturation.Name = "tsHueSaturation";
            this.tsHueSaturation.Click += new System.EventHandler(this.tsHueSaturation_Click);
            // 
            // tsBlackWhite
            // 
            this.tsBlackWhite.Image = global::NAPS2.Icons.contrast_high1;
            resources.ApplyResources(this.tsBlackWhite, "tsBlackWhite");
            this.tsBlackWhite.Name = "tsBlackWhite";
            this.tsBlackWhite.Click += new System.EventHandler(this.tsBlackWhite_Click);
            // 
            // tsSharpen
            // 
            this.tsSharpen.Image = global::NAPS2.Icons.sharpen1;
            resources.ApplyResources(this.tsSharpen, "tsSharpen");
            this.tsSharpen.Name = "tsSharpen";
            this.tsSharpen.Click += new System.EventHandler(this.tsSharpen_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            // 
            // tsReset
            // 
            this.tsReset.Image = global::NAPS2.Icons.undo;
            this.tsReset.Name = "tsReset";
            resources.ApplyResources(this.tsReset, "tsReset");
            this.tsReset.Click += new System.EventHandler(this.tsReset_Click);
            // 
            // tsdRotate
            // 
            this.tsdRotate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsRotateLeft,
            this.tsRotateRight,
            this.tsFlip,
            this.tsDeskew,
            this.tsCustomRotation});
            resources.ApplyResources(this.tsdRotate, "tsdRotate");
            this.tsdRotate.Image = global::NAPS2.Icons.arrow_rotate_anticlockwise;
            this.tsdRotate.Name = "tsdRotate";
            this.tsdRotate.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            // 
            // tsRotateLeft
            // 
            this.tsRotateLeft.Image = global::NAPS2.Icons.arrow_rotate_anticlockwise;
            resources.ApplyResources(this.tsRotateLeft, "tsRotateLeft");
            this.tsRotateLeft.Name = "tsRotateLeft";
            this.tsRotateLeft.Click += new System.EventHandler(this.tsRotateLeft_Click);
            // 
            // tsRotateRight
            // 
            this.tsRotateRight.Image = global::NAPS2.Icons.arrow_rotate_clockwise;
            resources.ApplyResources(this.tsRotateRight, "tsRotateRight");
            this.tsRotateRight.Name = "tsRotateRight";
            this.tsRotateRight.Click += new System.EventHandler(this.tsRotateRight_Click);
            // 
            // tsFlip
            // 
            this.tsFlip.Image = global::NAPS2.Icons.arrow_switch;
            resources.ApplyResources(this.tsFlip, "tsFlip");
            this.tsFlip.Name = "tsFlip";
            this.tsFlip.Click += new System.EventHandler(this.tsFlip_Click);
            // 
            // tsDeskew
            // 
            this.tsDeskew.Image = global::NAPS2.Icons.transform_shear;
            resources.ApplyResources(this.tsDeskew, "tsDeskew");
            this.tsDeskew.Name = "tsDeskew";
            this.tsDeskew.Click += new System.EventHandler(this.tsDeskew_Click);
            // 
            // tsCustomRotation
            // 
            this.tsCustomRotation.Image = global::NAPS2.Icons.numeric_stepper;
            this.tsCustomRotation.Name = "tsCustomRotation";
            resources.ApplyResources(this.tsCustomRotation, "tsCustomRotation");
            this.tsCustomRotation.Click += new System.EventHandler(this.tsCustomRotation_Click);
            // 
            // tsdReorder
            // 
            this.tsdReorder.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsInterleave,
            this.tsDeinterleave,
            this.toolStripSeparator12,
            this.tsAltInterleave,
            this.tsAltDeinterleave,
            this.toolStripSeparator1,
            this.tsReverse});
            resources.ApplyResources(this.tsdReorder, "tsdReorder");
            this.tsdReorder.Image = global::NAPS2.Icons.arrow_refresh;
            this.tsdReorder.Name = "tsdReorder";
            this.tsdReorder.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.tsdReorder.ShowDropDownArrow = false;
            // 
            // tsInterleave
            // 
            this.tsInterleave.Name = "tsInterleave";
            resources.ApplyResources(this.tsInterleave, "tsInterleave");
            this.tsInterleave.Click += new System.EventHandler(this.tsInterleave_Click);
            // 
            // tsDeinterleave
            // 
            this.tsDeinterleave.Name = "tsDeinterleave";
            resources.ApplyResources(this.tsDeinterleave, "tsDeinterleave");
            this.tsDeinterleave.Click += new System.EventHandler(this.tsDeinterleave_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            resources.ApplyResources(this.toolStripSeparator12, "toolStripSeparator12");
            // 
            // tsAltInterleave
            // 
            this.tsAltInterleave.Name = "tsAltInterleave";
            resources.ApplyResources(this.tsAltInterleave, "tsAltInterleave");
            this.tsAltInterleave.Click += new System.EventHandler(this.tsAltInterleave_Click);
            // 
            // tsAltDeinterleave
            // 
            this.tsAltDeinterleave.Name = "tsAltDeinterleave";
            resources.ApplyResources(this.tsAltDeinterleave, "tsAltDeinterleave");
            this.tsAltDeinterleave.Click += new System.EventHandler(this.tsAltDeinterleave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // tsReverse
            // 
            this.tsReverse.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsReverseAll,
            this.tsReverseSelected});
            this.tsReverse.Name = "tsReverse";
            resources.ApplyResources(this.tsReverse, "tsReverse");
            // 
            // tsReverseAll
            // 
            this.tsReverseAll.Name = "tsReverseAll";
            resources.ApplyResources(this.tsReverseAll, "tsReverseAll");
            this.tsReverseAll.Click += new System.EventHandler(this.tsReverseAll_Click);
            // 
            // tsReverseSelected
            // 
            this.tsReverseSelected.Name = "tsReverseSelected";
            resources.ApplyResources(this.tsReverseSelected, "tsReverseSelected");
            this.tsReverseSelected.Click += new System.EventHandler(this.tsReverseSelected_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // tsDelete
            // 
            resources.ApplyResources(this.tsDelete, "tsDelete");
            this.tsDelete.Image = global::NAPS2.Icons.cross;
            this.tsDelete.Name = "tsDelete";
            this.tsDelete.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.tsDelete.Click += new System.EventHandler(this.tsDelete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // BottomToolStripPanel
            // 
            resources.ApplyResources(this.BottomToolStripPanel, "BottomToolStripPanel");
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            // 
            // TopToolStripPanel
            // 
            resources.ApplyResources(this.TopToolStripPanel, "TopToolStripPanel");
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            // 
            // RightToolStripPanel
            // 
            resources.ApplyResources(this.RightToolStripPanel, "RightToolStripPanel");
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            // 
            // LeftToolStripPanel
            // 
            resources.ApplyResources(this.LeftToolStripPanel, "LeftToolStripPanel");
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            // 
            // ContentPanel
            // 
            resources.ApplyResources(this.ContentPanel, "ContentPanel");
            // 
            // FDesktop
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.toolStripContainer1);
            this.DoubleBuffered = true;
            this.Name = "FDesktop";
            this.Resize += new System.EventHandler(this.app_SizeChanged);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.tStrip.ResumeLayout(false);
            this.tStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ctxView;
        private System.Windows.Forms.ToolStripMenuItem ctxSelectAll;
        private System.Windows.Forms.ToolStripMenuItem ctxCopy;
        private System.Windows.Forms.ToolStripSeparator ctxSeparator1;
        private System.Windows.Forms.ToolStripSeparator ctxSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ctxDelete;
        private System.Windows.Forms.ToolStripMenuItem ctxPaste;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusText;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStrip tStrip;
        private System.Windows.Forms.ToolStripSplitButton tsScan;
        private System.Windows.Forms.ToolStripMenuItem tsBatchScan;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripDropDownButton tsdImage;
        private System.Windows.Forms.ToolStripMenuItem tsView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem tsCrop;
        private System.Windows.Forms.ToolStripMenuItem tsBrightnessContrast;
        private System.Windows.Forms.ToolStripMenuItem tsHueSaturation;
        private System.Windows.Forms.ToolStripMenuItem tsBlackWhite;
        private System.Windows.Forms.ToolStripMenuItem tsSharpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem tsReset;
        private System.Windows.Forms.ToolStripDropDownButton tsdRotate;
        private System.Windows.Forms.ToolStripMenuItem tsRotateLeft;
        private System.Windows.Forms.ToolStripMenuItem tsRotateRight;
        private System.Windows.Forms.ToolStripMenuItem tsFlip;
        private System.Windows.Forms.ToolStripMenuItem tsDeskew;
        private System.Windows.Forms.ToolStripMenuItem tsCustomRotation;
        private System.Windows.Forms.ToolStripDropDownButton tsdReorder;
        private System.Windows.Forms.ToolStripMenuItem tsInterleave;
        private System.Windows.Forms.ToolStripMenuItem tsDeinterleave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripMenuItem tsAltInterleave;
        private System.Windows.Forms.ToolStripMenuItem tsAltDeinterleave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsReverse;
        private System.Windows.Forms.ToolStripMenuItem tsReverseAll;
        private System.Windows.Forms.ToolStripMenuItem tsReverseSelected;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private ThumbnailList thumbnailList1;
        private System.Windows.Forms.Button btnZoomMouseCatcher;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private TiffViewerCtl tiffViewerCtl1;
        private System.Windows.Forms.ToolStripDropDownButton tsCombo_Profiles;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripMenuItem tsNewProfile;
        private System.Windows.Forms.ToolStripMenuItem tsProfiles;
        private System.Windows.Forms.ToolStripButton tsInsert;
        private System.Windows.Forms.ToolTip tt_FDesktop;
        private System.Windows.Forms.ToolStripDropDownButton FileDm;
        private System.Windows.Forms.ToolStripMenuItem loadProjectTool_TSMI;
        private System.Windows.Forms.ToolStripMenuItem tsdSavePDF;
        private System.Windows.Forms.ToolStripMenuItem tsSavePDFAll;
        private System.Windows.Forms.ToolStripMenuItem tsSavePDFSelected;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem tsPDFSettings;
        private System.Windows.Forms.ToolStripMenuItem tsdSaveImages;
        private System.Windows.Forms.ToolStripMenuItem tsSaveImagesAll;
        private System.Windows.Forms.ToolStripMenuItem tsSaveImagesSelected;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem tsImageSettings;
        private System.Windows.Forms.ToolStripMenuItem tsdEmailPDF;
        private System.Windows.Forms.ToolStripMenuItem tsEmailPDFAll;
        private System.Windows.Forms.ToolStripMenuItem tsEmailPDFSelected;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem tsEmailSettings;
        private System.Windows.Forms.ToolStripMenuItem tsPdfSettings2;
        private System.Windows.Forms.ToolStripMenuItem tsTools;
        private System.Windows.Forms.ToolStripMenuItem tsLanguage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem tsOCR;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripMenuItem tsAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem tsImport;
        private System.Windows.Forms.ToolStripMenuItem closeCurrentProject;
        private System.Windows.Forms.ToolStripMenuItem tsBarCodeCheck;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
        private System.Windows.Forms.ToolStripMenuItem tsExport;
        private System.Windows.Forms.ToolStripMenuItem tsPrjNew;
        private System.Windows.Forms.ToolStripMenuItem TS_PrjConfig;
        private System.Windows.Forms.ToolStripMenuItem TS_RenBatch;
        private System.Windows.Forms.ToolStripDropDownButton TS_View;
        private System.Windows.Forms.ToolStripMenuItem tsShowHideView2;
        private System.Windows.Forms.ToolStripMenuItem TSI_ToggleDarkMode1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton tsdDocument;
        private System.Windows.Forms.ToolStripMenuItem tsiDocumentAdd;
        private System.Windows.Forms.ToolStripMenuItem tsiDocumentRemove;
    }
}

