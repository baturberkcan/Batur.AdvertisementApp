using Batur.AdvertisementApp.UI.Models;
using FluentValidation;
using System;

namespace Batur.AdvertisementApp.UI.ValidationRules
{
    public class UserCreateModelValidator : AbstractValidator<UserCreateModel>
    {
        [Obsolete]
        public UserCreateModelValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Password).MinimumLength(3);
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Password not match");
            RuleFor(x => x.Firstname).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();

            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Username).MinimumLength(3);

            RuleFor(x => new { x.Username, x.Firstname })
                .Must(x => CannotFirstName(x.Username, x.Firstname))
                .When(x => x.Username != null && x.Firstname != null)
                .WithMessage("User name contains Firstname");
           
            RuleFor(x => x.GenderId).NotEmpty();

        }

        private bool CannotFirstName(string username, string firstname)
        {
            return !username.Contains(firstname);
        }
    }
}
