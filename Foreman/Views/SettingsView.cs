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

        public IFactorioGameDirectoryControl FactorioGameDirectoryControl { get { return factorioGameDicrectoryControl2; } }
        public IFactorioModDirectoryControl FactorioModDirectoryControl { get { return factorioModDirectoryControl2; } }

        public event EventHandler SaveButtonPressed;

        private void buttonSaveSettings_Click(object sender, EventArgs e)
        {
            SaveButtonPressed(this, new EventArgs());
        }
    }
}
