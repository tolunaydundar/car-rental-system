using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(brand => brand.Id).NotEmpty();
            RuleFor(brand => brand.Name).NotEmpty();
            RuleFor(brand => brand.Name).Length(2, 40);
        }
    }
}
