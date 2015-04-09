using PeteFest.Data.Core.DataObjects;

namespace PeteFest.Web.Mapping.Base
{
    public interface IModelMapper<TModel, TDataObject> where TDataObject : DataObject
    {
        TDataObject ModelToDataObject(TModel model);

        TDataObject ModelToDataObject(TModel model, TDataObject dataObject);

        TModel DataObjectToModel(TDataObject dataObject);

        TModel DataObjectToModel(TDataObject dataObject, TModel model);
    }
}