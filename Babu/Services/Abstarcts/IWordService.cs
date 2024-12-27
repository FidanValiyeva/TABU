using Babu.DTOs.Words;

namespace Babu.Services.Abstarcts
{
    public interface IWordService
    {
        Task CreateAsync(WordCreateDto dto);
        Task<IEnumerable<WordGetDto>> GetAllAsync();
        Task<WordGetDto> GetByIdAsync(int id);        
        Task DeleteAsync(int id);
    }
}
