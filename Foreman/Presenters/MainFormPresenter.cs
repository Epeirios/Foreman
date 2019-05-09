using Foreman.Events;
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

        public MainFormPresenter(IMainForm mainForm)
        {
            this.mainForm = mainForm;

            mainForm.MainFormLoaded += MainFormLoaded;

            mainForm.ShowSettingsView();
        }

        private void MainFormLoaded(object sender, EventArgs e)
        {
            EventAggregator.Instance.Publish(new MainFormLoadedMessage());
        }
    }
}
