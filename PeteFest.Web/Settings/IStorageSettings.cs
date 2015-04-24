namespace PeteFest.Web.Settings
{
    public interface IStorageSettings
    {
        string DatabaseFolderPath { get; }

        string PhotosFolderPath { get; }
    }
}
