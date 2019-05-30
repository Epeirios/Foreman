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
    }
}
