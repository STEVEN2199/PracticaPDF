using FluentValidation;
using PuntoDeVenta.Models;

namespace PuntoDeVenta.Validators
{
    public class RoleValidator : AbstractValidator<Role>
    {
        public RoleValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
        }
    }
}
