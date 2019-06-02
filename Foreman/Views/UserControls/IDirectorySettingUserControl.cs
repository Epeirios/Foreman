using System;

namespace Foreman.Views.Controls
{
    public interface IDirectorySettingControl : ISettingsControl
    {
        event EventHandler DirectoryButtonPressed;
        event EventHandler DirectoryChanged;

        void SetInfoLabel(string text);
        void SetInfoValue(string value);
        void SetDirectotyLabel(string text);
        string GetSelectedDirectory();
        void SetSelectedDirectory(string selectedDirectory);
        void SetDirectories(string[] directories);
    }
}
