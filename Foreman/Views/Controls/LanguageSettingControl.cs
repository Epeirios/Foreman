using System;
using System.Windows.Forms;

namespace Foreman.Views.Controls
{
    public partial class LanguageSettingControl : UserControl, ILanguageSettingControl
    {
        public LanguageSettingControl()
        {
            InitializeComponent();
        }

        public event EventHandler SelectedLanguageChanged;

        public string GetSelectedLanguage()
        {
            return comboBoxLanguage.Text;
        }

        public void SetLabel(string text)
        {
            labelLanguage.Text = text;
        }

        public void SetLanguages(string[] languages)
        {
            comboBoxLanguage.Items.Clear();
            comboBoxLanguage.Items.AddRange(languages);
        }

        public void SetSelectedLanguage(string selectedLanguage)
        {
            comboBoxLanguage.Text = selectedLanguage;
        }

        public void SetVisibility(bool visible)
        {
            groupBox1.Visible = visible;
        }

        private void comboBoxLanguage_TextChanged(object sender, EventArgs e)
        {
            SelectedLanguageChanged(this, new EventArgs());
        }
    }
}
