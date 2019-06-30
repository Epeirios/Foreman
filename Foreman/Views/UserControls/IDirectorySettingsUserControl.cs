using System;

namespace Foreman.Views.UserControls
{
    public interface IDirectorySettingsUserControl : ISettingsUserControl
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
