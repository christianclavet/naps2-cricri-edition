using System;
using System.Collections.Generic;
using System.Linq;

namespace NAPS2.ImportExport.Images
{
    public class ImageSettings
    {
        public const int DEFAULT_JPEG_QUALITY = 75;

        public ImageSettings()
        {
            JpegQuality = DEFAULT_JPEG_QUALITY;
        }

        public string DefaultFileName { get; set; }

        public bool SkipSavePrompt { get; set; }

        public int JpegQuality { get; set; }

        public TiffCompression TiffCompression { get; set; }

        public bool SinglePageTiff { get; set; }

        public bool UseCSVExport { get; set; }

        public string CSVFileName { get; set; }

        public string CSVExpression { get; set; }

        public string ProjectName { get; set; } 
    }
}
