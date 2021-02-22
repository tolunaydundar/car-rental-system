using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(car => car.Id).NotEmpty();
            RuleFor(car => car.BrandId).NotEmpty();
            RuleFor(car => car.CategoryId).NotEmpty();
            RuleFor(car => car.ColorId).NotEmpty();
            RuleFor(car => car.Model).NotEmpty();
            RuleFor(car => car.Model).Length(2, 40);
            RuleFor(car => car.ModelYear).NotEmpty();
            RuleFor(car => car.ModelYear).InclusiveBetween(1900, DateTime.Now.Year);
            RuleFor(car => car.DailyPrice).NotEmpty();
            RuleFor(car => car.Description).Length(2, 100);
        }
    }
}
