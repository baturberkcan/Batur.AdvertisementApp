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
            //CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola Boş olamaz");
            RuleFor(x => x.Password).MinimumLength(3).WithMessage("Parola en az 3 karakter olmalıdır");
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Parolalar eşleşmiyor");
            RuleFor(x => x.Firstname).NotEmpty().WithMessage("Ad boş olamaz");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad boş olamaz");

            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı boş olamaz"); ;
            RuleFor(x => x.Username).MinimumLength(3).WithMessage("Kullanıcı adı en 3 karakter olmalıdır"); ;

            RuleFor(x => new { x.Username, x.Firstname })
                .Must(x => CannotFirstName(x.Username, x.Firstname))
                .When(x => x.Username != null && x.Firstname != null)
                .WithMessage("Kullanıcı adı adınızı içeremez");
           
            RuleFor(x => x.GenderId).NotEmpty().WithMessage("Cinsiyet seçimi zorunludur");

        }

        private bool CannotFirstName(string username, string firstname)
        {
            return !username.Contains(firstname);
        }
    }
}
