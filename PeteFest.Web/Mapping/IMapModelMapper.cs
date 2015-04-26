using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PeteFest.Data.WebsiteMetadata.Pages.Festival.Map;
using PeteFest.Web.Mapping.Base;
using PeteFest.Web.Models.Festival;

namespace PeteFest.Web.Mapping
{
    public interface IMapModelMapper : IModelMapper<MapModel, MapPage>
    {
    }
}