using System;
using System.Windows.Forms;
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

            var propertiesManager = new PropertiesManager();

            loadingView.Tag = new LoadingPresenter(loadingView);
            settingsView.Tag = new SettingsPresenter(settingsView);

            var mainForm = new Views.MainForm(loadingView, settingsView);

            mainForm.Tag = new MainFormPresenter(mainForm);

            Application.Run(mainForm);
		}
	}
}
