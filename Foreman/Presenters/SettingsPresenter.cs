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

        private ISettingsView settingsView;
        private ISettingsManager settingsManager;

        private IDirectorySettingControl gameDirectorySettingControl;
        private IDirectorySettingControl modDirectorySettingControl;
        private ILanguageSettingControl languageSettingControl;

        public SettingsPresenter(ISettingsView settingsView, ISettingsManager settingsManager)
        {
            this.settingsView = settingsView;
            this.settingsManager = settingsManager;

            gameDirectorySettingControl = new DirectorySettingControl();
            modDirectorySettingControl = new DirectorySettingControl();
            languageSettingControl = new LanguageSettingControl();

            gameDirectorySettingControl.DirectoryButtonPressed += GameDirectorySettingControl_DirectoryButtonPressed;
            gameDirectorySettingControl.DirectoryChanged += GameDirectorySettingControl_DirectoryChanged;
            gameDirectorySettingControl.SetDirectotyLabel("Game directory");
            gameDirectorySettingControl.SetInfoLabel("Game version");
            gameDirectorySettingControl.SetInfoValue(string.Empty);
            gameDirectorySettingControl.SetDirectories(settingsManager.GetFoundInstallationDirectories());
            
            modDirectorySettingControl.DirectoryButtonPressed += ModDirectorySettingControl_DirectoryButtonPressed;
            modDirectorySettingControl.DirectoryChanged += ModDirectorySettingControl_DirectoryChanged;
            modDirectorySettingControl.SetDirectotyLabel("Mod directory");
            modDirectorySettingControl.SetInfoLabel("Mods in mods folder");
            modDirectorySettingControl.SetInfoValue(string.Empty);
            modDirectorySettingControl.SetDirectories(settingsManager.GetFoundModDirectories());

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

            if (Directory.Exists(selectedModDir))
            {
                if (Path.GetFileName(selectedModDir) == "Factorio")
                {
                    if (Directory.Exists(Path.Combine(selectedModDir, "mods")))
                    {
                        modDirectorySettingControl.SetSelectedDirectory(Path.Combine(selectedModDir, "mods"));
                    }
                }
                else if (Path.GetFileName(selectedModDir) == "mods")
                {
                    if (Directory.GetParent(selectedModDir).Name == "Factorio")
                    {
                        List<string> modFiles = new List<string>();
                        string[] files = Directory.GetFiles(selectedModDir);

                        foreach (var file in files)
                        {
                            if (Path.GetExtension(file) == ".zip")
                            {
                                modFiles.Add(file);
                            }
                        }

                        modDirectorySettingControl.SetInfoValue(modFiles.Count.ToString());

                        settingsManager.CurrentModDirectory = selectedModDir;
                    }
                }
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
                modDirectorySettingControl.SetSelectedDirectory(dialog.SelectedPath);
            }
        }

        private void GameDirectorySettingControl_DirectoryChanged(object sender, EventArgs e)
        {
            GameInstallation installation = settingsManager.GetGameInstalationFromDir(gameDirectorySettingControl.GetSelectedDirectory());
            
            gameDirectorySettingControl.SetInfoValue(string.Empty);

            if (installation != null)
            {
                gameDirectorySettingControl.SetInfoValue(installation.Version.ToString());

                settingsManager.CurrentGameInstallation = installation;
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
                gameDirectorySettingControl.SetSelectedDirectory(dialog.SelectedPath);
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

            }
        }

        private void SettingsView_SaveAndApplyButtonPressed(object sender, EventArgs e)
        {
            if (isSetupState)
            {
                isSetupState = false;
            }            
        }

        private void CheckIfSetupRequired()
        {
            GameInstallation savedInstallation = settingsManager.CurrentGameInstallation;
            string savedModDirectory = settingsManager.CurrentModDirectory;

            if (savedInstallation == null || 
                string.IsNullOrWhiteSpace(savedModDirectory) ||
                settingsManager.GetFoundInstallationDirectories().Length == 0 ||
                settingsManager.GetFoundModDirectories().Length == 0 ||
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
            GameInstallation gameInstallation = settingsManager.CurrentGameInstallation;
            string modDir = settingsManager.CurrentModDirectory;

            if (gameInstallation != null)
            {
                gameDirectorySettingControl.SetSelectedDirectory(gameInstallation.DirPath);
            }
            else if (settingsManager.GetFoundInstallationDirectories().Length >= 1)
            {
                gameDirectorySettingControl.SetSelectedDirectory(settingsManager.GetFoundInstallationDirectories()[0]);
            }

            if (Directory.Exists(modDir))
            {
                modDirectorySettingControl.SetSelectedDirectory(modDir);
            }
            else if (settingsManager.GetFoundModDirectories().Length >= 1)
            {
                modDirectorySettingControl.SetSelectedDirectory(settingsManager.GetFoundModDirectories()[0]);
            }
        }
    }
}
