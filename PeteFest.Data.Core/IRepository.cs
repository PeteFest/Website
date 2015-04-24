using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PeteFest.Data.Core.DataObjects;
using PeteFest.Data.Core.DataQuality.Rules.Base;

namespace PeteFest.Data.Core
{
    public interface IRepository<T> where T : DataObject
    {
        T Retrieve(string id);

        IEnumerable<T> RetrieveAll();

        T Create(T dataObject);

        T Update(T dataObject);

        void Delete(T dataObject);
    }
}