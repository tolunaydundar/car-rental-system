using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Id).NotEmpty();
            RuleFor(user => user.FirstName).NotEmpty();
            RuleFor(user => user.FirstName).Length(2, 40);
            RuleFor(user => user.LastName).NotEmpty();
            RuleFor(user => user.LastName).Length(2, 40);
            RuleFor(user => user.Age).NotEmpty();
            RuleFor(user => user.Age).GreaterThanOrEqualTo(18);
            RuleFor(user => user.Sex).NotEmpty();
            RuleFor(user => user.Sex).Must(sex => sex == 'F' || sex == 'M');
            RuleFor(user => user.PhoneNumber).NotEmpty();
            RuleFor(user => user.PhoneNumber).Length(7, 15);
            RuleFor(user => user.Email).NotEmpty();
            RuleFor(user => user.Email).Must(IsValidEmail).WithMessage(Messages.ValidEmail);
            RuleFor(user => user.Password).NotEmpty();
            RuleFor(user => user.Password).Length(8, 40);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                MailAddress _ = new MailAddress(email);
                return true;
            }

            catch (FormatException)
            {
                return false;
            }
        }
    }
}
