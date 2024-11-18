using FluentValidation;
using PuntoDeVenta.Models;

namespace PuntoDeVenta.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Username).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.PasswordHash).NotEmpty().MinimumLength(8);
        }
    }
}
