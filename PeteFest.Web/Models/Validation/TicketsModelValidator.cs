using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using PeteFest.Web.Models.Festival;

namespace PeteFest.Web.Models.Validation
{
    public class TicketsModelValidator : AbstractValidator<TicketsModel>
    {
        public TicketsModelValidator()
        {
            RuleFor(m => m.EmailAddress)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Email address must be valid");

            RuleFor(m => m.ContactName)
                .NotEmpty()
                .Length(1, 50)
                .WithMessage("Name must be between 1 and 50 characters");
        }
    }
}