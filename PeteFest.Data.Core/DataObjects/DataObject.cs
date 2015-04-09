using System;
using PeteFest.Data.Core.DataQuality;

namespace PeteFest.Data.Core.DataObjects
{
    public abstract class DataObject
    {
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
