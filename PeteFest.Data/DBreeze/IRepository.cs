using System;
using System.Collections;
using System.Collections.Generic;
using PeteFest.Data.DataObjects.Base;

namespace PeteFest.Data.DBreeze
{
    public interface IRepository<T> where T : DataObject
    {
        T Retrieve(Guid id);

        IEnumerable<T> RetrieveAll();

        T Create(T dataObject);

        T Update(T dataObject);
    }
}