using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PeteFest.Data.WebsiteMetadata.Pages.Festival.Performers;
using PeteFest.Web.Mapping.Base;
using PeteFest.Web.Models.Festival;

namespace PeteFest.Web.Mapping
{
    public class ActModelMapper : ModelMapper<ActModel,Act>, IActModelMapper
    {
    }
}