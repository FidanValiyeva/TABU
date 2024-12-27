using AutoMapper;
using Babu.DAL;
using Babu.DTOs.Games;
using Babu.DTOs.Languages;
using Babu.Entities;
using Babu.Exceptions;
using Babu.Services.Abstarcts;
using Babu.Validators.Games;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Babu.Services.Implements
{
    public class GameService(BabuDbContext _context,IMapper _mapper) : IGameService
    {

        public async Task<Guid> CreateAsync(GameCreateDto dto)
        {           
            var game=_mapper.Map<Game>(dto);
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
            return game.Id;
        }
        public async Task<GameGetDto> UpdateAsync(string code,GameCreateDto dto)
        {
            var game = await _context.Games.FirstOrDefaultAsync(x => x.LanguageCode == code);         
            game.FailCount=dto.FailCount;
            game.SkipCount=dto.SkipCount;
            game.Time=dto.Time; 
            /*game.Score=dto.Score;
            game.SuccessAnswer=dto.SuccessAnswer;   
            game.WrongAnswer=dto.WrongAnswer;*/   
            game.LanguageCode=dto.LanguageCode; 
            await _context.SaveChangesAsync();
            return new GameGetDto
            {
                Id = game.Id,
                BannedWordCount=game.BannedWordCount,
                FailCount=game.FailCount,
                SkipCount=game.SkipCount,
                Time=game.Time,
                Score=game.Score,
                SuccessAnswer=game.SuccessAnswer,
                WrongAnswer=game.WrongAnswer,
                LanguageCode=game.LanguageCode  
            };           
         
        }
       
        public async Task<IEnumerable<GameGetDto>> GetAllAsync()
        {
            var datas = await _context.Games.ToListAsync();
            return _mapper.Map<IEnumerable<GameGetDto>>(datas);
        }

        //Task IGameService.CreateAsync(GameCreateDto dto)
        //{
        //    throw new NotImplementedException();
        //}

        public Task<GameGetDto> UpdateAsync(string code, GameUpdateDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task Start(Guid id)
        {
            if (await _context.Games.AnyAsync(x => x.Id == id && x.Score == null))
            {
                var game = await _context.Games.FirstOrDefaultAsync(x => x.Id == id && x.Score == null);
            }
            else
            {
                throw new GameNotFoundException();
            }
            GameStatusDto status = new GameStatusDto()
            {
                Fail = 0,
                Skip = 0,
                Success=0,
            };
        }

        public Task Fail(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Success(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Skip(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task End(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
