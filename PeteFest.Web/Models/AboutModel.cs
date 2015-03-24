using PeteFest.Web.Models.Base;

namespace PeteFest.Web.Models
{
    public class AboutModel : ModelBase
    {
        public string HeaderText { get; set; }

        public string ParagraphText { get; set; }

        public string PictureUrl { get; set; }
    }
}