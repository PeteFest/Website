using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeteFest.Data.Core.DataObjects;

namespace PeteFest.Data.WebsiteMetadata.Pages.Festival.Performers
{
    public class Act : DataObject
    {
        public Act() : base("Act")
        {           
        }

        public string BiogParagraph { get; set; }

        public string BiogParagraph2 { get; set; }

        public string BiogParagraph3 { get; set; }

        public Guid PictureId { get; set; }

        public string WebsiteLink { get; set; }

        public string SoundCloudLink { get; set; }

        public string YouTubeLink { get; set; }
    }
}
