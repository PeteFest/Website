using PeteFest.Web.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeteFest.Web.Models.Festival
{
    public class TicketsModel : ModelBase
    {
        public string HeaderText { get; set; }

        public string ParagraphText { get; set; }
    }
}