using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeteFest.Data.Core;
using PeteFest.Data.Core.GData;
using PeteFest.Data.WebsiteMetadata.Pages.Home;

namespace PeteFest.Data.Repositories
{
    public class HomePageRepository : GDataRepository<HomePage>, IHomePageRepository
    {
        public HomePageRepository(IGDataServiceFactory serviceFactory)
            : base(serviceFactory)
        {         
        }
    }
}
