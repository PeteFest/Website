using System;
using DBreeze;
using DBreeze.Transactions;
using PeteFest.Data.DataObjects.Base;

namespace PeteFest.Data.DBreeze
{
    public class DBreezeEngineWrapper : IDBreezeEngineWrapper
    {
        private readonly DBreezeEngine _db;
        private Transaction _transaction;

        public DBreezeEngineWrapper(DBreezeEngine db)
        {
            _db = db;
            _transaction = db.GetTransaction();
        }

        public IRepository<T> GetRepository<T>() where T : DataObject
        {
            try
            {
                return new Repository<T>(_transaction);
            }
            catch (Exception ex)
            {
                const string message = "A problem occured whilst initializing DBreeze transaction";
                throw new DBreezeTransactionException(message, ex);
            }
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch (Exception)
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction = _db.GetTransaction();
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}