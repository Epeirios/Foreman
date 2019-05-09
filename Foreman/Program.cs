using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows;
using Foreman.Views;
using Foreman.Presenters;
using Foreman.BusinessLogic;

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

            var gameDirectoriesFinder = new GameDirectoriesManager();
            var propertiesManager = new PropertiesManager();

            loadingView.Tag = new LoadingPresenter(loadingView);
            settingsView.Tag = new SettingsPresenter(settingsView, gameDirectoriesFinder);

            var mainForm = new Views.MainForm(loadingView, settingsView);

            mainForm.Tag = new MainFormPresenter(mainForm);

            propertiesManager.SetupProperties();

            Application.Run(mainForm);
		}
	}
}
