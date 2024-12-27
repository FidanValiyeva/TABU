using AutoMapper;
using Babu.DAL;
using Babu.DTOs.Games;
using Babu.DTOs.Languages;
using Babu.DTOs.Words;
using Babu.Entities;
using Babu.Services.Abstarcts;
using Microsoft.EntityFrameworkCore;

namespace Babu.Services.Implements
{
    public class WordService(BabuDbContext _context,IMapper _mapper) : IWordService
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

        public async Task<WordGetDto> UpdateAsync(int id , WordUpdateDto dto)
        {
            var word = await _context.Words.FirstOrDefault(x => x.Id == id);
            word.Text=dto.Text;
            word.LanguageCode=dto.LanguageCode;
            word.BannedWords=dto.BannedWords;
            await _context.SaveChangesAsync();
            return new WordGetDto
            {
                Text=word.Text,
                LanguageCode=dto.LanguageCode,
                BannedWords=dto.BannedWords
            };           
        }
        public async Task<IEnumerable<WordGetDto>> GetAllAsync()
        {
            var datas = await _context.Languages.ToListAsync();
            return _mapper.Map<IEnumerable<WordGetDto>>(datas);
        }

        public Task<int> UpdateAsync(WordUpdateDto dto)
        {
            throw new NotImplementedException();
        }

        Task<int> IWordService.DeleteAsync(int code)
        {
            throw new NotImplementedException();
        }
    }
}
