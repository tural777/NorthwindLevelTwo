using FluentValidation;
using MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.ValidationRules.FluentValidation
{
    public class ShippingDetailValidator : AbstractValidator<ShippingDetail>
    {

        public ShippingDetailValidator()
        {
            RuleFor(r => r.FirstName).NotEmpty().WithMessage("Zehmet olmasa adinizi daxil edin.");
            RuleFor(r => r.FirstName).MinimumLength(3);
            RuleFor(r => r.LastName).NotEmpty();
            RuleFor(r => r.Email).EmailAddress();
            RuleFor(r => r.Address).NotEmpty();
            RuleFor(r => r.City).NotEmpty();
            //RuleFor(r => r.Age).ExclusiveBetween(18, 199);

            RuleFor(r => r.Age).Must(CustomRule).WithMessage("Min 18 yash olmalidir.");
        }

        private bool CustomRule(int age)
        {
            return age >= 18;
        }
    }
}
