using Foreman.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foreman.Presenters
{
    public class MainFormPresenter
    {
        IMainForm mainForm;
        LoadingPresenter loadingPresenter;

        public MainFormPresenter(IMainForm mainForm, LoadingPresenter loadingPresenter)
        {
            this.mainForm = mainForm;
            this.loadingPresenter = loadingPresenter;

            mainForm.ShowLoadingView();
        }
    }
}
