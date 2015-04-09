using System;

namespace PeteFest.Data.Core.DBreeze
{
    public interface IDBreezeEngineWrapper : IDisposable
    {
        ITransactionWrapper GetTransaction();

        TRepository GetRepository<TRepository>(ITransactionWrapper transaction);
    }
}