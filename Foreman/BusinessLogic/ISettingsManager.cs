namespace Foreman.BusinessLogic
{
    public interface ISettingsManager
    {
        FoundInstallation[] GetSavedGameDirectories();
        string[] GetSavedModDirectories();

        FoundInstallation GetCurrentGameDirectory();
        string GetCurrentModDirectory();
        string GetCurrentLanguage();

        bool CurrentGameDirFound();
        bool CurrentModDirFound();
    }
}
