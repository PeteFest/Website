using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PeteFest.Data.WebsiteMetadata;
using PeteFest.Data.WebsiteMetadata.Pages.About;
using PeteFest.Data.WebsiteMetadata.Pages.Home;
using PeteFest.Web.Mapping.Base;
using PeteFest.Web.Models;

namespace PeteFest.Web.Mapping
{
    public class AboutModelMapper : ModelMapper<AboutModel, AboutPage>, IAboutModelMapper
    {
    }
}