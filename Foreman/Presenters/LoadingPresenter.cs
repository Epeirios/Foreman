using Foreman.Events;
using Foreman.Views;

namespace Foreman.Presenters
{
    public class LoadingPresenter
    {
        private ILoadingView loadingview;

        public LoadingPresenter(ILoadingView loadingview)
        {
            this.loadingview = loadingview;

            loadingview.SetLoadingText("Loading game data");
            loadingview.SetProgress(0);

            EventAggregator.Instance.Subscribe<SettingsConfiguredMessage>(m =>
            {
                SetupView();
            });
        }

        private void SetupView()
        {
            loadingview.SetProgress(0);
        }
    }
}
