using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PeteFest.Web.Models.Base;

namespace PeteFest.Web.Models.Festival
{
    public class ProgrammeModel : ModelBase
    {
        public string SaturdayProgrammeHeaderText { get; set; }
        public string SaturdayProgrammeParagraphText { get; set; }
        public string SundayProgrammeHeaderText { get; set; }
        public string SundayProgrammeParagraphText { get; set; }
    }
}