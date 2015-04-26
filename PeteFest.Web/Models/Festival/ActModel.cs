using System;
using PeteFest.Web.Models.Base;

namespace PeteFest.Web.Models.Festival
{
    public class ActModel : ModelBase
    {
        public string Biog { get; set; }

        public Guid PictureId { get; set; }

        public string WebsiteLink { get; set; }

        public string SoundCloudLink { get; set; }

        public string YouTubeLink { get; set; }
    }
}