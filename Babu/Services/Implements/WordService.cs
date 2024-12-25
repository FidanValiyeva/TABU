using Babu.DAL;
using Babu.DTOs.Words;
using Babu.Entities;
using Babu.Services.Abstarcts;

namespace Babu.Services.Implements
{
    public class WordService(BabuDbContext _context) : IWordService
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
    }
}
