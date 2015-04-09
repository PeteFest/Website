using System;
using AutoMapper;
using PeteFest.Data.Core.DataObjects;

namespace PeteFest.Web.Mapping.Base
{
    public abstract class ModelMapper<TModel, TDataObject> : IModelMapper<TModel, TDataObject> where TDataObject : DataObject
    {
        public TDataObject ModelToDataObject(TModel model)
        {
            var dataObject = Activator.CreateInstance<TDataObject>();

            return this.ModelToDataObject(model, dataObject);
        }

        public TDataObject ModelToDataObject(TModel model, TDataObject dataObject)
        {
            Mapper.DynamicMap(model, dataObject);

            return dataObject;
        }

        public TModel DataObjectToModel(TDataObject dataObject)
        {
            var model = Activator.CreateInstance<TModel>();

            return this.DataObjectToModel(dataObject, model);
        }

        public TModel DataObjectToModel(TDataObject dataObject, TModel model)
        {
            Mapper.DynamicMap(dataObject, model);

            return model;
        }
    }
}