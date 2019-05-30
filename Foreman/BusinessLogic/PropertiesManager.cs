using System.Collections.Specialized;
using System.IO;

namespace Foreman.BusinessLogic
{
    public class PropertiesManager : IPropertiesManager
    {
        public PropertiesManager()
        {
            SetupProperties();
        }

        public void SetupProperties()
        {
            if (Properties.Settings.Default.AllGameInstallationDirectories == null) Properties.Settings.Default.AllGameInstallationDirectories = new StringCollection();
            if (Properties.Settings.Default.AllGameModDirectories == null) Properties.Settings.Default.AllGameModDirectories = new StringCollection();

            if (Properties.Settings.Default.EnabledMods == null) Properties.Settings.Default.EnabledMods = new StringCollection();
            if (Properties.Settings.Default.EnabledAssemblers == null) Properties.Settings.Default.EnabledAssemblers = new StringCollection();
            if (Properties.Settings.Default.EnabledMiners == null) Properties.Settings.Default.EnabledMiners = new StringCollection();
            if (Properties.Settings.Default.EnabledModules == null) Properties.Settings.Default.EnabledModules = new StringCollection();

            Properties.Settings.Default.Save();
        }
    }
}
