using PeteFest.Data.Core.DBreeze;
using PeteFest.Data.DataObjects;

namespace PeteFest.Data.Repositories
{
    public class TicketInfoContactRepository : Repository<TicketInfoContact>, ITicketInfoContactRepository
    {
        public TicketInfoContactRepository(ITransactionWrapper transaction)
            : base(transaction)
        {
        }
    }
}
