using PeteFest.Web.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeteFest.Web.Models.Festival.Performers.Acts
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