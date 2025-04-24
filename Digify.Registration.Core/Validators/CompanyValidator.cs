using FluentValidation;
using Digify.Registration.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digify.Registration.Core.Validators
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(t => t.Id).NotEqual(Guid.Empty);  
            RuleFor(t => t.CompanyName).NotNull().NotEmpty();
            RuleFor(t => t.NPWP).NotNull().NotEmpty();
            RuleFor(t => t.DirectorName).NotNull().NotEmpty();
            RuleFor(t => t.PICName).NotNull().NotEmpty();
            RuleFor(t => t.Email).NotNull().NotEmpty();
            RuleFor(t => t.PhoneNumber).NotNull().NotEmpty();
            RuleFor(t => t.DocumentNPWP).NotNull().NotEmpty();
            RuleFor(t => t.DocumentPowerOfAttorney).NotNull().NotEmpty();
            RuleFor(t => t.DocumentNPWPName).NotNull().NotEmpty();
            RuleFor(t => t.DocumentPowerOfAttorneyName).NotNull().NotEmpty();
        }
    }
}
