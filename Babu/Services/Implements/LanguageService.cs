using AutoMapper;
using Babu.DAL;
using Babu.DTOs.Languages;
using Babu.Entities;
using Babu.Services.Abstarcts;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Babu.Services.Implements
{
    public class LanguageService(BabuDbContext _context,IMapper _mapper) : ILanguageService
    {
        public async Task CreateAsync(LanguageCreateDto dto)
        {
            if (await _context.Languages.AnyAsync(x => x.Code == dto.Code))
                throw new LanguageExistException();

            await _context.Languages.AddAsync(_mapper.Map<Language>(dto));
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LanguagesGetDto>> GetAllAsync()
        {
            var datas =await _context.Languages.ToListAsync();
            return _mapper.Map<IEnumerable<LanguagesGetDto>>(datas);    
        }

        Task<IEnumerable> ILanguageService.GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
