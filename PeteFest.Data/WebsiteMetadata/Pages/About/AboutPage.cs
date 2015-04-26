using System.Web.Mvc;
using PeteFest.Data.Core.DataObjects;

namespace PeteFest.Data.WebsiteMetadata.Pages.About
{
    public class AboutPage : DataObject
    {
        public AboutPage() : base("AboutPage")
        {         
        }

        public string HeaderText { get; set; }

        public string Paragraph1Text { get; set; }

        public string Paragraph2Text { get; set; }

        public string PictureUrl { get; set; }
    }
}
