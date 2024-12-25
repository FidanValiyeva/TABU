using Babu.DTOs.Words;

namespace Babu.Services.Abstarcts
{
    public interface IWordService
    {
        Task<int> CreateAsync(WordCreateDto dto);

    }
}
