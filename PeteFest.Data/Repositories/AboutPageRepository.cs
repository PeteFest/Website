using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeteFest.Data.Core.GData;
using PeteFest.Data.WebsiteMetadata.Pages.About;

namespace PeteFest.Data.Repositories
{
    public class AboutPageRepository : GDataRepository<AboutPage>, IAboutPageRepository
    {
        public AboutPageRepository(IGDataServiceFactory serviceFactory)
            : base(serviceFactory)
        {         
 
        }
    }
}
