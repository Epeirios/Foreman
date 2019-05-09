using System;

namespace Foreman.Views.Controls
{
    public interface IFactorioGameDirectoryControl
    {
        string ManualDir { get; set; }
        Version ManualDirVersion { get; set; }
        Version FoundDirVersion { get; set; }
        string SelectedDir { set; get; }

        void RadioButtonFocus(RadioButtonStatesEnum radioButtonStatesEnum);
        void SetFoundGameDirectories(string[] foundInstallations);
        void RadioButtonToggleEnabled(RadioButtonStatesEnum radioButton, bool enabled);

        event EventHandler<StringEventArgs> SelectedFoundDirectoryChanged;
        event EventHandler<StringEventArgs> ManualDirectoryChanged;
        event EventHandler<StringEventArgs> ManualDirectoryNavigateButtonPressed;
        event EventHandler<RadioButtonEventArgs> RadioButtonChanged;
    }
}
