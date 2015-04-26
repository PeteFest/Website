using PeteFest.Data.Core.DataObjects;

namespace PeteFest.Data.DataObjects
{
    public class TicketInfoContact : DataObject
    {
        public TicketInfoContact()
            : base("TicketInfoContact")
        {          
        }

        public string ContactName { get; set; }

        public string EmailAddress { get; set; }
    }
}
