using FluentValidation;
using LibraryWebAPI.Dto;
using LibraryWebAPI.Dto.Books;

namespace LibraryWebAPI.Models.Validator
{
    public class BookValidator : AbstractValidator<BookRequestDto>
    {
        public BookValidator()
        {
            RuleFor(b => b.Name)
                .NotEmpty()
                .MinimumLength(3)
                .WithMessage("Mínimo de 3 caracteres.")
                .MaximumLength(80)
                .WithMessage("Máximo de 80 caracteres");

            RuleFor(b => b.Author)
                .NotEmpty()
                .MinimumLength(3)
                .WithMessage("Mínimo de 3 caracteres.")
                .MaximumLength(80)
                .WithMessage("Máximo de 80 caracteres");

            RuleFor(b => b.PublisherId)
                .NotNull()
                .WithMessage("Este campo é obrigatòrio!")
                .GreaterThan(0)
                .WithMessage("Mínimo de 1 caracter");

            RuleFor(b => b.Quantity)
                .NotNull()
                .WithMessage("Este campo é obrigatòrio!")
                .GreaterThan(-1)
                .WithMessage("Mínimo de 1 caracter");

            RuleFor(b => b.Launch)
               .NotEmpty()
               .WithMessage("Este campo é obrigatòrio!");

        }
    }
}
