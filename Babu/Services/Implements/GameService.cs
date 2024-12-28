using AutoMapper;
using Babu.DAL;
using Babu.DTOs.Games;
using Babu.DTOs.Languages;
using Babu.DTOs.Words;
using Babu.Entities;
using Babu.Exceptions;
using Babu.Services.Abstarcts;
using Babu.Validators.Games;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Babu.Services.Implements
{
    public class GameService(BabuDbContext _context,IMapper _mapper,IMemoryCache _cache) : IGameService
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

        public async Task<WordForGameDto> Start(Guid id)
        {
            var game= await _context.Games.FindAsync(id);
            if (game==null || game.Score != null)
            {
                throw new GameNotFoundException();
            }


            IQueryable<Word> query = _context.Words
           .Where(x => x.LanguageCode == game.LanguageCode);
            var words=await query
                 .Select(x => new WordForGameDto
                 {
                     Id=x.Id,
                     Word=x.Text,
                     BannedWords=x.BannedWords.Select(y=>y.Text)
                 }).ToListAsync();
            var wordsStack=new Stack<WordForGameDto>(words);  
            WordForGameDto currentWord = wordsStack.Pop();
            GameStatusDto status = new GameStatusDto()
            {
                Fail = 0,
                Skip = 0,
                Success = 0,
                Words = wordsStack,
                MaxSkipCount = game.SkipCount,
                UsedWordIds = words.Select(x=>x.Id)

            };
            _cache.Set(id, status,TimeSpan.FromSeconds(300));
            return currentWord;

        }

        public Task Fail(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Success(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<WordForGameDto> Skip(Guid id)
        {
            var status = _getCurrentGame(id);
            if (status.Skip <= status.MaxSkipCount)
            {

                var currentword=status.Words.Pop();
                status.Skip++;
                _cache.Set(id, status,TimeSpan.FromSeconds(300));
                return currentword;

            }
           return null;
        }

        public Task End(Guid id)
        {
            throw new NotImplementedException();
        }
        GameStatusDto _getCurrentGame(Guid id)
        {
            var result =_cache.Get<GameStatusDto>(id);
            if (result == null)
                throw new Exception();
            {
                return result;
            }
        }
    }
}
