using System;
using System.Collections.Generic;
using System.IO;
using Foreman.Models;
using Newtonsoft.Json;

namespace Foreman.BusinessLogic
{
    public class SettingsManager : ISettingsManager
    {
        public SettingsManager()
        {
            SearchGameDirectories();
            SearchModDirectories();
        }

        Language ISettingsManager.CurrentLanguage
        {
            get
            {
                string savedValue = Properties.Settings.Default.Language;
                Language language;

                if (string.IsNullOrWhiteSpace(savedValue))
                {
                    Properties.Settings.Default.Language = "en";
                    language = new Language("en", "English");
                }
                else
                {
                    language = new Language(savedValue, savedValue);
                }

                return language;
            }
            set => throw new NotImplementedException();
        }

        public FoundInstallation CurrentGameInstallation
        {
            get
            {
                string dir = Properties.Settings.Default.GameInstallationDirectory;

                FoundInstallation installation = GetGameInstalationFromDir(dir);

                return installation;
            }
            set
            {
                Properties.Settings.Default.GameInstallationDirectory = value.DirPath;
                Properties.Settings.Default.Save();
            }
        }

        public string CurrentGameDirectory
        {
            get
            {
                return Properties.Settings.Default.GameInstallationDirectory;
            }
            set
            {
                Properties.Settings.Default.GameInstallationDirectory = value;
                Properties.Settings.Default.Save();
            }
        }

        public string CurrentModDirectory
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public string[] GetFoundInstallationDirectories()
        {
            throw new NotImplementedException();
        }

        public FoundInstallation[] GetFoundInstallations()
        {
            throw new NotImplementedException();
        }

        public string[] GetFoundModDirectories()
        {
            throw new NotImplementedException();
        }

        public Language[] GetLanguages()
        {
            throw new NotImplementedException();
        }

        private FoundInstallation[] SearchGameDirectories()
        {
            System.Collections.Specialized.StringCollection possibleDirs = new System.Collections.Specialized.StringCollection();
            List<FoundInstallation> installations = new List<FoundInstallation>();

            String steamFolder = Path.Combine("Steam", "steamapps", "common");

            possibleDirs.AddRange(new string[]
            {
                Path.Combine(Environment.GetEnvironmentVariable("PROGRAMFILES(X86)"), steamFolder, "Factorio"),
                Path.Combine(Environment.GetEnvironmentVariable("ProgramW6432"), steamFolder, "Factorio"),
                Path.Combine(Environment.GetEnvironmentVariable("PROGRAMFILES(X86)"), "Factorio"),
                Path.Combine(Environment.GetEnvironmentVariable("ProgramW6432"), "Factorio"),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Applications", "factorio.app", "Contents")
            });
            
            System.Collections.Specialized.StringCollection savedDirs = Properties.Settings.Default.AllGameInstallationDirectories;
            
            foreach (var dir in savedDirs)
            {
                if (!possibleDirs.Contains(dir))
                {
                    possibleDirs.Add(dir);
                }                
            }

            foreach (var dir in possibleDirs)
            {
                if (Directory.Exists(dir))
                {
                    FoundInstallation instal = GetGameInstalationFromDir(dir);

                    if (instal != null)
                    {
                        installations.Add(instal);
                    }                    
                }
            }

            return installations.ToArray();
        }

        private FoundInstallation GetGameInstalationFromDir(string dir)
        {
            if (Directory.Exists(dir))
            {
                String json = "";
                String infoFile = Path.Combine(dir, "data", "base", "info.json");
                try
                {
                    if (!File.Exists(infoFile))
                    {
                        return null;
                    }
                    json = File.ReadAllText(infoFile);
                }
                catch (Exception)
                {
                    ErrorLogging.LogLine(String.Format("The Installation at '{0}' has an invalid info.json file", infoFile));
                }

                if (json == "")
                    return null;

                Mod newMod = JsonConvert.DeserializeObject<Mod>(json);

                if (!Version.TryParse(newMod.version, out newMod.parsedVersion))
                {
                    newMod.parsedVersion = new Version(0, 0, 0);
                }

                return new FoundInstallation(dir, newMod.parsedVersion);
            }
            return null;
        }

        private string[] SearchModDirectories()
        {
            List<string> possibleDirs = new List<string>();
            
            String steamFolder = Path.Combine("Steam", "steamapps", "common");

            possibleDirs.AddRange(new string[]{
                Path.Combine(Properties.Settings.Default.GameModDirectory, "mods"),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "factorio", "mods")         
            });

            System.Collections.Specialized.StringCollection savedDirs = Properties.Settings.Default.AllGameModDirectories;

            foreach (var dir in savedDirs)
            {
                if (!possibleDirs.Contains(dir))
                {
                    possibleDirs.Add(dir);
                }                
            }

            return possibleDirs.ToArray();
        }
    }
}
