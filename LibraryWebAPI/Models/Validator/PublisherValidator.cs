using FluentValidation;
using LibraryWebAPI.Dto;
using LibraryWebAPI.Dto.Publishers;

namespace LibraryWebAPI.Models.Validator
{
    public class PublisherValidator : AbstractValidator<PublisherRequestDto>
    {
        public PublisherValidator()
        {
  
            RuleFor(p => p.Name)
                .NotEmpty()
                .MinimumLength(3)
                .WithMessage("Mínimo de 3 caracteres.")
                .MaximumLength(80)
                .WithMessage("Máximo de 80 caracteres");

            RuleFor(p => p.City)
                .NotEmpty()
                .MinimumLength(3)
                .WithMessage("Mínimo de 3 caracteres.")
                .MaximumLength(80)
                .WithMessage("Máximo de 80 caracteres");
        }
    }
}
