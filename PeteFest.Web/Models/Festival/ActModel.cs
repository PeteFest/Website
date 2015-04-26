using System;
using PeteFest.Web.Models.Base;

namespace PeteFest.Web.Models.Festival
{
    public class ActModel : ModelBase
    {
        public string BiogParagraph { get; set; }

        public string BiogParagraph2 { get; set; }

        public string BiogParagraph3 { get; set; }

        public Guid PictureId { get; set; }

        public string WebsiteLink { get; set; }

        public string SoundCloudLink { get; set; }

        public string YouTubeLink { get; set; }
    }
}