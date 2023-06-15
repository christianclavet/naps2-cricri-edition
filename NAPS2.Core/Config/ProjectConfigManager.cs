using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using NAPS2.ImportExport.Images;


namespace NAPS2.Config
{
    public class ProjectConfigManager : ConfigManager<List<ProjectSettings>>
    {
        private readonly AppConfigManager appConfigManager;

        public ProjectConfigManager(AppConfigManager appConfigManager)
            : base("projectConfigs.xml", Paths.Executable, Paths.AppData, () => new List<ProjectSettings>())
        {
            this.appConfigManager = appConfigManager;
        }

        public List<ProjectSettings> Settings => Config;

        public override void Load()
        {
            base.Load();
            if (appConfigManager.Config.LockSystemProfiles)
            {
                var systemProfiles = TryLoadConfig(secondaryConfigPath);
                if (systemProfiles != null)
                {
           
                    var systemProfileNames = new HashSet<string>(systemProfiles.Select(x => x.Name));
                    foreach (var profile in Config.ToList())
                    {
                        if (systemProfileNames.Contains(profile.Name))
                        {
                            // Merge some properties from the user's copy of the profile
                            var systemProfile = systemProfiles.First(x => x.Name == profile.Name);
                            

                            // Delete the user's copy of the profile
                            Config.Remove(profile);
                            // Avoid removing duplicates
                            systemProfileNames.Remove(profile.Name);
                        }
                    }
                    if (systemProfiles.Count > 0 && appConfigManager.Config.NoUserProfiles)
                    {
                        Config.Clear();
                    }
                   
                    Config.InsertRange(0, systemProfiles);
                }
            }
        }

        protected override List<ProjectSettings> Deserialize(Stream configFileStream)
        {
            try
            {
                return ReadProfiles(configFileStream);
            }
            catch (InvalidOperationException)
            {
                // Continue, and try to read using the old serializer now
                configFileStream.Seek(0, SeekOrigin.Begin);
            }
            return ReadProfiles(configFileStream);

        }

        private static List<ProjectSettings> ReadProfiles(Stream configFileStream)
        {
            var serializer = new XmlSerializer(typeof(List<ProjectSettings>));
            var settingsList = (List<ProjectSettings>)serializer.Deserialize(configFileStream);
            
            return settingsList;
        }
    }
}
