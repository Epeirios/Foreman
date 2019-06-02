using Foreman.Models.SerializableObjects;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Foreman.Models
{
    public class GameInstallation
    {
        public string DirPath { get; }
        public Version Version { get => BaseGameMod.ModVersion; }
        public Mod BaseGameMod { get; }

        private GameInstallation(string dirPath, Mod baseGameMod)
        {
            DirPath = dirPath;
            BaseGameMod = baseGameMod;
        }

        public static GameInstallation GetGameInstalationFromDir(string dir)
        {
            if (Directory.Exists(dir))
            {
                string json = "";
                string infoFile = Path.Combine(dir, "data", "base", "info.json");

                if (Utils.ReadJsonFile(infoFile, out json))
                {
                    Mod baseMod = new Mod(JsonConvert.DeserializeObject<ModInfo>(json));

                    return new GameInstallation(dir, baseMod);
                }
            }
            return null;
        }
    }
}
