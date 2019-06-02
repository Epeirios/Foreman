using Foreman.Models.ControlModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Foreman.Models
{
    public class Settings
    {
        private Language currentLanguage;
        private GameInstallation currentGameInstallation;
        private ModDirectory currentModDirectory;
        private bool useModList;

        private GameInstallation[] gameInstallations;
        private ModDirectory[] modDirectories;
        private string[] enabledMods;

        public Settings()
        {
            LoadSettings();
        }

        public bool UseModList
        {
            get
            {
                return useModList;
            }
            set
            {
                useModList = value;
            }
        }

        public Language CurrentLanguage
        {
            get
            {
                return currentLanguage;
            }
            set
            {
                currentLanguage = value;
            }
        }

        public GameInstallation CurrentGameInstallation
        {
            get
            {
                return currentGameInstallation;
            }
        }

        public string CurrentGameInstallationDirectory
        {
            get
            {
                if (currentGameInstallation != null)
                {
                    return currentGameInstallation.DirPath;
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                if (VerifyGameDirectory(value))
                {
                    List<GameInstallation> installations = new List<GameInstallation>();
                    installations.AddRange(gameInstallations);

                    GameInstallation installation = GameInstallation.GetGameInstalationFromDir(value);

                    if (!Array.Exists(GetGameInstallationDirectories(), e => e == value))
                    {
                        installations.Add(installation);
                    }

                    gameInstallations = installations.ToArray();
                    currentGameInstallation = installation;
                }
            }
        }

        public ModDirectory CurrentModDirectory
        {
            get
            {
                return currentModDirectory;
            }
        }

        public string CurrentModDirectoryString
        {
            get
            {
                if (currentModDirectory != null)
                {
                    return currentModDirectory.Directory;
                }
                else
                {
                    return string.Empty;
                }                
            }
            set
            {
                if (VerifyModDirectory(value))
                {
                    string dir = CorrectifyModDirectory(value);
                    ModDirectory modDirectory = null;

                    List<ModDirectory> dirs = new List<ModDirectory>();
                    dirs.AddRange(modDirectories);

                    if (!dirs.Select(x => x.Directory).ToArray().Contains(value))
                    {
                        modDirectory = ModDirectory.GetModDirectoryFromDir(value, enabledMods);

                        dirs.Add(modDirectory);
                    }

                    modDirectories = dirs.ToArray();

                    if (modDirectory != null)
                    {
                        currentModDirectory = modDirectory;
                    }
                    
                    return;
                }
            }
        }

        public string[] GetGameInstallationDirectories()
        {
            GameInstallation[] installations = gameInstallations;

            List<string> installationDirs = new List<string>();

            foreach (var item in installations)
            {
                installationDirs.Add(item.DirPath);
            }

            return installationDirs.ToArray();
        }

        public GameInstallation[] GetGameInstallations()
        {
            return gameInstallations;
        }

        public string[] GetModDirectoryStrings()
        {
            List<string> directories = new List<string>();

            foreach (var item in modDirectories)
            {
                if (item != null)
                {
                    directories.Add(item.Directory);
                }                
            }

            return directories.ToArray();
        }

        public ModDirectory[] GetModDirectories()
        {
            return modDirectories;
        }

        public Language[] GetLanguages()
        {
            throw new NotImplementedException();
        }

        private GameInstallation[] SearchGameInstallations()
        {
            System.Collections.Specialized.StringCollection possibleDirs = new System.Collections.Specialized.StringCollection();
            List<GameInstallation> installations = new List<GameInstallation>();

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
                    if (VerifyGameDirectory(dir))
                    {
                        installations.Add(GameInstallation.GetGameInstalationFromDir(dir));
                    }
                }
            }

            return installations.ToArray();
        }

        private ModDirectory[] SearchModDirectories()
        {
            List<string> possibleDirs = new List<string>();

            String steamFolder = Path.Combine("Steam", "steamapps", "common");

            possibleDirs.AddRange(new string[]{
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Factorio", "mods")
            });

            System.Collections.Specialized.StringCollection savedDirs = Properties.Settings.Default.AllGameModDirectories;

            foreach (var dir in savedDirs)
            {
                if (!possibleDirs.Contains(dir))
                {
                    if (VerifyModDirectory(dir))
                    {
                        possibleDirs.Add(dir);
                    }                    
                }
            }

            List<ModDirectory> modDirectories = new List<ModDirectory>();

            foreach (var item in possibleDirs)
            {
                var modDir = ModDirectory.GetModDirectoryFromDir(item, enabledMods);

                if (modDir != null)
                {
                    modDirectories.Add(modDir);
                }                
            }

            return modDirectories.ToArray();
        }

        public bool VerifyGameDirectory(string dir)
        {
            bool legit = false;

            if (GameInstallation.GetGameInstalationFromDir(dir) != null)
            {
                legit = true;
            }

            return legit;
        }

        public string CorrectifyModDirectory(string dir)
        {
            if (VerifyModDirectory(dir))
            {
                if (Path.GetFileName(dir) == "Factorio")
                {
                    string correctedDir = Path.Combine(dir, "mods");

                    if (Directory.Exists(correctedDir))
                    {
                        dir = correctedDir;
                    }
                }
            }
            return dir;
        }

        public bool VerifyModDirectory(string dir)
        {
            bool legit = false;

            if (Directory.Exists(dir))
            {
                if (Path.GetFileName(dir) == "Factorio")
                {
                    if (Directory.Exists(Path.Combine(dir, "mods")))
                    {
                        legit = true;
                    }
                }
                else if (Path.GetFileName(dir) == "mods")
                {
                    if (Directory.GetParent(dir).Name == "Factorio")
                    {
                        legit = true;
                    }
                }
            }

            return legit;
        }

        private System.Collections.Specialized.StringCollection StringArrayToStringCollection(string[] array)
        {
            System.Collections.Specialized.StringCollection collection = new System.Collections.Specialized.StringCollection();
            collection.AddRange(array);
            return collection;
        }

        private string[] StringCollectionToStringArray(System.Collections.Specialized.StringCollection collection)
        {
            List<string> strings = new List<string>();

            foreach (var item in collection)
            {
                strings.Add(item);
            }

            return strings.ToArray();
        }

        public void LoadSettings()
        {
            enabledMods = StringCollectionToStringArray(Properties.Settings.Default.EnabledMods);

            currentLanguage = new Language(Properties.Settings.Default.Language, "English");
            currentGameInstallation = GameInstallation.GetGameInstalationFromDir(Properties.Settings.Default.GameInstallationDirectory);
            currentModDirectory = ModDirectory.GetModDirectoryFromDir(Properties.Settings.Default.GameModDirectory, enabledMods);
            useModList = Properties.Settings.Default.UseModList;

            gameInstallations = SearchGameInstallations();
            modDirectories = SearchModDirectories();
            enabledMods = StringCollectionToStringArray(Properties.Settings.Default.EnabledMods);
        }

        public void SaveSettings()
        {
            Properties.Settings.Default.Language = currentLanguage.LanguageID;
            Properties.Settings.Default.GameInstallationDirectory = currentGameInstallation.DirPath;
            Properties.Settings.Default.GameModDirectory = currentModDirectory.Directory;
            Properties.Settings.Default.UseModList = useModList;

            Properties.Settings.Default.AllGameInstallationDirectories = StringArrayToStringCollection(GetGameInstallationDirectories());
            Properties.Settings.Default.AllGameModDirectories = StringArrayToStringCollection(GetModDirectoryStrings());
            Properties.Settings.Default.EnabledMods = StringArrayToStringCollection(enabledMods);

            Properties.Settings.Default.Save();
        }
    }
}
