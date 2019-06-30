using Foreman.Events;
using Foreman.Views;
using System;

namespace Foreman.Presenters
{
    public class MainWindowPresenter
    {
        IMainWindow mainForm;

        public MainWindowPresenter(IMainWindow mainForm)
        {
            this.mainForm = mainForm;

            mainForm.MainWindowLoaded += MainFormLoaded;

            EventAggregator.Instance.Subscribe<SetupRequiredMessage>(m =>
            {
                mainForm.ShowSettingsView();
            });

            EventAggregator.Instance.Subscribe<SettingsConfiguredMessage>(m =>
            {
                mainForm.ShowLoadingView();
            });
        }

        private void MainFormLoaded(object sender, EventArgs e)
        {
            EventAggregator.Instance.Publish(new MainFormLoadedMessage());
        }
    }
}
