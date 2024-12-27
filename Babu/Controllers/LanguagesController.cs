using AutoMapper;
using Babu.DTOs.Languages;
using Babu.Entities;
using Babu.Exceptions;
using Babu.Services.Abstarcts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Memory;

namespace Babu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LanguagesController(ILanguageService _service,IMemoryCache _cache) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(string key)
        {
            return Ok(_cache.Get(key));
        }
        [HttpPost]
        public async Task<IActionResult> Create(LanguageCreateDto dto)
        {
            try
            {
                await _service.CreateAsync(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex is IBaseException bEx)
                {
                    return StatusCode(bEx.StatusCode,new
                    {
                        Message=bEx.ErrorMessage,
                        StatusCode = bEx.StatusCode
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        Message=ex.Message
                    });  
                }

            }                         
             
        }
        [HttpPut]
        public async Task<IActionResult> Update(string code,LanguageUpdateDto dto)
        {
            
                await _service.UpdateAsync(code,dto);
                     return Ok();
                   
        }
        [HttpDelete]
        public async Task Delete(string code)
        {
            await _service.DeleteAsync(code);
        }
    }
}
