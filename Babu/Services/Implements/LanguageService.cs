using Babu.DAL;
using Babu.DTOs.Languages;
using Babu.Services.Abstarcts;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Babu.Services.Implements
{
    public class LanguageService(BabuDbContext _context) : ILanguageService
    {
        public async Task CreateAsync(LanguageCreateDto dto)
        {
            await _context.AddAsync(new Entities.Language
            {
                Code = dto.Code,
                Name = dto.Name,
                Icon = dto.Icon,
            });
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LanguagesGetDto>> GetAllAsync()
        {
            return await _context.Languages.Select(x => new LanguagesGetDto
            {
                Code = x.Code,
                Name = x.Name,
                Icon = x.Icon,
            }).ToListAsync();   
        }

        Task<IEnumerable> ILanguageService.GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
