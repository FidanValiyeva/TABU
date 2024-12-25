using AutoMapper;
using Babu.DAL;
using Babu.Entities;
using Babu.Services.Abstarcts;
using Babu.Validators.Games;

namespace Babu.Services.Implements
{
    public class GameService(BabuDbContext _context,IMapper _mapper) : IGameService
    {

        public async Task<Guid> CreateAsync(Game dto)
        {
            var game=_mapper.Map<Game>(dto);
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
            return game.Id;
        }

        public Task CreateAsync(GameCreateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task Start(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
