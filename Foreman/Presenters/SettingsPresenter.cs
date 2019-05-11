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
        private IGameDirectoriesManager gameDirectoriesManager;

        private string currentGameDirectory;
        private string currentModDirectory;
        private string currentLanguage;

        public SettingsPresenter(ISettingsView settingsView, IGameDirectoriesManager gameDirectoriesManager)
        {
            this.settingsView = settingsView;
            this.gameDirectoriesManager = gameDirectoriesManager;

            currentGameDirectory = gameDirectoriesManager.GetCurrentGameDirectory();
            currentModDirectory = gameDirectoriesManager.GetCurrentModDirectory();
            currentLanguage = Properties.Settings.Default.Language;

            IDirectorySettingControl gameDirectorySettingControl = new DirectorySettingControl();
            gameDirectorySettingControl.SetDirectotyLabel("Game directory");
            gameDirectorySettingControl.SetInfoLabel("Game version");
            //gameDirectorySettingControl.SetDirecties();

            IDirectorySettingControl modDirectorySettingControl = new DirectorySettingControl();
            modDirectorySettingControl.SetDirectotyLabel("Mod directory");
            modDirectorySettingControl.SetInfoLabel("Mods in modlist");

            ILanguageSettingControl languageSettingControl = new LanguageSettingControl();

            ISettingsControl[] settingsControls =
            {
                gameDirectorySettingControl,
                modDirectorySettingControl,
                languageSettingControl
            };

            settingsView.SaveAndApplyButtonPressed += SettingsView_SaveAndApplyButtonPressed;
            settingsView.CancelButtonPressed += SettingsView_CancelButtonPressed;
            settingsView.SetCancelButtonText("Cancel");
            settingsView.SetSaveAndApplyButtonText("Save and Apply");
            settingsView.SetSettingsLabel("Settings");
            settingsView.SetSettingsControls(settingsControls);

            settingsView.FactorioGameDirectoryControl.RadioButtonChanged += FactorioGameDirectoryControl_RadioButtonChanged;
            settingsView.FactorioGameDirectoryControl.ManualDirectoryNavigateButtonPressed += FactorioGameDirectoryControl_ManualDirectoryNavigateButtonPressed;
            settingsView.FactorioGameDirectoryControl.ManualDirectoryChanged += FactorioGameDirectoryControl_ManualDirectoryChanged;
            settingsView.FactorioGameDirectoryControl.SelectedFoundDirectoryChanged += FactorioGameDirectoryControl_SelectedFoundDirectoryChanged;

            EventAggregator.Instance.Subscribe<MainFormLoadedMessage>(m => SetupDirs());
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
            FoundInstallation[] gameDirectories = gameDirectoriesManager.GameDirectories;
            string[] modDirectories = gameDirectoriesManager.ModDirectories;

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
