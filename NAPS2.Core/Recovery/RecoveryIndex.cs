using System;
using System.Collections.Generic;
using System.Linq;
using NAPS2.ImportExport.Images;

namespace NAPS2.Recovery
{
    public class RecoveryIndex
    {
        public const int CURRENT_VERSION = 1;

        public RecoveryIndex()
        {
            imageSettings = new ImageSettings();
            Images = new List<RecoveryIndexImage>();
        }

        public ImageSettings imageSettings { get; set; }

        public int Version { get; set; }

        public List<RecoveryIndexImage> Images { get; set; }
    }
}
