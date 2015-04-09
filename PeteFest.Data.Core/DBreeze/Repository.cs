using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DBreeze.DataTypes;
using PeteFest.Data.Core.DataObjects;
using PeteFest.Data.Core.DataQuality;
using PeteFest.Data.Core.DataQuality.Rules.Base;

namespace PeteFest.Data.Core.DBreeze
{
    public class Repository<T> : IRepository<T> where T : DataObject
    {
        private readonly ITransactionWrapper _transaction;

        public Repository(ITransactionWrapper transaction)
        {
            _transaction = transaction;
        }

        public T Retrieve(Guid id)
        {
            var row = _transaction.Select<string, DbMJSON<T>>(typeof(T).FullName, id.ToString());

            if (row.Exists)
            {
                return row.Value.Get;
            }

            return default(T);
        }

        public IEnumerable<T> RetrieveAll()
        {
            var data = _transaction.SelectForward<string, DbMJSON<T>>(typeof (T).FullName);

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

            _transaction.Insert(typeof(T).FullName, dataObject.Id.ToString(), new DbMJSON<T>(dataObject));

            return dataObject;
        }

        public T Update(T dataObject)
        {
            dataObject.UpdatedOn = DateTime.Now;

            _transaction.Insert(typeof(T).FullName, dataObject.Id.ToString(), new DbMJSON<T>(dataObject));

            return dataObject;
        }

        public bool Check<TProperty, TRule>(Expression<Func<T, TProperty>> property, T dataObject) where TRule : IRule, new()
        {
            var rule = Activator.CreateInstance<TRule>();
            return rule.IsSatisfied(property, dataObject, RetrieveAll());
        }
    }
}