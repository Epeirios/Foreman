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
    public partial class LanguageSettingControl : UserControl, ILanguageSettingControl
    {
        public LanguageSettingControl()
        {
            InitializeComponent();
        }

        public event EventHandler SelectedLanguageChanged;

        public string GetSelectedLanguage()
        {
            throw new NotImplementedException();
        }

        public void SetLabel(string text)
        {
            throw new NotImplementedException();
        }

        public void SetLanguages(string[] languages)
        {
            throw new NotImplementedException();
        }

        public void SetSelectedLanguage(string selectedLanguage)
        {
            throw new NotImplementedException();
        }
    }
}
