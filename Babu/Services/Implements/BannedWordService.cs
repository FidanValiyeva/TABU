using AutoMapper;
using Babu.DAL;
using Babu.DTOs.BannedWords;
using Babu.DTOs.Languages;
using Babu.Entities;
using Babu.Services.Abstarcts;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Babu.Services.Implements
{
    public class BannedWordService(BabuDbContext _context,Mapper _mapper) : IBannedWordService
    {
        public async Task<IEnumerable> GetWordAsync(string word)
        {
            var datas = await _context.Words.ToListAsync();
            return _mapper.Map<IEnumerable<BannedWordGetDto>>(datas);
        }
        public async Task<BannedWordGetDto> UpdateAsync(int id, BannedWordUpdateDto dto)
        {
            var BannedWord=await _context.Words.SingleOrDefaultAsync(   x => x.Id == id);
            BannedWord.Text = dto.Text;
            BannedWord.Id = dto.Id;           
            await _context.SaveChangesAsync();
            return new BannedWordGetDto
            {
                Text=BannedWord.Text,
                Id=BannedWord.Id
              
            };


        }

        Task<string> IBannedWordService.GetWordAsync(string word)
        {
            throw new NotImplementedException();
        }
    }
}
