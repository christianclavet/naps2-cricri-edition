using NAPS2.Scan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace NAPS2.ImportExport.Images
{
    public class ProjectSettings
    {
        public const int CURRENT_VERSION = 1;

        public ProjectSettings()
        {
            Name = string.Empty;
            Description = string.Empty;
            DefaultFileName = string.Empty;
            UseCSVExport = false;
            CSVExpression = string.Empty;
            ProjectName = string.Empty;

        }

        [XmlIgnore]
        public bool IsLocked { get; set; }

        [XmlIgnore]
        public bool IsDeviceLocked { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string DefaultFileName { get; set; }

        public bool UseCSVExport { get; set; }

        public string CSVFileName { get; set; }

        public string CSVExpression { get; set; }

        public string ProjectName { get; set; }

        public ProjectSettings Clone()
        {
            var settings = (ProjectSettings)MemberwiseClone();
            
            return settings;
        }
    }
}
