using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foreman.Views.Controls
{
    public interface IDirectorySettingControl : ISettingsControl
    {
        event EventHandler DirectoryButtonPressed;
        event EventHandler DirectoryChanged;

        void SetInfoLabel(string text);
        void SetInfoValue(string value);
        void SetDirectotyLabel(string directory);
        string GetSelectedDirectory();
        void SetSelectedDirectory(string selectedDirectory);
        void SetDirecties(string[] directories);
    }
}
