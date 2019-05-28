using Foreman.Models;

namespace Foreman.BusinessLogic
{
    public interface ISettingsManager
    {
        Language CurrentLanguage { get; set; }
        FoundInstallation CurrentGameInstallation { get; set; }
        string CurrentGameDirectory { get; set; }
        string CurrentModDirectory { get; set; }

        Language[] GetLanguages();
        FoundInstallation[] GetFoundInstallations();
        string[] GetFoundInstallationDirectories();
        string[] GetFoundModDirectories();
    }
}
