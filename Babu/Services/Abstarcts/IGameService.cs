using Babu.DTOs.Games;
using Babu.DTOs.Languages;
using Babu.DTOs.Words;
using Babu.Entities;
using Babu.Validators.Games;

namespace Babu.Services.Abstarcts
{
    public interface IGameService
    {
        Task<Guid> CreateAsync(GameCreateDto dto);
        Task<IEnumerable<GameGetDto>> GetAllAsync();
              
        Task <GameGetDto>UpdateAsync(string code,GameUpdateDto dto);
        Task<WordForGameDto> Start(Guid id);
        Task Fail(Guid id);
        Task Success(Guid id);
        Task <WordForGameDto>Skip(Guid id);
        Task End(Guid id);
    }
}
