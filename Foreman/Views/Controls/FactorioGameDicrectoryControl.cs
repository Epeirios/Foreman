using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Specialized;

namespace Foreman.Views.Controls
{
    public partial class FactorioGameDicrectoryControl : UserControl, IFactorioGameDirectoryControl
    {
        FoundInstallation[] foundInstallations = { };

        public FactorioGameDicrectoryControl()
        {
            InitializeComponent();
        }

        public string ManualDir { get => textBoxManualDirectory.Text; set => textBoxManualDirectory.Text = value; }
        public Version ManualDirVersion { get => new Version(labelManualVersion.Text); set => labelManualVersion.Text = value.ToString(); }
        public string SelectedDir { get => (string)comboBoxFoundDirectories.SelectedItem; set => comboBoxFoundDirectories.SelectedItem = value; }
        public Version FoundDirVersion { get => new Version(labelSelectedVersion.Text); set => labelSelectedVersion.Text = value.ToString(); }

        public event EventHandler<StringEventArgs> SelectedFoundDirectoryChanged;
        public event EventHandler<StringEventArgs> ManualDirectoryChanged;
        public event EventHandler<StringEventArgs> ManualDirectoryNavigateButtonPressed;
        public event EventHandler<RadioButtonEventArgs> RadioButtonChanged;

        public void RadioButtonFocus(RadioButtonStatesEnum radioButtonStatesEnum)
        {
            switch (radioButtonStatesEnum)
            {
                case RadioButtonStatesEnum.foundDirectories:
                    radioButtonFoundDirectories.Checked = true;
                    comboBoxFoundDirectories.Enabled = true;
                    textBoxManualDirectory.Enabled = false;
                    buttonSelectDirectory.Enabled = false;
                    break;
                case RadioButtonStatesEnum.manualDirectory:
                    radioButtonManualDirectory.Checked = true;
                    comboBoxFoundDirectories.Enabled = false;
                    textBoxManualDirectory.Enabled = true;
                    buttonSelectDirectory.Enabled = true;
                    break;
                default:
                    break;
            }
        }

        public void RadioButtonToggleEnabled(RadioButtonStatesEnum radioButton, bool enabled)
        {
            switch (radioButton)
            {
                case RadioButtonStatesEnum.foundDirectories:
                    radioButtonFoundDirectories.Enabled = enabled;
                    break;
                case RadioButtonStatesEnum.manualDirectory:
                    radioButtonManualDirectory.Enabled = enabled;
                    break;
                default:
                    break;
            }
        }

        public void SetFoundGameDirectories(string[] foundInstallations)
        {
            comboBoxFoundDirectories.Items.Clear();
            comboBoxFoundDirectories.Items.AddRange(foundInstallations);
        }

        private void buttonSelectDirectory_Click(object sender, EventArgs e)
        {
            StringEventArgs args = new StringEventArgs();
            args.Value = textBoxManualDirectory.Text;

            ManualDirectoryNavigateButtonPressed(this, args);
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                RadioButtonEventArgs args = new RadioButtonEventArgs();

                if (((RadioButton)sender) == radioButtonFoundDirectories)
                {
                    args.RadioButtonStatesEnum = RadioButtonStatesEnum.foundDirectories;
                }
                else if (((RadioButton)sender) == radioButtonManualDirectory)
                {
                    args.RadioButtonStatesEnum = RadioButtonStatesEnum.manualDirectory;
                }

                EventHandler<RadioButtonEventArgs> handler = RadioButtonChanged;
                if (handler != null)
                {
                    RadioButtonChanged(this, args);
                }
            }
        }

        private void textBoxManualDirectory_TextChanged(object sender, EventArgs e)
        {
            StringEventArgs args = new StringEventArgs();
            args.Value = textBoxManualDirectory.Text;

            ManualDirectoryChanged(this, args);
        }

        private void comboBoxFoundDirectories_TextChanged(object sender, EventArgs e)
        {
            StringEventArgs args = new StringEventArgs();
            args.Value = (string)comboBoxFoundDirectories.SelectedItem;

            SelectedFoundDirectoryChanged(this, args);
        }
    }
}
