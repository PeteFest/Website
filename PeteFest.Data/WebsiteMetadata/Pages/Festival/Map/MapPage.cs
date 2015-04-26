using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeteFest.Data.Core.DataObjects;

namespace PeteFest.Data.WebsiteMetadata.Pages.Festival.Map
{
    public class MapPage : DataObject
    {
        public MapPage() : base("MapPage")
        {           
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Zoom { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string TownOrCity { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
    }
}
