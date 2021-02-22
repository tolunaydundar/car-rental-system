using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(color => color.Id).NotEmpty();
            RuleFor(color => color.Name).NotEmpty();
            RuleFor(color => color.Name).Length(2, 40);
            RuleFor(color => color.HexCode).NotEmpty();
            RuleFor(color => color.HexCode).Length(6, 6);
        }
    }
}
