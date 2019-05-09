using System;
using System.Collections.Generic;
using System.IO;

namespace Foreman.BusinessLogic
{
    public class GameDirectoriesManager : IGameDirectoriesManager
    {
        public GameDirectoriesManager()
        {
            SearchModDirectories();
            SearchGameDirectories();
        }

        public FoundInstallation[] GameDirectories { get; private set; } = { };
        public string[] ModDirectories { get; private set; } = { };

        public bool CurrentGameDirFound()
        {
            string dir = GetCurrentGameDirectory();

            foreach (var item in GameDirectories)
            {
                if (item.DirPath == dir)
                {
                    return true;
                }
            }

            return false;
        }

        public bool CurrentModDirFound()
        {
            string dir = GetCurrentModDirectory();

            foreach (var item in GameDirectories)
            {
                if (item.DirPath == dir)
                {
                    return true;
                }
            }

            return false;
        }

        public string GetCurrentGameDirectory()
        {
            string savedDir = Properties.Settings.Default.FactorioPath;

            if (savedDir != null)
            {
                if (Directory.Exists(savedDir))
                {
                    FoundInstallation inst = FoundInstallation.GetInstallationFromPath(savedDir);

                    if (inst.Version != new Version(0, 0, 0))
                    {
                        return savedDir;
                    }
                }
            }

            Properties.Settings.Default.FactorioPath = null;
            Properties.Settings.Default.Save();
            return null;
        }

        public string GetCurrentModDirectory()
        {
            string savedDir = Properties.Settings.Default.FactorioModPath;

            if (savedDir != null)
            {
                if (Directory.Exists(savedDir))
                {
                    return savedDir;                   
                }
            }

            Properties.Settings.Default.FactorioModPath = null;
            Properties.Settings.Default.Save();
            return null;
        }

        private void SearchGameDirectories()
        {
            List<FoundInstallation> dirs = new List<FoundInstallation>();

            String steamFolder = Path.Combine("Steam", "steamapps", "common");
            foreach (String defaultPath in new String[]{
                  Path.Combine(Environment.GetEnvironmentVariable("PROGRAMFILES(X86)"), steamFolder, "Factorio"),
                  Path.Combine(Environment.GetEnvironmentVariable("ProgramW6432"), steamFolder, "Factorio"),
                  Path.Combine(Environment.GetEnvironmentVariable("PROGRAMFILES(X86)"), "Factorio"),
                  Path.Combine(Environment.GetEnvironmentVariable("ProgramW6432"), "Factorio"),
                  Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Applications", "factorio.app", "Contents")})
            {
                if (Directory.Exists(defaultPath))
                {
                    FoundInstallation inst = FoundInstallation.GetInstallationFromPath(defaultPath);
                    if (inst != null)
                        dirs.Add(inst);
                }
            }

            GameDirectories = dirs.ToArray();
        }

        private void SearchModDirectories()
        {
            List<string> dirs = new List<string>();

            if (!Directory.Exists(Properties.Settings.Default.FactorioModPath))
            {
                if (Directory.Exists(Path.Combine(Properties.Settings.Default.FactorioPath, "mods")))
                {
                    dirs.Add(Path.Combine(Properties.Settings.Default.FactorioPath, "mods"));
                }
                else if (Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "factorio", "mods")))
                {
                    dirs.Add(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "factorio", "mods"));
                }
            }

            ModDirectories = dirs.ToArray();
        }
    }
}
