using System;
using System.Windows;
using System.Windows.Controls;
using Foreman;
using Foreman.BusinessLogic;
using Foreman.Presenters;
using Foreman.Views;
using Foreman.Views.UserControls;
using ForemanFrontend.Views;

namespace ForemanFrontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindow
    {
        //ForemanFrontend.Views LoadingView loadingView;
        ForemanFrontend.Views.Usercontrols.SettingsView settingsView;

        public MainWindow()
        {
            InitializeComponent();

            //loadingView = new LoadingView();
            settingsView = new ForemanFrontend.Views.Usercontrols.SettingsView();

            var propertiesManager = new PropertiesManager();

            var modSettingsUserControl = new ForemanFrontend.Views.Usercontrols.ModSettingsUserControl();
            var languageSettingsUserControl = new ForemanFrontend.Views.Usercontrols.LanguageSettingsUserControl();
            var gameInstallationSettingsUserControl = new ForemanFrontend.Views.Usercontrols.GameInstallationSettingsUserControl();

            //loadingView.Tag = new LoadingPresenter(loadingView);
            settingsView.Tag = new SettingsPresenter((ISettingsView)settingsView, modSettingsUserControl, gameInstallationSettingsUserControl, languageSettingsUserControl);

            var mainWindowPresenter = new MainWindowPresenter(this);
        }

        public event EventHandler MainWindowLoaded;

        public void ShowLoadingView()
        {
            GridMainView.Children.Add(settingsView);
        }

        public void ShowSettingsView()
        {
            throw new NotImplementedException();
        }
    }
}
