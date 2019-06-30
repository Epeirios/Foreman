using Foreman.Views.UserControls;
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

namespace ForemanFrontend.Views.Usercontrols
{
    /// <summary>
    /// Interaction logic for LanguageSettingsUserControl.xaml
    /// </summary>
    public partial class LanguageSettingsUserControl : UserControl, ILanguageSettingsUserControl, ISettingsUserControl
    {
        public LanguageSettingsUserControl()
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
