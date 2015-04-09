using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PeteFest.Web.Models.Base;

namespace PeteFest.Web.Models
{
    public class HomeModel : ModelBase
    {
        [Display(Name = "Pre-Header Text")]
        public string PreHeaderText { get; set; }

        [Display(Name = "Header Text")]
        public string HeaderText { get; set; }

        [Display(Name = "Summary Text")]
        public string SummaryText { get; set; }

        [Display(Name = "Twitter Widget Id")]
        public string TwitterWidgetId { get; set; }
    }
}