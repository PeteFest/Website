using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeteFest.Data.Core;
using PeteFest.Data.Core.GData;
using PeteFest.Data.WebsiteMetadata.Pages.Festival.Performers;

namespace PeteFest.Data.Repositories
{
    public interface IActRepository : IRepository<Act>
    {
        Act GetById(Guid id);
    }
}
