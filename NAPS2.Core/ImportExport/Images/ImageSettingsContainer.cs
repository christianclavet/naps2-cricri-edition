using System;
using System.Collections.Generic;
using System.Linq;
using NAPS2.Config;

namespace NAPS2.ImportExport.Images
{
    public class ImageSettingsContainer
    {
        private readonly IUserConfigManager userConfigManager;

        private ImageSettings localImageSettings;

        private static ProjectSettings localProjectSettings;
        private ProjectSettings localPRJSettings;

        public ImageSettingsContainer(IUserConfigManager userConfigManager)
        {
            this.userConfigManager = userConfigManager;
        }

        public ImageSettings ImageSettings
        {
            get => localImageSettings ?? userConfigManager.Config.ImageSettings ?? new ImageSettings();
            set => localImageSettings = value;
        }

        public ProjectSettings Project_Settings
        {
            get => localPRJSettings ?? new ProjectSettings();
            set => localPRJSettings = value;
        }

        static public ProjectSettings ProjectSettings 
        {
            get => localProjectSettings ?? new ProjectSettings();
            set => localProjectSettings = value; 
        }

    }
}
