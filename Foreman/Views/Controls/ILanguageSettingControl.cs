using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foreman.Views.Controls
{
    public interface ILanguageSettingControl : ISettingsControl
    {
        event EventHandler SelectedLanguageChanged;

        void SetLanguages(string[] languages);
        string GetSelectedLanguage();
        void SetSelectedLanguage(string selectedLanguage);
        void SetLabel(string text);
    }
}
