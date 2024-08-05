using Microsoft.Net.Http.Headers;
using WebApplication5.Entity;
using FluentValidation;
using System.Data;
using Microsoft.Identity.Client;
using System.Text.RegularExpressions;

namespace WebApplication5.volidator
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator() 
        {
            //string NameValidation = "1234567890!@#$%^&*().,:;";

            //Regex regex = new Regex("^[A-Z А-Я][a-z]");
            //Match matches = regex.Matches(name);
            //if (matches.Success)
            //{

            //}

            RuleFor(user => user.Name).NotEmpty().Matches("^[A-Za-zА-Яа-яЁё\\s'-]+$").WithMessage("Name is required.").Length(2, 50)9;
            RuleFor(user => user.Surname).NotEmpty().WithMessage("Surname is required.").Length(2, 50);
            RuleFor(user => user.Email).NotEmpty().WithMessage("Email is required").EmailAddress();
            RuleFor(user => user.Id).IsInEnum();
        }
    }
}
