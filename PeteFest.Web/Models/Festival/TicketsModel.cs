using PeteFest.Web.Models.Base;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FluentValidation.Attributes;
using PeteFest.Web.Models.Validation;

namespace PeteFest.Web.Models.Festival
{
    [Validator(typeof(TicketsModelValidator))]
    public class TicketsModel : ModelBase
    {
        public string HeaderText { get; set; }

        public string Paragraph1Text { get; set; }

        public string Paragraph2Text { get; set; }

        [Display(Name = "Name")]
        public string ContactName { get; set; }

        [Display(Name = "Email")]
        public string EmailAddress { get; set; }
    }
}