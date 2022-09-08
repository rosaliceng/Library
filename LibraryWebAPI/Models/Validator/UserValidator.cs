using FluentValidation;
using LibraryWebAPI.Dto;
using LibraryWebAPI.Dto.Users;

namespace LibraryWebAPI.Models.Validator
{
    public class UserValidator : AbstractValidator<UserRequestDto>
    {
        public UserValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty()
                .WithMessage("Este campo é obrigatório!")
                .MinimumLength(3)
                .WithMessage("Mínimo de 3 caracteres.")
                .MaximumLength(80)
                .WithMessage("Máximo de 80 caracteres.");

            RuleFor(u => u.City)
                .NotEmpty()
                .WithMessage("Este campo é obrigatório!")
                .MinimumLength(3)
                .WithMessage("Mínimo de 3 caracteres.")
                .MaximumLength(80)
                .WithMessage("Máximo de 80 caracteres.");

            RuleFor(u => u.City)
                .NotEmpty()
                .WithMessage("Este campo é obrigatório!")
                .MinimumLength(3)
                .WithMessage("Mínimo de 3 caracteres.")
                .MaximumLength(80)
                .WithMessage("Máximo de 80 caracteres.");

            RuleFor(u => u.Email)
               .NotEmpty()
               .WithMessage("Este campo é obrigatório!")
               .EmailAddress()
               .WithMessage("E-mail inválido!");

        }
    }
}
