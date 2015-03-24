using System.Collections.Generic;
using PeteFest.Web.Models.Base;

namespace PeteFest.Web.Models
{
    public class HomeModel : ModelBase
    {
        public string PreHeaderText { get; set; }

        public string HeaderText { get; set; }

        public string SummaryText { get; set; }

        public string TwitterWidgetId { get; set; }
    }
}