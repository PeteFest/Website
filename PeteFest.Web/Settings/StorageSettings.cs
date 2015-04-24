using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace PeteFest.Web.Settings
{
    public class StorageSettings : IStorageSettings
    {
        public string PhotosFolderPath
        {
            get { return ConfigurationManager.AppSettings["PhotosFolder"]; }
        }

        public string DatabaseFolderPath
        {
            get { return ConfigurationManager.AppSettings["DatabaseFolder"]; }
        }
    }
}