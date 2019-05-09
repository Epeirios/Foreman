using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows;
using Foreman.Views;
using Foreman.Presenters;

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

            loadingView.Tag = new LoadingPresenter(loadingView);
            settingsView.Tag = new SettingsPresenter(settingsView);

            var mainForm = new Views.MainForm(loadingView, settingsView);

            mainForm.Tag = new MainFormPresenter(mainForm);

			Application.Run(mainForm);
		}
	}
}
