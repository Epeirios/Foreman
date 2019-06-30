using System;
using System.Windows.Forms;
using Foreman.Presenters;
using Foreman.BusinessLogic;
using Foreman.Views.UserControls;
using Foreman.Views;

namespace Foreman
{
    static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

            var loadingView = new LoadingView();
            var settingsView = new SettingsView();

            var propertiesManager = new PropertiesManager();

            var modSettingsUserControl = new ModSettingsUserControl();
            var languageSettingsUserControl = new LanguageSettingsUserControl();
            var directorySettingsUserControl = new DirectorySettingUserControl();

            loadingView.Tag = new LoadingPresenter(loadingView);
            settingsView.Tag = new SettingsPresenter(settingsView, modSettingsUserControl, directorySettingsUserControl, languageSettingsUserControl);

            var mainForm = new Views.MainForm(loadingView, settingsView);

            mainForm.Tag = new MainWindowPresenter(mainForm);

            Application.Run(mainForm);
		}
	}
}
