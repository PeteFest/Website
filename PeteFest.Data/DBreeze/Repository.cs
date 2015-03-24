using System;
using System.Collections.Generic;
using System.Linq;
using DBreeze.DataTypes;
using DBreeze.Transactions;
using PeteFest.Data.DataObjects.Base;

namespace PeteFest.Data.DBreeze
{
    public class Repository<T> : IRepository<T> where T : DataObject
    {
        private readonly Transaction _transaction;

        public Repository(Transaction transaction)
        {
            _transaction = transaction;
        }

        public T Retrieve(Guid id)
        {
            var row = _transaction.Select<Guid, DbMJSON<T>>(typeof(T).FullName, id);

            if (row.Exists)
            {
                return row.Value.Get;
            }

            return default(T);
        }

        public IEnumerable<T> RetrieveAll()
        {
            var data = _transaction.SelectForward<Guid, DbMJSON<T>>(typeof (T).FullName);

            return data
                .Where(row => row.Value != null)
                .Select(row => row.Value.Get);
        }

        public T Create(T dataObject)
        {
            dataObject.CreatedOn = DateTime.Now;
            dataObject.Id = dataObject.Id == Guid.Empty 
                ? Guid.NewGuid() 
                : dataObject.Id;

            // TODO: Note IP Addresses

            _transaction.Insert(typeof(T).FullName, dataObject.Id, new DbMJSON<T>(dataObject));

            return dataObject;
        }

        public T Update(T dataObject)
        {
            dataObject.UpdatedOn = DateTime.Now;

            _transaction.Insert(typeof(T).FullName, dataObject.Id, new DbMJSON<T>(dataObject));

            return dataObject;
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }
    }
}