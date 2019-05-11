using Foreman.Views.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foreman.Views
{
    public interface ISettingsView
    {
        event EventHandler SaveAndApplyButtonPressed;
        event EventHandler CancelButtonPressed;

        void SetSettingsControls(ISettingsControl[] settingsControls);
        void SetCancelButtonText(string text);
        void SetSaveAndApplyButtonText(string text);
        void SetSettingsLabel(string text);
    }
}
