using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(category => category.Id).NotEmpty();
            RuleFor(category => category.Name).NotEmpty();
            RuleFor(category => category.Name).Length(2, 40);
            RuleFor(category => category.Description).Length(2, 100);
        }
    }
}
