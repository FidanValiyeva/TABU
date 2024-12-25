using AutoMapper;
using Babu.DTOs.Languages;
using Babu.Entities;
using Babu.Exceptions;
using Babu.Services.Abstarcts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Babu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LanguagesController(ILanguageService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllAsync());
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
             
               await _service.CreateAsync(dto); 
               return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update()
        {
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            return Ok();
        }
    }
}
