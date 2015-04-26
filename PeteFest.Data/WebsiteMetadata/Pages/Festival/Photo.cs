using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeteFest.Data.Core.DataObjects;

namespace PeteFest.Data.WebsiteMetadata.Pages.Festival
{
    public class Photo : DataObject
    {
        public Photo()
            : base("Photo")
        {          
        }

        public string Data { get; set; }

        public string Name { get; set; }
    }
}
