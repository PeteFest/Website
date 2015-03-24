using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeteFest.Data.DataObjects.Base
{
    public abstract class DataObject
    {
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public string Ip { get; set; }
    }
}
