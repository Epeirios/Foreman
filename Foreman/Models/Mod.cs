using Foreman.Models.SerializableObjects;
using System;
using System.Collections.Generic;

namespace Foreman.Models
{
    public class Mod
    {
        private ModInfo modInfo;

        public string ModName { get => modInfo.name; }
        public string ModTitle { get => modInfo.title; }
        public Version ModVersion { get => GetVersion(modInfo.version); }
        public Version FactorioVersion { get => GetVersion(modInfo.factorio_version); }
        public ModDependency[] Dependencies { get; private set; }

        public Mod(ModInfo modInfo)
        {
            this.modInfo = modInfo;
            this.Dependencies = ParseModInfoDependencies(modInfo.dependencies);
        }

        private Version GetVersion(string version)
        {
            Version tempVersion;

            Version.TryParse(version, out tempVersion);

            return tempVersion;
        }

        private ModDependency[] ParseModInfoDependencies(string[] dependencies)
        {
            List<ModDependency> modDependencies = new List<ModDependency>();

            foreach (var item in dependencies)
            {
                string modName = "noName";
                Version modVersion = new Version();
                DependencyType dependencyType = DependencyType.EqualTo;
                bool optional = false;

                int offset = 0;

                string[] stringElements = item.Split(' ');
                int lenght = stringElements.Length;

                if (lenght >= 3)
                {
                    if (stringElements.Length == 4)
                    {
                        if (stringElements[0] == "?")
                        {
                            optional = true;
                            offset += 1;
                        }
                    }

                    switch (stringElements[offset + 1])
                    {
                        case "=":
                            dependencyType = DependencyType.EqualTo;
                            break;
                        case ">":
                            dependencyType = DependencyType.GreaterThan;
                            break;
                        case ">=":
                            dependencyType = DependencyType.GreaterThanOrEqual;
                            break;
                        default:
                            break;
                    }


                    Version.TryParse(stringElements[offset + 2], out modVersion);
                }
                else if (lenght == 2)
                {
                    dependencyType = DependencyType.GreaterThanOrEqual;
                    modVersion = new Version();
                }

                modName = stringElements[offset + 0];

                modDependencies.Add(new ModDependency(modName, modVersion, dependencyType, optional));
            }

            return modDependencies.ToArray();
        }
    }
}
