using Foreman.BusinessLogic;
using Foreman.Events;
using Foreman.Views;
using Foreman.Views.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Foreman.Presenters
{
    public class SettingsPresenter
    {
        private ISettingsView settingsView;
        private ISettingsManager settingsManager;

        private IDirectorySettingControl gameDirectorySettingControl;
        private IDirectorySettingControl modDirectorySettingControl;
        private ILanguageSettingControl languageSettingControl;

        private FoundInstallation currentGameDirectory;
        private string currentModDirectory;
        private string currentLanguage;

        private FoundInstallation[] gameDirectories;
        private string[] modDirectories;
        private string[] languages;

        public SettingsPresenter(ISettingsView settingsView, ISettingsManager settingsManager)
        {
            this.settingsView = settingsView;
            this.settingsManager = settingsManager;

            gameDirectorySettingControl = new DirectorySettingControl();
            modDirectorySettingControl = new DirectorySettingControl();
            languageSettingControl = new LanguageSettingControl();

            PreInitalize();

            if (true)
            {

            }

            EventAggregator.Instance.Subscribe<MainFormLoadedMessage>(m => SetupDirs());
        }

        private void PreInitalize()
        {
            currentGameDirectory = settingsManager.GetCurrentGameDirectory();
            currentModDirectory = settingsManager.GetCurrentModDirectory();
            currentLanguage = settingsManager.GetCurrentLanguage();

            gameDirectories = settingsManager.GetSavedGameDirectories();
            modDirectories = settingsManager.GetSavedModDirectories();
            
            gameDirectorySettingControl.DirectoryButtonPressed += GameDirectorySettingControl_DirectoryButtonPressed;
            gameDirectorySettingControl.DirectoryChanged += GameDirectorySettingControl_DirectoryChanged;
            gameDirectorySettingControl.SetDirectotyLabel("Game directory");
            gameDirectorySettingControl.SetInfoLabel("Game version");
            
            modDirectorySettingControl.DirectoryButtonPressed += ModDirectorySettingControl_DirectoryButtonPressed;
            modDirectorySettingControl.DirectoryChanged += ModDirectorySettingControl_DirectoryChanged;
            modDirectorySettingControl.SetDirectotyLabel("Mod directory");
            modDirectorySettingControl.SetInfoLabel("Mods in modlist");
            
            languageSettingControl.SetLabel("Language");

            ISettingsControl[] settingsControls =
            {
                gameDirectorySettingControl,
                modDirectorySettingControl,
                languageSettingControl
            };

            settingsView.SaveAndApplyButtonPressed += SettingsView_SaveAndApplyButtonPressed;
            settingsView.CancelButtonPressed += SettingsView_CancelButtonPressed;
            settingsView.SetSettingsControls(settingsControls);
            settingsView.SetCancelButtonText("Cancel");
            settingsView.SetSaveAndApplyButtonText("Save and Apply");
        }

        private void InitializeSetup()
        {
            settingsView.SetSettingsLabel("Setup");
        }

        private void InitializeSettings()
        {
            settingsView.SetSettingsLabel("Settings");
        }

        private void ModDirectorySettingControl_DirectoryChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ModDirectorySettingControl_DirectoryButtonPressed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void GameDirectorySettingControl_DirectoryChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void GameDirectorySettingControl_DirectoryButtonPressed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SettingsView_CancelButtonPressed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SettingsView_SaveAndApplyButtonPressed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SettingsView_SaveButtonPressed(object sender, EventArgs e)
        {
            if (currentGameDirectory != null)
            {
                Properties.Settings.Default.FactorioPath = currentGameDirectory;
            }

            if (currentModDirectory != null)
            {
                Properties.Settings.Default.FactorioPath = currentModDirectory;
            }
        }

        private void FactorioGameDirectoryControl_SelectedFoundDirectoryChanged(object sender, StringEventArgs e)
        {
            FoundInstallation inst = FoundInstallation.GetInstallationFromPath(e.Value);

            if (inst != null)
            {
                currentGameDirectory = inst.DirPath;
                settingsView.FactorioGameDirectoryControl.FoundDirVersion = inst.Version;
            }
            else
            {
                settingsView.FactorioGameDirectoryControl.FoundDirVersion = new Version("0.0.0");
            }
        }

        private void FactorioGameDirectoryControl_ManualDirectoryChanged(object sender, StringEventArgs e)
        {
            FoundInstallation inst = FoundInstallation.GetInstallationFromPath(e.Value);

            if (inst != null)
            {
                settingsView.FactorioGameDirectoryControl.ManualDirVersion = inst.Version;
            }
            else
            {
                settingsView.FactorioGameDirectoryControl.ManualDirVersion = new Version("0.0.0");
            }
        }

        private void FactorioGameDirectoryControl_ManualDirectoryNavigateButtonPressed(object sender, StringEventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (Directory.Exists(e.Value))
                {
                    dialog.SelectedPath = e.Value;
                }
                var result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    settingsView.FactorioGameDirectoryControl.ManualDir = dialog.SelectedPath;
                }
            }
        }

        private void FactorioGameDirectoryControl_RadioButtonChanged(object sender, RadioButtonEventArgs e)
        {
            settingsView.FactorioGameDirectoryControl.RadioButtonFocus(e.RadioButtonStatesEnum);
        }

        private void SetupDirs()
        {
            FoundInstallation[] gameDirectories = settingsManager.GameDirectories;
            string[] modDirectories = settingsManager.ModDirectories;

            if (currentGameDirectory != null && currentModDirectory != null)
            {
                //TODO skip settings screen
            }

            if (gameDirectories.Length == 0)
            {
                settingsView.FactorioGameDirectoryControl.RadioButtonFocus(RadioButtonStatesEnum.manualDirectory);
                settingsView.FactorioGameDirectoryControl.RadioButtonToggleEnabled(RadioButtonStatesEnum.foundDirectories, false);
            }
            else
            {
                List<string> strGameDirs = new List<string>();

                foreach (var item in gameDirectories)
                {
                    strGameDirs.Add(item.DirPath);
                }

                settingsView.FactorioGameDirectoryControl.SetFoundGameDirectories(strGameDirs.ToArray());
                settingsView.FactorioGameDirectoryControl.RadioButtonFocus(RadioButtonStatesEnum.foundDirectories);
                settingsView.FactorioGameDirectoryControl.SelectedDir = strGameDirs[0];
            }

            if (currentGameDirectory != null)
            {
                settingsView.FactorioGameDirectoryControl.ManualDir = currentGameDirectory;
            }
        }
    }
}
