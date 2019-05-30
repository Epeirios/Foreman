using Foreman.Models;

namespace Foreman.BusinessLogic
{
    public interface ISettingsManager
    {
        Language CurrentLanguage { get; set; }
        GameInstallation CurrentGameInstallation { get; set; }
        string CurrentGameDirectory { get; set; }
        string CurrentModDirectory { get; set; }

        Language[] GetLanguages();
        GameInstallation[] GetFoundInstallations();
        string[] GetFoundInstallationDirectories();
        string[] GetFoundModDirectories();

        GameInstallation GetGameInstalationFromDir(string dir);
    }
}
