using Foreman.BusinessLogic;
using Foreman.Events;
using Foreman.Views;
using Foreman.Views.Controls;
using Foreman.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Foreman.Presenters
{
    public class SettingsPresenter
    {
        private bool isSetupState = false;

        private Settings settings;

        private ISettingsView settingsView;

        private IDirectorySettingControl gameDirectorySettingControl;
        private IDirectorySettingControl modDirectorySettingControl;
        private ILanguageSettingControl languageSettingControl;

        public SettingsPresenter(ISettingsView settingsView)
        {
            this.settingsView = settingsView;

            gameDirectorySettingControl = new DirectorySettingControl();
            modDirectorySettingControl = new DirectorySettingControl();
            languageSettingControl = new LanguageSettingControl();

            settings = new Settings();

            gameDirectorySettingControl.DirectoryButtonPressed += GameDirectorySettingControl_DirectoryButtonPressed;
            gameDirectorySettingControl.DirectoryChanged += GameDirectorySettingControl_DirectoryChanged;
            gameDirectorySettingControl.SetDirectotyLabel("Game directory");
            gameDirectorySettingControl.SetInfoLabel("Game version");
            gameDirectorySettingControl.SetInfoValue(string.Empty);
            gameDirectorySettingControl.SetDirectories(settings.GetGameInstallationDirectories());
            
            modDirectorySettingControl.DirectoryButtonPressed += ModDirectorySettingControl_DirectoryButtonPressed;
            modDirectorySettingControl.DirectoryChanged += ModDirectorySettingControl_DirectoryChanged;
            modDirectorySettingControl.SetDirectotyLabel("Mod directory");
            modDirectorySettingControl.SetInfoLabel("Mods in mods folder");
            modDirectorySettingControl.SetInfoValue(string.Empty);
            modDirectorySettingControl.SetDirectories(settings.GetModDirectories());

            languageSettingControl.SetLabel("Language");

            ISettingsControl[] settingsControls =
            {
                gameDirectorySettingControl,
                modDirectorySettingControl                
            };

            settingsView.SaveAndApplyButtonPressed += SettingsView_SaveAndApplyButtonPressed;
            settingsView.CancelButtonPressed += SettingsView_CancelButtonPressed;
            settingsView.SetSettingsControls(settingsControls);
            settingsView.SetCancelButtonText("Cancel");
            settingsView.SetSaveAndApplyButtonText("Save and Apply");

            EventAggregator.Instance.Subscribe<MainFormLoadedMessage>(m =>
            {
                CheckIfSetupRequired();
                SetupControls();
             });
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
            string selectedModDir = modDirectorySettingControl.GetSelectedDirectory();

            modDirectorySettingControl.SetInfoValue(string.Empty);

            if (settings.VerifyModDirectory(selectedModDir))
            {
                settings.CurrentModDirectory = selectedModDir;

                List<string> modFiles = new List<string>();
                string[] files = Directory.GetFiles(settings.CurrentModDirectory);

                foreach (var file in files)
                {
                    if (Path.GetExtension(file) == ".zip")
                    {
                        modFiles.Add(file);
                    }
                }

                modDirectorySettingControl.SetInfoValue(modFiles.Count.ToString());
            }
        }

        private void ModDirectorySettingControl_DirectoryButtonPressed(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            string dir = modDirectorySettingControl.GetSelectedDirectory();

            if (Directory.Exists(dir))
            {
                dialog.SelectedPath = dir;
            }

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                settings.CurrentModDirectory = dialog.SelectedPath;
                modDirectorySettingControl.SetDirectories(settings.GetModDirectories());
                modDirectorySettingControl.SetSelectedDirectory(settings.CurrentModDirectory);
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
        }

        private void CheckIfSetupRequired()
        {
            GameInstallation savedInstallation = settings.CurrentGameInstallation;
            string savedModDirectory = settings.CurrentModDirectory;

            if (savedInstallation == null || 
                string.IsNullOrWhiteSpace(savedModDirectory) ||
                settings.GetGameInstallationDirectories().Length == 0 ||
                settings.GetModDirectories().Length == 0 ||
                !Directory.Exists(savedModDirectory)
                )
            {
                InitializeSetupView();
            }
            else
            {
                InitializeSettingsView();
            }
        }

        private void SetupControls()
        {
            GameInstallation gameInstallation = settings.CurrentGameInstallation;
            string modDir = settings.CurrentModDirectory;

            if (gameInstallation != null)
            {
                gameDirectorySettingControl.SetSelectedDirectory(gameInstallation.DirPath);
            }
            else if (settings.GetGameInstallationDirectories().Length >= 1)
            {
                gameDirectorySettingControl.SetSelectedDirectory(settings.GetGameInstallationDirectories()[0]);
            }

            if (Directory.Exists(modDir))
            {
                modDirectorySettingControl.SetSelectedDirectory(modDir);
            }
            else if (settings.GetModDirectories().Length >= 1)
            {
                modDirectorySettingControl.SetSelectedDirectory(settings.GetModDirectories()[0]);
            }
        }
    }
}
