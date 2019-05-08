using Foreman.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foreman.Presenters
{
    public class LoadingPresenter
    {
        private ILoadingView loadingview;

        public LoadingPresenter(ILoadingView loadingview)
        {
            this.loadingview = loadingview;

            loadingview.SetLoadingText("dit is een test");
            loadingview.SetProgress(50);
        }
    }
}
