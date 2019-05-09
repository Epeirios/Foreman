using Foreman.Events;
using Foreman.Views;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Windows.Forms;

namespace Foreman.Presenters
{
    public class SettingsPresenter
    {
        private ISettingsView settingsView;

        public SettingsPresenter(ISettingsView settingsView)
        {
            this.settingsView = settingsView;

            EventAggregator.Instance.Subscribe<MainFormLoadedMessage>(m => SetupDirs());
        }

        private void SetupDirs()
        {
            //I changed the name of the variable, so this copies the value over for people who are upgrading their Foreman version
            if (Properties.Settings.Default.FactorioPath == "" && Properties.Settings.Default.FactorioDataPath != "")
            {
                Properties.Settings.Default["FactorioPath"] = Path.GetDirectoryName(Properties.Settings.Default.FactorioDataPath);
                Properties.Settings.Default["FactorioDataPath"] = "";
            }

            if (!Directory.Exists(Properties.Settings.Default.FactorioPath))
            {
                List<FoundInstallation> installations = new List<FoundInstallation>();
                String steamFolder = Path.Combine("Steam", "steamapps", "common");
                foreach (String defaultPath in new String[]{
                  Path.Combine(Environment.GetEnvironmentVariable("PROGRAMFILES(X86)"), steamFolder, "Factorio"),
                  Path.Combine(Environment.GetEnvironmentVariable("ProgramW6432"), steamFolder, "Factorio"),
                  Path.Combine(Environment.GetEnvironmentVariable("PROGRAMFILES(X86)"), "Factorio"),
                  Path.Combine(Environment.GetEnvironmentVariable("ProgramW6432"), "Factorio"),
                  Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Applications", "factorio.app", "Contents")}) //Not actually tested on a Mac
                {
                    if (Directory.Exists(defaultPath))
                    {
                        FoundInstallation inst = FoundInstallation.GetInstallationFromPath(defaultPath);
                        if (inst != null)
                            installations.Add(inst);
                    }
                }

                if (installations.Count > 0)
                {
                    if (installations.Count > 1)
                    {
                        using (InstallationChooserForm form = new InstallationChooserForm(installations))
                        {
                            if (form.ShowDialog() == DialogResult.OK && form.SelectedPath != null)
                            {
                                Properties.Settings.Default["FactorioPath"] = form.SelectedPath;
                            }
                            else
                            {
                                form.Close();
                                form.Dispose();
                                return;
                            }
                        }
                    }
                    else
                    {
                        Properties.Settings.Default["FactorioPath"] = installations[0].path;
                    }

                    Properties.Settings.Default.Save();
                }
            }

            if (!Directory.Exists(Properties.Settings.Default.FactorioPath))
            {
                using (DirectoryChooserForm form = new DirectoryChooserForm(""))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        Properties.Settings.Default["FactorioPath"] = form.SelectedPath;
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        form.Close();
                        form.Dispose();
                        return;
                    }
                }
            }

            if (!Directory.Exists(Properties.Settings.Default.FactorioModPath))
            {
                if (Directory.Exists(Path.Combine(Properties.Settings.Default.FactorioPath, "mods")))
                {
                    Properties.Settings.Default["FactorioModPath"] = Path.Combine(Properties.Settings.Default.FactorioPath, "mods");
                }
                else if (Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "factorio", "mods")))
                {
                    Properties.Settings.Default["FactorioModPath"] = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "factorio", "mods");
                }
            }

            if (Properties.Settings.Default.EnabledMods == null) Properties.Settings.Default.EnabledMods = new StringCollection();
            if (Properties.Settings.Default.EnabledAssemblers == null) Properties.Settings.Default.EnabledAssemblers = new StringCollection();
            if (Properties.Settings.Default.EnabledMiners == null) Properties.Settings.Default.EnabledMiners = new StringCollection();
            if (Properties.Settings.Default.EnabledModules == null) Properties.Settings.Default.EnabledModules = new StringCollection();
        }
    }
}
