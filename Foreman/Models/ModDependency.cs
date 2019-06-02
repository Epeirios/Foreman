using System;

namespace Foreman.Models
{
    public class ModDependency
    {
        public ModDependency(string modName, Version modVersion, DependencyType versionType, bool optional)
        {
            ModName = modName;
            ModVersion = modVersion;
            VersionType = versionType;
            Optional = optional;
        }

        public string ModName { get; private set; }
        public Version ModVersion { get; private set; }
        public bool Optional { get; private set; }
        public DependencyType VersionType { get; private set; }
    }

    public enum DependencyType
    {
        EqualTo,
        GreaterThan,
        GreaterThanOrEqual
    }
}
