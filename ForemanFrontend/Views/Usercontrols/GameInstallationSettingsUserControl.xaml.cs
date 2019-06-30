using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Foreman.Views.UserControls;

namespace ForemanFrontend.Views.Usercontrols
{
    /// <summary>
    /// Interaction logic for GameInstallationSettingsUserControl.xaml
    /// </summary>
    public partial class GameInstallationSettingsUserControl : UserControl, IDirectorySettingsUserControl, ISettingsUserControl
    {
        public GameInstallationSettingsUserControl()
        {
            InitializeComponent();
        }

        public event EventHandler DirectoryButtonPressed;
        public event EventHandler DirectoryChanged;

        public string GetSelectedDirectory()
        {
            throw new NotImplementedException();
        }

        public void SetDirectories(string[] directories)
        {
            throw new NotImplementedException();
        }

        public void SetDirectotyLabel(string text)
        {
            throw new NotImplementedException();
        }

        public void SetInfoLabel(string text)
        {
            throw new NotImplementedException();
        }

        public void SetInfoValue(string value)
        {
            throw new NotImplementedException();
        }

        public void SetSelectedDirectory(string selectedDirectory)
        {
            throw new NotImplementedException();
        }
    }
}
