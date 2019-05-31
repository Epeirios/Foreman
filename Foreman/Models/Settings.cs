using System;
using System.Collections.Generic;
using System.IO;

namespace Foreman.Models
{
    public class Settings
    {
        private Language currentLanguage;
        private GameInstallation currentGameInstallation;
        private string currentModDirectory;

        private GameInstallation[] gameInstallations;
        private string[] modDirectories;

        public Settings()
        {
            LoadSettings();
        }

        Language CurrentLanguage
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
                return currentGameInstallation.DirPath;
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

        public string CurrentModDirectory
        {
            get
            {
                return currentModDirectory;
            }
            set
            {
                if (VerifyModDirectory(value))
                {
                    if (Path.GetFileName(value) == "Factorio")
                    {
                        string correctedDir = Path.Combine(value, "mods");

                        if (Directory.Exists(correctedDir))
                        {
                            List<string> dirs = new List<string>();
                            dirs.AddRange(modDirectories);

                            if (!dirs.Contains(correctedDir))
                            {
                                dirs.Add(correctedDir);
                            }
                            modDirectories = dirs.ToArray();

                            currentModDirectory = correctedDir;
                            return;
                        }
                    }
                    else if (Path.GetFileName(value) == "mods")
                    {
                        if (Directory.GetParent(value).Name == "Factorio")
                        {
                            List<string> dirs = new List<string>();
                            dirs.AddRange(modDirectories);

                            if (!dirs.Contains(value))
                            {
                                dirs.Add(value);
                            }
                            modDirectories = dirs.ToArray();

                            currentModDirectory = value;
                        }
                    }
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

        public string[] GetModDirectories()
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

        private string[] SearchModDirectories()
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

            return possibleDirs.ToArray();
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

        public void LoadSettings()
        {
            currentLanguage = new Language(Properties.Settings.Default.Language, "English");
            currentGameInstallation = GameInstallation.GetGameInstalationFromDir(Properties.Settings.Default.GameInstallationDirectory);
            currentModDirectory = Properties.Settings.Default.GameModDirectory;

            gameInstallations = SearchGameInstallations();
            modDirectories = SearchModDirectories();
        }

        public void SaveSettings()
        {
            Properties.Settings.Default.Language = currentLanguage.LanguageID;
            Properties.Settings.Default.GameInstallationDirectory = currentGameInstallation.DirPath;
            Properties.Settings.Default.GameModDirectory = currentModDirectory;

            Properties.Settings.Default.AllGameInstallationDirectories = StringArrayToStringCollection(GetGameInstallationDirectories());
            Properties.Settings.Default.AllGameModDirectories = StringArrayToStringCollection(modDirectories);

            Properties.Settings.Default.Save();
        }
    }
}
