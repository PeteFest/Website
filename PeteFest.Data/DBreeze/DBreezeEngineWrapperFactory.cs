using System;
using DBreeze;

namespace PeteFest.Data.DBreeze
{
    public class DBreezeEngineWrapperFactory : IDBreezeEngineWrapperFactory
    {
        private readonly string _dbPath;

        public DBreezeEngineWrapperFactory()
        {
            _dbPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\cache";
        }

        public IDBreezeEngineWrapper Get()
        {
            return new DBreezeEngineWrapper(new DBreezeEngine(_dbPath));
        }
    }
}