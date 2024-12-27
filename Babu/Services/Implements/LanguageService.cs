using AutoMapper;
using Babu.DAL;
using Babu.DTOs.Languages;
using Babu.Entities;
using Babu.Exceptions;
using Babu.Services.Abstarcts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Babu.Services.Implements
{
    public class LanguageService(BabuDbContext _context,IMapper _mapper) : ILanguageService
    {
        public async Task CreateAsync(LanguageCreateDto dto)
        {
            if (await _context.Languages.AnyAsync(x => x.Code == dto.Code))
                throw new LanguagesExistException();

            await _context.Languages.AddAsync(_mapper.Map<Language>(dto));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string code)
        {
            var entity = _context.Languages.FirstOrDefault(x=>x.Code==code);
            _context.Languages.Remove(entity);
            await   _context.SaveChangesAsync();
        }

        //public Task DeleteAsync(string code)
        //{
           
        //    throw new NotImplementedException();
        
        //}

        public async Task<IEnumerable<LanguagesGetDto>> GetAllAsync()
        {
            var datas =await _context.Languages.ToListAsync();
            return _mapper.Map<IEnumerable<LanguagesGetDto>>(datas);    
        }

         
        public async Task<LanguagesGetDto> UpdateAsync (string code,LanguageUpdateDto dto)
        {
            var language=await _context.Languages.FirstOrDefaultAsync(  x=>x.Code==code);
            language.Name = dto.Name;
            language.Icon = dto.Icon;
            await _context.SaveChangesAsync();
            return new LanguagesGetDto
            {
                Code = language.Code,
                Name = language.Name,
                Icon = language.Icon,
            };
        }

       
    }
}
