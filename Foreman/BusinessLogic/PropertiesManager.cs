using System.Collections.Specialized;
using System.IO;

namespace Foreman.BusinessLogic
{
    public class PropertiesManager : IPropertiesManager
    {
        public void SetupProperties()
        {
            CompatabilityFixes();

            if (Properties.Settings.Default.EnabledMods == null) Properties.Settings.Default.EnabledMods = new StringCollection();
            if (Properties.Settings.Default.EnabledAssemblers == null) Properties.Settings.Default.EnabledAssemblers = new StringCollection();
            if (Properties.Settings.Default.EnabledMiners == null) Properties.Settings.Default.EnabledMiners = new StringCollection();
            if (Properties.Settings.Default.EnabledModules == null) Properties.Settings.Default.EnabledModules = new StringCollection();
        }

        private void CompatabilityFixes()
        {
            if (Properties.Settings.Default.FactorioPath == "" && Properties.Settings.Default.FactorioDataPath != "")
            {
                Properties.Settings.Default["FactorioPath"] = Path.GetDirectoryName(Properties.Settings.Default.FactorioDataPath);
                Properties.Settings.Default["FactorioDataPath"] = "";
                //Properties.Settings.Default.Properties.Remove("FactorioDataPath");
            }
        }
    }
}
