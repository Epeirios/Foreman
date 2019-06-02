using System;

namespace Foreman.Views.Controls
{
    public interface ILanguageSettingsControl : ISettingsControl
    {
        event EventHandler SelectedLanguageChanged;

        void SetLanguages(string[] languages);
        string GetSelectedLanguage();
        void SetSelectedLanguage(string selectedLanguage);
        void SetLabel(string text);
    }
}
