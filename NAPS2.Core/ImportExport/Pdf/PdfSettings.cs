using System;
using System.Collections.Generic;
using System.Linq;

namespace NAPS2.ImportExport.Pdf
{
    public class PdfSettings
    {
        private PdfMetadata metadata;
        private PdfImageSettings imageSettings;
        private PdfEncryption encryption;

        public PdfSettings()
        {
            metadata = new PdfMetadata();
            imageSettings = new PdfImageSettings();
            encryption = new PdfEncryption();
        }

        public string DefaultFileName { get; set; }

        public bool SkipSavePrompt { get; set; }

        public bool SinglePagePdf { get; set; }

        public PdfMetadata Metadata
        {
            get => metadata;
            set => metadata = value ?? throw new ArgumentNullException(nameof(value));
        }

        public PdfImageSettings ImageSettings
        {
            get { return imageSettings; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                imageSettings = value;
            }
        }

        public PdfEncryption Encryption
        {
            get => encryption;
            set => encryption = value ?? throw new ArgumentNullException(nameof(value));
        }

        public PdfCompat Compat { get; set; }
    }
}
