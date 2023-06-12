using System;
using System.Collections.Generic;
using System.Linq;

namespace NAPS2.ImportExport.Images
{
    public class ProjectSettings
    {

        public ProjectSettings()
        {

        }
        public string Name { get; set; }
        public string Description { get; set; }

        public string DefaultFileName { get; set; }

        public bool UseCSVExport { get; set; }

        public string CSVFileName { get; set; }

        public string CSVExpression { get; set; }

        public string ProjectName { get; set; }
    }
}
