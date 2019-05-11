using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foreman.Views.Controls
{
    public partial class DirectorySettingControl : UserControl, IDirectorySettingControl
    {
        public DirectorySettingControl()
        {
            InitializeComponent();
        }

        public event EventHandler DirectoryButtonPressed;
        public event EventHandler DirectoryChanged;

        public string GetSelectedDirectory()
        {
            throw new NotImplementedException();
        }

        public void SetDirecties(string[] directories)
        {
            throw new NotImplementedException();
        }

        public void SetDirectotyLabel(string directory)
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
