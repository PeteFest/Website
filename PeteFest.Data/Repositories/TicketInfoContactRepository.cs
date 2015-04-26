using Google.Apis.Services;
using PeteFest.Data.Core.GData;
using PeteFest.Data.DataObjects;

namespace PeteFest.Data.Repositories
{
    public class TicketInfoContactRepository : GDataRepository<TicketInfoContact>, ITicketInfoContactRepository
    {
        public TicketInfoContactRepository(IGDataServiceFactory serviceFactory)
            : base(serviceFactory)
        {
        }
    }
}
