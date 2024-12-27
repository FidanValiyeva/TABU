using Babu.DTOs.Languages;
using System.Collections;

namespace Babu.Services.Abstarcts
{
    public interface ILanguageService
    {
        Task CreateAsync(LanguageCreateDto dto);
        Task<IEnumerable<LanguagesGetDto>> GetAllAsync();
        Task DeleteAsync(string code);
        Task <LanguagesGetDto>UpdateAsync(string code,LanguageUpdateDto dto);

    }
}
