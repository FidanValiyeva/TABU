using Babu.DTOs.Games;
using FluentValidation;

namespace Babu.Validators.Games
{
    public class GameCreateDtoValidator:AbstractValidator<GameCreateDto>    
    {
        public GameCreateDtoValidator() 
        {
            RuleFor(x=>x.LanguageCode)
                .NotEmpty()
                .WithMessage("Olke kodu bosh olamsin")
                .NotNull()
                .Length(2)  
                .WithMessage("olke kodu 2den az ola bilmez");
            RuleFor(x => x.BannedWordCount)
                .NotEmpty()
                .WithMessage("bannanmis soz sayi bosh olmasin")
                .NotNull()
                .WithMessage("bannanmis soz sayi null olmasin");

                
                
               
                
        } 
    }
}
