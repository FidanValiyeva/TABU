using Babu.Entities;
using Babu.Validators.Games;

namespace Babu.Services.Abstarcts
{
    public interface IGameService
    {
        Task CreateAsync(GameCreateDto dto);
        Task Start(Guid id);

    }
}
