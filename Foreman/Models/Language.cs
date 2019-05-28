namespace Foreman.Models
{
    public struct Language
    {
        public string LanguageID { get; }
        public string LocaleLanguageName { get; }

        public Language(string languageID, string localeLanguageName)
        {
            this.LanguageID = languageID;
            this.LocaleLanguageName = localeLanguageName;
        }
    }
}
