using Foreman.Views.Controls;
using System;

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
