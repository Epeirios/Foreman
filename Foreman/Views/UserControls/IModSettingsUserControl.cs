using Foreman.Models.ControlModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Foreman.Views.Controls
{
    public interface IModSettingsControl : ISettingsControl
    {
        event EventHandler DirectoryButtonPressed;
        event EventHandler DirectoryChanged;
        event EventHandler RadioButtonChanged;
        event EventHandler SelectedModChanged;

        string InfoLabel { set; }
        string InfoValue { set; }
        string DirectoryLabel { set; }
        string SelectedDirectory { get; set; }
        string[] Directories { set; }
        string RadioModListLabel { set; }
        string RadioCustomListLabel { set; }
        bool RadioUseModListSelected { get; set; }
        CheckedModListBoxItem[] ModList { set; get; }
        string SelectedMod { get; }
        TreeNode ModProperties { set; }
        bool CustomModSelectionEnabled { set; }
    }
}
