using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foreman.Views
{
    public interface IMainWindow
    {
        void ShowLoadingView();
        void ShowSettingsView();

        event EventHandler MainWindowLoaded;
    }
}
