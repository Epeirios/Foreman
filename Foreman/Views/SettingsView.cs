using System;
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
            buttonCancel.Text = text;
        }

        public void SetSaveAndApplyButtonText(string text)
        {
            buttonSaveAndApply.Text = text;
        }

        public void SetSettingsControls(ISettingsControl[] settingsControls)
        {
            tableLayoutPanel1.Controls.Clear();

            for (int i = 0; i < settingsControls.Length; i++)
            {
                tableLayoutPanel1.Controls.Add((Control)settingsControls[i], 3 + (i * 2), 1);
            }
        }

        public void SetSettingsLabel(string text)
        {
            labelSettingsLabel.Text = text;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            CancelButtonPressed(this, new EventArgs());
        }

        private void buttonSaveAndApply_Click(object sender, EventArgs e)
        {
            SaveAndApplyButtonPressed(this, new EventArgs());
        }
    }
}
