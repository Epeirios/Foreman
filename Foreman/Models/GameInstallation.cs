using Newtonsoft.Json;
using System;
using System.IO;

namespace Foreman.Models
{
    public class GameInstallation
    {
        public string DirPath { get; }
        public Version Version { get; }

        public GameInstallation(string dirPath, Version version)
        {
            this.DirPath = dirPath;
            this.Version = version;
        }

        public static GameInstallation GetGameInstalationFromDir(string dir)
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

                return new GameInstallation(dir, newMod.parsedVersion);
            }
            return null;
        }
    }
}
