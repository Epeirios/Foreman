using Foreman.Models.ControlModels;
using System;
using System.Windows.Forms;

namespace Foreman.Views.UserControls
{
    public interface IModSettingsUserControl : ISettingsUserControl
    {
        event EventHandler DirectoryButtonPressed;
        event EventHandler DirectoryChanged;
        event EventHandler RadioButtonChanged;
        event EventHandler SelectedModChanged;
        event EventHandler CheckedModsChanged;

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
        //TreeNode[] ModInfoProperties { set; }
        bool CustomModSelectionEnabled { set; }
    }
}
