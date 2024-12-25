using Babu.DTOs.Words;
using FluentValidation;

namespace Babu.Validators.Words
{
    public class WordCreateDtoValidator:AbstractValidator<WordCreateDto>
    {
        public WordCreateDtoValidator()
        {
            RuleForEach(x => x.BannedWords)
                .NotNull()
                .MinimumLength(2);
            RuleFor(x => x.BannedWords)
                .NotNull()
                .Must(x => x.Count == 6);
        }
    }
}
