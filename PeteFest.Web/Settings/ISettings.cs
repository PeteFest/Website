namespace PeteFest.Web.Settings
{
    public interface ISettings
    {
        string DatabaseFolderPath { get; }

        string PhotosFolderPath { get; }
    }
}
