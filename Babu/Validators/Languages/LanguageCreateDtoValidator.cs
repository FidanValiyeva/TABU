using Babu.DTOs.Languages;
using FluentValidation;

namespace Babu.Validators.Languages
{
    public class LanguageCreateDtoValidator:AbstractValidator<LanguageCreateDto>
    {
        public LanguageCreateDtoValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty()
            .WithMessage("olke code adi bosh ola bilmez")
            .NotNull()
            .WithMessage("olke code adi null ola bilmez")
            .Length(2)
            .WithMessage("olke code adi 2den az ola bilmez");

            RuleFor(x => x.Name)
                .MinimumLength(2)
                .MaximumLength(32);

            RuleFor(x => x.IconUrl)
                .MaximumLength(128)
                .Matches("^http(s)?://([\\w-]+.)+[\\w-]+(/[\\w- ./?%&=])?$")
                .WithMessage("Url link olmalidir");
                

                



        }

    }
}
