using PeteFest.Web.Models.Base;
using PeteFest.Web.Models.Festival.Performers;
using PeteFest.Web.Models.Festival.Performers.Acts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeteFest.Web.Models.Festival.Performers
{
    public class PerformersModel : ModelBase
    {
        public IEnumerable<ActModel> Acts { get; set; }
    }
}