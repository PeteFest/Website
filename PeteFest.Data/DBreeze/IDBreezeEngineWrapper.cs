using System;
using PeteFest.Data.DataObjects.Base;

namespace PeteFest.Data.DBreeze
{
    public interface IDBreezeEngineWrapper : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : DataObject;

        void Commit();
    }
}