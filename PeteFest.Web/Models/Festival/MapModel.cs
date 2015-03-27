using PeteFest.Web.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PeteFest.Web.Models.Festival
{
    public class MapModel : ModelBase
    {
        public string MapHeaderText { get; set; }
        public string MapParagraphText { get; set; }
        public string DirectionsHeaderText { get; set; }
        public string DirectionsParagraphText { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Zoom { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string TownOrCity { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public string LinkText { get; set; }

        public string FormattedAddress 
        { 
            get
            {
                string formattedAddress = string.Empty;
                foreach (var addressLine in AddressLines())
                {
                    formattedAddress += !string.IsNullOrEmpty(addressLine)
                        ? addressLine + ", "
                        : string.Empty;
                }

                return formattedAddress.EndsWith(", ")
                    ? formattedAddress.Remove(formattedAddress.LastIndexOf(", "))
                    : formattedAddress;
            }
        }

        public MvcHtmlString HtmlFormattedAddress
        {
            get
            {
                string formattedAddress = string.Empty;
                foreach (var addressLine in AddressLines())
                {
                    formattedAddress += !string.IsNullOrEmpty(addressLine)
                        ? addressLine + @"<br/>"
                        : string.Empty;
                }

                if (formattedAddress.EndsWith(@"<br/>"))
                {
                    formattedAddress = formattedAddress.Remove(formattedAddress.LastIndexOf(@"<br/>"));
                }

                return new MvcHtmlString(string.Format(@"<p>{0}</p>", formattedAddress));
            }
        }

        private IEnumerable<string> AddressLines()
        {
            List<string> addressLines = new List<string>();
            addressLines.Add(AddressLine1);
            addressLines.Add(AddressLine2);
            addressLines.Add(AddressLine3);
            addressLines.Add(TownOrCity);
            addressLines.Add(County);
            addressLines.Add(Postcode);
            return addressLines;
        }
    }
}