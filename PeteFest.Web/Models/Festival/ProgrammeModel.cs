using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PeteFest.Web.Models.Base;

namespace PeteFest.Web.Models.Festival
{
    public class ProgrammeModel : ModelBase
    {
        public string ProgrammeHeaderText { get; set; }
        public string ProgrammeParagraphText { get; set; }
    }
}