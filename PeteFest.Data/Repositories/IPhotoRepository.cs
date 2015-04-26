using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeteFest.Data.Core;
using PeteFest.Data.WebsiteMetadata.Pages.Festival;

namespace PeteFest.Data.Repositories
{
    public interface IPhotoRepository : IRepository<Photo>
    {
        Photo GetById(Guid id);
    }
}
