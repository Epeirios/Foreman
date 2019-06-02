using Foreman.BusinessLogic;
using Foreman.Events;
using Foreman.Views;
using Foreman.Views.Controls;
using Foreman.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Foreman.Models.ControlModels;

namespace Foreman.Presenters
{
    public class SettingsPresenter
    {
        private bool isSetupState = false;

        private Settings settings;

        private ISettingsView settingsView;

        private IDirectorySettingControl gameDirectorySettingControl;
        private IModSettingsControl modSettingsControl;
        private ILanguageSettingsControl languageSettingControl;

        public SettingsPresenter(ISettingsView settingsView)
        {
            this.settingsView = settingsView;

            gameDirectorySettingControl = new DirectorySettingControl();
            modSettingsControl = new ModSettingsControl();
            languageSettingControl = new LanguageSettingsControl();

            settings = new Settings();

            gameDirectorySettingControl.DirectoryButtonPressed += GameDirectorySettingControl_DirectoryButtonPressed;
            gameDirectorySettingControl.DirectoryChanged += GameDirectorySettingControl_DirectoryChanged;
            gameDirectorySettingControl.SetDirectotyLabel("Game directory");
            gameDirectorySettingControl.SetInfoLabel("Game version");
            gameDirectorySettingControl.SetInfoValue(string.Empty);
            gameDirectorySettingControl.SetDirectories(settings.GetGameInstallationDirectories());
            
            modSettingsControl.DirectoryButtonPressed += ModDirectorySettingControl_DirectoryButtonPressed;
            modSettingsControl.DirectoryChanged += ModDirectorySettingControl_DirectoryChanged;
            modSettingsControl.RadioButtonChanged += ModSettingsControl_RadioButtonChanged;
            modSettingsControl.SelectedModChanged += ModSettingsControl_SelectedModChanged;
            modSettingsControl.DirectoryLabel = "Mod directory";
            modSettingsControl.InfoLabel = ("Mods in mods folder");
            modSettingsControl.RadioModListLabel = "Use modlist";
            modSettingsControl.RadioCustomListLabel = "Custom modlist";
            modSettingsControl.InfoValue = (string.Empty);
            modSettingsControl.Directories = settings.GetModDirectoryStrings();

            languageSettingControl.SetLabel("Language");

            ISettingsControl[] settingsControls =
            {
                gameDirectorySettingControl,
                modSettingsControl                
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

        private void ModSettingsControl_SelectedModChanged(object sender, EventArgs e)
        {
            string selectedModName = modSettingsControl.SelectedMod;


        }

        private void ModSettingsControl_RadioButtonChanged(object sender, EventArgs e)
        {
            modSettingsControl.CustomModSelectionEnabled = !modSettingsControl.RadioUseModListSelected;
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
            string selectedModDir = modSettingsControl.SelectedDirectory;

            modSettingsControl.InfoValue = (string.Empty);

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

                modSettingsControl.InfoValue = (modFiles.Count.ToString());
            }
        }

        private void ModDirectorySettingControl_DirectoryButtonPressed(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            string dir = modSettingsControl.SelectedDirectory;

            if (Directory.Exists(dir))
            {
                dialog.SelectedPath = dir;
            }

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                settings.CurrentModDirectoryString = dialog.SelectedPath;
                modSettingsControl.Directories = (settings.GetModDirectoryStrings());
                modSettingsControl.SelectedDirectory = (settings.CurrentModDirectoryString);
            }
        }

        private void GameDirectorySettingControl_DirectoryChanged(object sender, EventArgs e)
        {
            string gameDir = gameDirectorySettingControl.GetSelectedDirectory();
            
            gameDirectorySettingControl.SetInfoValue(string.Empty);

            if (settings.VerifyGameDirectory(gameDir))
            {
                settings.CurrentGameInstallationDirectory = gameDir;

                GameInstallation installation = settings.CurrentGameInstallation;

                gameDirectorySettingControl.SetInfoValue(installation.Version.ToString());
            }
        }

        private void GameDirectorySettingControl_DirectoryButtonPressed(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            string dir = gameDirectorySettingControl.GetSelectedDirectory();

            if (Directory.Exists(dir))
            {
                dialog.SelectedPath = dir;
            }

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                settings.CurrentGameInstallationDirectory = dialog.SelectedPath;
                gameDirectorySettingControl.SetDirectories(settings.GetGameInstallationDirectories());
                gameDirectorySettingControl.SetSelectedDirectory(settings.CurrentGameInstallationDirectory);
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
                gameDirectorySettingControl.SetSelectedDirectory(gameInstallation.DirPath);
            }
            else if (settings.GetGameInstallationDirectories().Length >= 1)
            {
                gameDirectorySettingControl.SetSelectedDirectory(settings.GetGameInstallationDirectories()[0]);
            }

            if (settings.VerifyModDirectory(modDir))
            {
                modSettingsControl.SelectedDirectory = (modDir);
            }
            else if (settings.GetModDirectories().Length >= 1)
            {
                modSettingsControl.SelectedDirectory = (settings.GetModDirectoryStrings()[0]);
            }

            bool useModList = settings.UseModList;

            if (useModList)
            {

            }

            modSettingsControl.RadioUseModListSelected = useModList;



            modSettingsControl.ModList = settings.CurrentModDirectory.GetCheckedListBoxItemsModList();

        }


    }
}
