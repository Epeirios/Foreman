using Newtonsoft.Json;
using System;
using System.IO;

namespace Foreman
{
    public class FoundInstallation
    {
        public string DirPath { get; set; }
        public Version Version { get; set; }

        protected FoundInstallation(string dirPath, Version version)
        {
            this.DirPath = dirPath;
            this.Version = version;
        }

        public static FoundInstallation GetInstallationFromPath(string factorioPath)
        {
            String json = "";
            String infoFile = Path.Combine(factorioPath, "data", "base", "info.json");
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
                newMod.parsedVersion = new Version(0,0,0);
            }

            return new FoundInstallation(factorioPath, newMod.parsedVersion);
        }
    }
}
