using System;
using PeteFest.Data.Core.DataQuality;

namespace PeteFest.Data.Core.DataObjects
{
    public abstract class DataObject
    {
        protected DataObject(string typeIdentifier)
        {
            TypeIdentifier = typeIdentifier;
        }

        public string Name { get; set; }

        public string TypeIdentifier { get; private set; }

        public Guid Id { get; set; }

        public string GmailId { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
