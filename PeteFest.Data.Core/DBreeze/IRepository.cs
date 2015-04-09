using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PeteFest.Data.Core.DataObjects;
using PeteFest.Data.Core.DataQuality;
using PeteFest.Data.Core.DataQuality.Rules.Base;

namespace PeteFest.Data.Core.DBreeze
{
    public interface IRepository<T> where T : DataObject
    {
        IEnumerable<T> RetrieveAll();

        T Create(T dataObject);

        T Update(T dataObject);

        bool Check<TProperty, TRule>(Expression<Func<T, TProperty>> property, T dataObject)
            where TRule : IRule, new();
    }
}