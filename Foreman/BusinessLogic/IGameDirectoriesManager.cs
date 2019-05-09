namespace Foreman.BusinessLogic
{
    public interface IGameDirectoriesManager
    {
        FoundInstallation[] GameDirectories { get; }
        string[] ModDirectories { get; }

        string GetCurrentGameDirectory();
        string GetCurrentModDirectory();

        bool CurrentGameDirFound();
        bool CurrentModDirFound();
    }
}
