using System.Web.Mvc;
using PeteFest.Web.Models.Base;

namespace PeteFest.Web.Models
{
    public class AboutModel : ModelBase
    {
        public string HeaderText { get; set; }

        public string Paragraph1Text { get; set; }

        public string Paragraph2Text { get; set; }

        public string PictureUrl { get; set; }
    }
}