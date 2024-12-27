using Babu.DTOs.Words;

namespace Babu.Services.Abstarcts
{
    public interface IWordService
    {
        Task<int> CreateAsync(WordCreateDto dto);
        Task<int> UpdateAsync(WordUpdateDto dto);
        Task<int> DeleteAsync(int code);
    }
}
