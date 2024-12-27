using AutoMapper;
using Babu.DAL;
using Babu.DTOs.Games;
using Babu.DTOs.Languages;
using Babu.DTOs.Words;
using Babu.Entities;
using Babu.Services.Abstarcts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Babu.Services.Implements
{
    public class WordService(BabuDbContext _context, IMapper _mapper) : IWordService
    {

        public async Task<int> CreateAsync(WordCreateDto dto)
        {
            Word word = new Word
            {
                LanguageCode = dto.LanguageCode,
                Text = dto.Text,
            };
            word.BannedWords = dto.BannedWords.Select(x => new BannedWord
            {
                Text = x
            }).ToList();           
            await _context.Words.AddAsync(word);
            await _context.SaveChangesAsync();
            return word.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = _context.Words.FirstOrDefault( x => x.Id == id);
            _context.Words.Remove(entity);
            await _context.SaveChangesAsync();  
        }

        /*public async Task UpdateAsync(int , WordUpdateDto dto)
        {
            var word = await _context.Words.Include(x => x.BannedWords).FirstOrDefaultAsync(x => x.Id == id);
            word.Text = dto.Text;
            word.LanguageCode = dto.LanguageCode;

            _mapper.Map(dto, word);
            await _context.SaveChangesAsync();

        }*/
        public async Task<IEnumerable<WordGetDto>> GetAllAsync()
        {
            return await _context.Words
               .Include(x => x.BannedWords)
               .Select(x => new WordGetDto
               {
                   LanguageCode = x.LanguageCode,
                   Text = x.Text,
                   BannedWords = x.BannedWords.Select(x => x.Text).ToList()
               }).ToListAsync();
        }

       

        /*Task<int> IWordService.DeleteAsync(int code)
        {
            throw new NotImplementedException();
        }*/

        Task IWordService.CreateAsync(WordCreateDto dto)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<WordGetDto>> IWordService.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<WordGetDto> IWordService.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        

        Task IWordService.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
