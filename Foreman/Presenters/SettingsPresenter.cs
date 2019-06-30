using Foreman.Events;
using Foreman.Views;
using Foreman.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using Foreman.Views.UserControls;

namespace Foreman.Presenters
{
    public class SettingsPresenter
    {
        private bool isSetupState = false;

        private Settings settings;

        private ISettingsView settingsView;

        private IDirectorySettingsUserControl directorySettingsUserControl;
        private IModSettingsUserControl modSettingsUserControl;
        private ILanguageSettingsUserControl languageSettingsUserControl;

        public SettingsPresenter(ISettingsView settingsView, IModSettingsUserControl modSettingsUserControl, IDirectorySettingsUserControl directorySettingsUserControl, ILanguageSettingsUserControl languageSettingsUserControl)
        {
            this.settingsView = settingsView;

            this.directorySettingsUserControl = directorySettingsUserControl;
            this.modSettingsUserControl = modSettingsUserControl;
            this.languageSettingsUserControl = languageSettingsUserControl;

            settings = new Settings();

            this.directorySettingsUserControl.DirectoryButtonPressed += GameDirectorySettingControl_DirectoryButtonPressed;
            this.directorySettingsUserControl.DirectoryChanged += GameDirectorySettingControl_DirectoryChanged;
            this.directorySettingsUserControl.SetDirectotyLabel("Game directory");
            this.directorySettingsUserControl.SetInfoLabel("Game version");
            this.directorySettingsUserControl.SetInfoValue(string.Empty);
            this.directorySettingsUserControl.SetDirectories(settings.GetGameInstallationDirectories());
            
            this.modSettingsUserControl.DirectoryButtonPressed += ModDirectorySettingControl_DirectoryButtonPressed;
            this.modSettingsUserControl.DirectoryChanged += ModDirectorySettingControl_DirectoryChanged;
            this.modSettingsUserControl.RadioButtonChanged += ModSettingsControl_RadioButtonChanged;
            this.modSettingsUserControl.SelectedModChanged += ModSettingsControl_SelectedModChanged;
            this.modSettingsUserControl.CheckedModsChanged += ModSettingsControl_CheckedModsChanged;
            this.modSettingsUserControl.DirectoryLabel = "Mod directory";
            this.modSettingsUserControl.InfoLabel = ("Mods selected");
            this.modSettingsUserControl.RadioModListLabel = "Use modlist";
            this.modSettingsUserControl.RadioCustomListLabel = "Custom modlist";
            this.modSettingsUserControl.InfoValue = (string.Empty);
            this.modSettingsUserControl.Directories = settings.GetModDirectoryStrings();

            this.languageSettingsUserControl.SetLabel("Language");

            ISettingsUserControl[] settingsControls =
            {
                this.directorySettingsUserControl,
                this.modSettingsUserControl                
            };

            settingsView.SaveAndApplyButtonPressed += SettingsView_SaveAndApplyButtonPressed;
            settingsView.CancelButtonPressed += SettingsView_CancelButtonPressed;
            settingsView.SetSettingsControls(settingsControls);
            settingsView.SetCancelButtonText("Cancel");
            settingsView.SetSaveAndApplyButtonText("Save and Apply");

            EventAggregator.Instance.Subscribe<MainFormLoadedMessage>(m =>
            {
                if (CheckIfSetupRequired())
                {
                    InitializeSetupView();
                    InitializeControlVariables();

                    EventAggregator.Instance.Publish(new SetupRequiredMessage());
                }
                else
                {
                    InitializeSettingsView();

                    //EventAggregator.Instance.Publish(new SettingsConfiguredMessage());

                    InitializeControlVariables();
                    EventAggregator.Instance.Publish(new SetupRequiredMessage());
                }
             });
        }

        private void ModSettingsControl_CheckedModsChanged(object sender, EventArgs e)
        {
            modSettingsUserControl.InfoValue = (modSettingsUserControl.ModList.Where(kv => kv.Enabled).Count().ToString() + " / " + modSettingsUserControl.ModList.Count());

            settings.CurrentModDirectory.SetModListFromCheckedModListBoxItems(modSettingsUserControl.ModList);
            modSettingsUserControl.ModList = settings.CurrentModDirectory.GetCheckedListBoxItemsModList();
        }

        private void ModSettingsControl_SelectedModChanged(object sender, EventArgs e)
        {
            string selectedModName = modSettingsUserControl.SelectedMod;

            List<TreeNode> treeNode = new List<TreeNode>();
            var mod = settings.CurrentModDirectory.ModInfoList.Where(element => element.Key.ModName == selectedModName).First().Key;

            treeNode.Add(new TreeNode($"Mod title: {mod.ModTitle}"));
            treeNode.Add(new TreeNode($"Mod name: {mod.ModName}"));
            treeNode.Add(new TreeNode($"Mod version: {mod.ModVersion.ToString()}"));
            treeNode.Add(new TreeNode($"Required Factorio version: {mod.FactorioVersion.ToString()}"));

            TreeNode dependencies = new TreeNode("Dependencies");

            foreach (var item in mod.Dependencies)
            {
                dependencies.Nodes.Add($"{item.ModName} {item.VersionType.ToString()} {item.ModVersion} Optional: {item.Optional.ToString()}");
            }

            treeNode.Add(dependencies);

            //modSettingsControl.ModInfoProperties = treeNode.ToArray();
        }

        private void ModSettingsControl_RadioButtonChanged(object sender, EventArgs e)
        {
            modSettingsUserControl.CustomModSelectionEnabled = !modSettingsUserControl.RadioUseModListSelected;
        }

        private void InitializeSetupView()
        {
            isSetupState = true;
            settingsView.SetSettingsLabel("Setup");
        }

        private void InitializeSettingsView()
        {
            isSetupState = false;
            settingsView.SetSettingsLabel("Settings");
        }

        private void ModDirectorySettingControl_DirectoryChanged(object sender, EventArgs e)
        {
            string selectedModDir = modSettingsUserControl.SelectedDirectory;

            modSettingsUserControl.InfoValue = (string.Empty);

            if (settings.VerifyModDirectory(selectedModDir))
            {
                settings.CurrentModDirectoryString = selectedModDir;

                List<string> modFiles = new List<string>();
                string[] files = Directory.GetFiles(settings.CurrentModDirectoryString);

                foreach (var file in files)
                {
                    if (Path.GetExtension(file) == ".zip")
                    {
                        modFiles.Add(file);
                    }
                }

                modSettingsUserControl.InfoValue = (settings.CurrentModDirectory.ModInfoList.Values.Where(kv => kv == true).Count().ToString() + " / " + settings.CurrentModDirectory.ModInfoList.Count.ToString());
            }
        }

        private void ModDirectorySettingControl_DirectoryButtonPressed(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            string dir = modSettingsUserControl.SelectedDirectory;

            if (Directory.Exists(dir))
            {
                dialog.SelectedPath = dir;
            }

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                settings.CurrentModDirectoryString = dialog.SelectedPath;
                modSettingsUserControl.Directories = (settings.GetModDirectoryStrings());
                modSettingsUserControl.SelectedDirectory = (settings.CurrentModDirectoryString);
            }
        }

        private void GameDirectorySettingControl_DirectoryChanged(object sender, EventArgs e)
        {
            string gameDir = directorySettingsUserControl.GetSelectedDirectory();
            
            directorySettingsUserControl.SetInfoValue(string.Empty);

            if (settings.VerifyGameDirectory(gameDir))
            {
                settings.CurrentGameInstallationDirectory = gameDir;

                GameInstallation installation = settings.CurrentGameInstallation;

                directorySettingsUserControl.SetInfoValue(installation.Version.ToString());
            }
        }

        private void GameDirectorySettingControl_DirectoryButtonPressed(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            string dir = directorySettingsUserControl.GetSelectedDirectory();

            if (Directory.Exists(dir))
            {
                dialog.SelectedPath = dir;
            }

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                settings.CurrentGameInstallationDirectory = dialog.SelectedPath;
                directorySettingsUserControl.SetDirectories(settings.GetGameInstallationDirectories());
                directorySettingsUserControl.SetSelectedDirectory(settings.CurrentGameInstallationDirectory);
            }
        }

        private void SettingsView_CancelButtonPressed(object sender, EventArgs e)
        {
            if (isSetupState)
            {
                Application.Exit();
            }
            else
            {
                settings = new Settings();
            }
        }

        private void SettingsView_SaveAndApplyButtonPressed(object sender, EventArgs e)
        {
            if (isSetupState)
            {
                InitializeSettingsView();
            }

            settings.SaveSettings();
            settings = new Settings();

            EventAggregator.Instance.Publish(new SettingsConfiguredMessage());
        }

        private bool CheckIfSetupRequired()
        {
            bool required = false;

            GameInstallation savedInstallation = settings.CurrentGameInstallation;
            string savedModDirectory = settings.CurrentModDirectoryString;

            if (savedInstallation == null || 
                string.IsNullOrWhiteSpace(savedModDirectory) ||
                settings.GetGameInstallationDirectories().Length == 0 ||
                settings.GetModDirectories().Length == 0 ||
                !Directory.Exists(savedModDirectory)
                )
            {
            }
            else
            {
                required = false;
            }

            return required;
        }

        private void InitializeControlVariables()
        {
            GameInstallation gameInstallation = settings.CurrentGameInstallation;
            string modDir = settings.CurrentModDirectoryString;

            if (gameInstallation != null)
            {
                directorySettingsUserControl.SetSelectedDirectory(gameInstallation.DirPath);
            }
            else if (settings.GetGameInstallationDirectories().Length >= 1)
            {
                directorySettingsUserControl.SetSelectedDirectory(settings.GetGameInstallationDirectories()[0]);
            }

            if (settings.VerifyModDirectory(modDir))
            {
                modSettingsUserControl.SelectedDirectory = (modDir);
            }
            else if (settings.GetModDirectories().Length >= 1)
            {
                modSettingsUserControl.SelectedDirectory = (settings.GetModDirectoryStrings()[0]);
            }

            bool useModList = settings.UseModList;

            if (useModList)
            {

            }

            modSettingsUserControl.RadioUseModListSelected = useModList;



            modSettingsUserControl.ModList = settings.CurrentModDirectory.GetCheckedListBoxItemsModList();

        }


    }
}
