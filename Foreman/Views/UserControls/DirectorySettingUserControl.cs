using System;
using System.Windows.Forms;

namespace Foreman.Views.UserControls
{
    public partial class DirectorySettingUserControl : UserControl, IDirectorySettingsUserControl
    {
        public DirectorySettingUserControl()
        {
            InitializeComponent();
        }

        public event EventHandler DirectoryButtonPressed;
        public event EventHandler DirectoryChanged;

        public string GetSelectedDirectory()
        {
            return comboBoxSelectDirectory.Text;
        }

        public void SetDirectories(string[] directories)
        {
            comboBoxSelectDirectory.Items.Clear();
            comboBoxSelectDirectory.Items.AddRange(directories);
        }

        public void SetDirectotyLabel(string text)
        {
            labelDirectory.Text = text;
        }

        public void SetInfoLabel(string text)
        {
            labelInfo.Text = text;
        }

        public void SetInfoValue(string value)
        {
            labelInfoValue.Text = value;
        }

        public void SetSelectedDirectory(string selectedDirectory)
        {
            comboBoxSelectDirectory.Text = selectedDirectory;
        }

        public void SetVisibility(bool visible)
        {
            groupBox1.Visible = visible;
        }

        private void buttonSelectDirectory_Click(object sender, EventArgs e)
        {
            DirectoryButtonPressed(this, new EventArgs());
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            DirectoryChanged(this, new EventArgs());
        }
    }
}
