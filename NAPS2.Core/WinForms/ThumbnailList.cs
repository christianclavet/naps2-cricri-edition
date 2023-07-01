using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using NAPS2.Platform;
using NAPS2.Scan.Images;
using NTwain.Data;
using ZXing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NAPS2.WinForms
{
    public partial class ThumbnailList : DragScrollListView
    {
        private static readonly FieldInfo imageSizeField;
        private static readonly MethodInfo performRecreateHandleMethod;
        private static int documentCount;

        static ThumbnailList()
        {
            documentCount = 1;
            // Try to enable larger thumbnails via a reflection hack
            if (PlatformCompat.Runtime.SetImageListSizeOnImageCollection)
            {
                imageSizeField = typeof(ImageList.ImageCollection).GetField("imageSize", BindingFlags.Instance | BindingFlags.NonPublic);
                performRecreateHandleMethod = typeof(ImageList.ImageCollection).GetMethod("RecreateHandle", BindingFlags.Instance | BindingFlags.NonPublic);
            }
            else
            {
                imageSizeField = typeof(ImageList).GetField("imageSize", BindingFlags.Instance | BindingFlags.NonPublic);
                performRecreateHandleMethod = typeof(ImageList).GetMethod("PerformRecreateHandle", BindingFlags.Instance | BindingFlags.NonPublic);
            }

            if (imageSizeField == null || performRecreateHandleMethod == null)
            {
                // No joy, just be happy enough with 256
                ThumbnailRenderer.MAX_SIZE = 256;
               
            }
        }

        private Bitmap placeholder;

        public ListViewGroupCollection GetGroups()
        {
            return Groups;
        }

        public ThumbnailList()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            LargeImageList = ilThumbnailList;
            addGroup("Document "+documentCount.ToString());
           
        }

        public ThumbnailRenderer ThumbnailRenderer { get; set; }

        public Size ThumbnailSize
        {
            get => ilThumbnailList.ImageSize;
            set
            {
                if (imageSizeField != null && performRecreateHandleMethod != null)
                {
                    // A simple hack to let the listview have larger thumbnails than 256x256
                    if (PlatformCompat.Runtime.SetImageListSizeOnImageCollection)
                    {
                        imageSizeField.SetValue(ilThumbnailList.Images, value);
                        performRecreateHandleMethod.Invoke(ilThumbnailList.Images, new object[] { });
                    }
                    else
                    {
                        imageSizeField.SetValue(ilThumbnailList, value);
                        performRecreateHandleMethod.Invoke(ilThumbnailList, new object[] { "ImageSize" });
                    }
                }
                else
                {
                    ilThumbnailList.ImageSize = value;
                }
            }
        }

        private string ItemText => PlatformCompat.Runtime.UseSpaceInListViewItem ? " " : "";

        private List<ScannedImage> CurrentImages => Items.Cast<ListViewItem>().Select(x => (ScannedImage)x.Tag).ToList();

        public void AddedImages(List<ScannedImage> allImages)
        {
            lock (this)
            {
                BeginUpdate();
                for (int i = 0; i < ilThumbnailList.Images.Count; i++)
                {
                    if (Items[i].Tag != allImages[i])
                    {
                        ilThumbnailList.Images[i] = GetThumbnail(allImages[i]);
                        Items[i].Tag = allImages[i];
                    }
                }
                for (int i = ilThumbnailList.Images.Count; i < allImages.Count; i++)
                {
                    ilThumbnailList.Images.Add(GetThumbnail(allImages[i]));
                    Items.Add(ItemText, i).Tag = allImages[i];           
                    if (allImages[i].IsSeparator)
                    {
                        Items[i].Text = (i + 1).ToString() + " Separator";
                    } else 
                    {
                        Items[i].Text = (i + 1).ToString();
                    }
                    //Items[i].ForeColor = color;
                }
                EndUpdate();
                GroupRefresh(allImages);
            }
            Invalidate();
        }

        public void DeletedImages(List<ScannedImage> allImages)
        {
            lock (this)
            {
                BeginUpdate();
                if (allImages.Count == 0)
                {
                    ilThumbnailList.Images.Clear();
                    Items.Clear();
                }
                else
                {
                    foreach (var oldImg in CurrentImages.Except(allImages))
                    {
                        var item = Items.Cast<ListViewItem>().First(x => x.Tag == oldImg);
                        foreach (ListViewItem item2 in Items)
                        {
                            if (item2.ImageIndex > item.ImageIndex)
                            {
                                item2.ImageIndex -= 1;
                            }
                        }

                        ilThumbnailList.Images.RemoveAt(item.ImageIndex);
                        Items.RemoveAt(item.Index);
                    }
                }
                EndUpdate();
                GroupRefresh(allImages);
            }
            Invalidate();
        }

        public void UpdatedImages(List<ScannedImage> images, List<int> selection)
        {
            lock (this)
            {
                BeginUpdate();
                int min = selection == null || !selection.Any() ? 0 : selection.Min();
                int max = selection == null || !selection.Any() ? images.Count : selection.Max() + 1;         

                for (int i = min; i < max; i++)
                {
                    int imageIndex = Items[i].ImageIndex;
                    ilThumbnailList.Images[imageIndex] = GetThumbnail(images[i]);
                    Items[i].Tag = images[i];

                    if (images[i].IsSeparator)
                    {
                        Items[i].Text = (i + 1).ToString() + "/" + Items.Count.ToString() + " Separator";
                    }
                    else
                    {
                        Items[i].Text = (i + 1).ToString() + "/" + Items.Count.ToString() + " ";
                    }
                    Items[i].ForeColor = Color.White;
                }
                EndUpdate();
                GroupRefresh(images);
            }
            Invalidate();
        }

        public void GroupRefresh(List<ScannedImage> images)
        {
            var max = images.Count;
            Groups.Clear();
            documentCount = 1;
            addGroup("Document " + documentCount.ToString());
            BeginUpdate();
            for (int i = 0; i < max; i++)
            {
                // Group define.
                if (images[i].IsSeparator)
                {
                    documentCount++;
                    addGroup("Document " + documentCount.ToString());

                }
                Groups[documentCount - 1].Items.Add(Items[i]);
                SetGroupState(ListViewGroupState.Collapsible);
                SetGroupFooter(Groups[documentCount - 1], (Groups[documentCount - 1].Items.Count).ToString() + " Pages(s) in this document");
            }
            EndUpdate(); 

        }

        public void ReplaceThumbnail(int index, ScannedImage img)
        {
            lock (this)
            {
                BeginUpdate();
                var thumb = GetThumbnail(img);
                if (thumb.Size == ThumbnailSize)
                {
                    ilThumbnailList.Images[index] = thumb;
                    Invalidate(Items[index].Bounds);
                }
                EndUpdate();
            }
        }

        public void RegenerateThumbnailList(List<ScannedImage> images, Color color, bool onlyText = false)
        {
            lock (this)
            {
                
                if (!onlyText)
                {
                    BeginUpdate();
                    if (ilThumbnailList.Images.Count > 0)
                    {
                        ilThumbnailList.Images.Clear();
                    }

                    var list = new List<Image>();
                    foreach (var image in images)
                    {
                        list.Add(GetThumbnail(image));
                    }

                    ilThumbnailList.Images.AddRange(list.ToArray());
                    EndUpdate();
                }

                foreach (ListViewItem item in Items)
                {
                    if (images[item.Index].IsSeparator)
                    {
                        item.Text = (item.Index + 1).ToString() + "/" + Items.Count.ToString() + " Separator";
                    } else
                    {
                        item.Text = (item.Index + 1).ToString() + "/" + Items.Count.ToString();
                    }
                    item.ImageIndex = item.Index;
                    item.ForeColor = color;


                }

                
                
            }
        }

        private Bitmap GetThumbnail(ScannedImage img)
        {
            lock (this)
            {
                var thumb = img.GetThumbnail();
                if (thumb == null)
                {
                    return RenderPlaceholder();
                }
                if (img.IsThumbnailDirty)
                {
                    thumb = DrawHourglass(thumb);
                }
                return thumb;
            }
        }

        private Bitmap RenderPlaceholder()
        {
            lock (this)
            {
                if (placeholder?.Size == ThumbnailSize)
                {
                    return placeholder;
                }
                placeholder?.Dispose();
                placeholder = new Bitmap(ThumbnailSize.Width, ThumbnailSize.Height);
                placeholder = DrawHourglass(placeholder);
                return placeholder;
            }
        }

        public void addGroup(string text)
        {
            this.Groups.Add(new ListViewGroup(text, HorizontalAlignment.Left));            
        }

        private Bitmap DrawHourglass(Image image)
        {
            var bitmap = new Bitmap(ThumbnailSize.Width, ThumbnailSize.Height);
            using (var g = Graphics.FromImage(bitmap))
            {
                var attrs = new ImageAttributes();
                attrs.SetColorMatrix(new ColorMatrix
                {
                    Matrix33 = 0.3f
                });
                g.DrawImage(image,
                    new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                    0,
                    0,
                    image.Width,
                    image.Height,
                    GraphicsUnit.Pixel,
                    attrs);
                g.DrawImage(Icons.hourglass_grey, new Rectangle((bitmap.Width - 32) / 2, (bitmap.Height - 32) / 2, 32, 32));
            }
            image.Dispose();
            return bitmap;
        }
    }
}
