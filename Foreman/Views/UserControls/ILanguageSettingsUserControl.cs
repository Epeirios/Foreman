using System;

namespace Foreman.Views.UserControls
{
    public interface ILanguageSettingsUserControl : ISettingsUserControl
    {
        event EventHandler SelectedLanguageChanged;

        void SetLanguages(string[] languages);
        string GetSelectedLanguage();
        void SetSelectedLanguage(string selectedLanguage);
        void SetLabel(string text);
    }
}
