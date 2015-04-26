using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Gmail.v1;
using PeteFest.Data.Core.GData;
using PeteFest.Data.WebsiteMetadata.Pages.Festival;
using PeteFest.Data.WebsiteMetadata.Pages.Festival.Performers;

namespace PeteFest.Data.Repositories
{
    public class ActRepository : GDataRepository<Act>, IActRepository
    {
        public ActRepository(IGDataServiceFactory serviceFactory)
            : base(serviceFactory)
        {          
        }

        public Act GetById(Guid id)
        {
            return base.SearchSingleById(id);
        }
    }
}
