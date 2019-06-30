using Foreman.Models.ControlModels;
using System;
using System.Windows.Controls;
using Foreman.Views.UserControls;

namespace ForemanFrontend.Views.Usercontrols
{
    /// <summary>
    /// Interaction logic for ModSettingsUserControl.xaml
    /// </summary>
    public partial class ModSettingsUserControl : UserControl, IModSettingsUserControl, ISettingsUserControl
    {
        public event EventHandler DirectoryButtonPressed;
        public event EventHandler DirectoryChanged;
        public event EventHandler RadioButtonChanged;
        public event EventHandler SelectedModChanged;
        public event EventHandler CheckedModsChanged;

        public ModSettingsUserControl()
        {
            InitializeComponent();
        }

        public string InfoLabel { set => throw new NotImplementedException(); }
        public string InfoValue { set => throw new NotImplementedException(); }
        public string DirectoryLabel { set => throw new NotImplementedException(); }
        public string SelectedDirectory { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string[] Directories { set => throw new NotImplementedException(); }
        public string RadioModListLabel { set => throw new NotImplementedException(); }
        public string RadioCustomListLabel { set => throw new NotImplementedException(); }
        public bool RadioUseModListSelected { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public CheckedModListBoxItem[] ModList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string SelectedMod => throw new NotImplementedException();
        
        public bool CustomModSelectionEnabled { set => throw new NotImplementedException(); }
    }
}
