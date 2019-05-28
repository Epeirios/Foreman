using Newtonsoft.Json;
using System;
using System.IO;

namespace Foreman.Models
{
    public class FoundInstallation
    {
        public string DirPath { get; }
        public Version Version { get; }

        public FoundInstallation(string dirPath, Version version)
        {
            this.DirPath = dirPath;
            this.Version = version;
        }
    }
}
