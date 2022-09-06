using FluentValidation;
using LibraryWebAPI.Dto;
using LibraryWebAPI.Dto.Rents;

namespace LibraryWebAPI.Models.Validator
{
    public class RentValidator : AbstractValidator<RentRequestDto>
    {
        public RentValidator()
            {
            RuleFor(r => r.UserId)
                .NotNull()
                .WithMessage("O Id do usuário está vazio!")
                .GreaterThan(0)
                .WithMessage("Mínimo de 1 caracter");

            RuleFor(r => r.BookId)
                .NotNull()
                .WithMessage("O Id do livro está vazio!")
                .GreaterThan(0)
                .WithMessage("Mínimo de 1 caracter");



        }
    }
}
