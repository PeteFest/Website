using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Gmail.v1;
using PeteFest.Data.Core.GData;
using PeteFest.Data.WebsiteMetadata.Pages.Festival;

namespace PeteFest.Data.Repositories
{
    public class PhotoRepository : GDataRepository<Photo>, IPhotoRepository
    {
        public PhotoRepository(IGDataServiceFactory serviceFactory) : base(serviceFactory)
        {
        }

        public Photo GetById(Guid id)
        {
            return base.SearchSingleById(id);
        }
    }
}
