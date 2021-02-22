using Business.Concrete;
using Entities.Concrete;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.Id).NotEmpty();
            RuleFor(customer => customer.UserId).NotEmpty();
            RuleFor(customer => customer.CompanyName).Length(2, 40);
        }
    }
}
