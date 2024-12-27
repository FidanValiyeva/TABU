using Babu.DTOs.BannedWords;
using Babu.DTOs.Games;

namespace Babu.Services.Abstarcts
{
    public interface IBannedWordService
    {
        Task<string> GetWordAsync(string word);
        Task<BannedWordGetDto> UpdateAsync(int id , BannedWordUpdateDto dto);
    }
}
