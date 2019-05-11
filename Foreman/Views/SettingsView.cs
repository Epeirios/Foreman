using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Foreman.Views.Controls;

namespace Foreman.Views
{
    public partial class SettingsView : UserControl, ISettingsView
    {
        public SettingsView()
        {
            InitializeComponent();
        }

        public event EventHandler SaveAndApplyButtonPressed;
        public event EventHandler CancelButtonPressed;

        public void SetCancelButtonText(string text)
        {
            throw new NotImplementedException();
        }

        public void SetSaveAndApplyButtonText(string text)
        {
            throw new NotImplementedException();
        }

        public void SetSettingsControls(ISettingsControl[] settingsControls)
        {
            throw new NotImplementedException();
        }

        public void SetSettingsLabel(string text)
        {
            throw new NotImplementedException();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }

        private void buttonSaveAndApply_Click(object sender, EventArgs e)
        {

        }
    }
}
