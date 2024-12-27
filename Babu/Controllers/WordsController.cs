﻿using Babu.DTOs.Words;
using Babu.Exceptions;
using Babu.Services.Abstarcts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Memory;

namespace Babu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController(IWordService _service,IMemoryCache _cache) : Controller
    {
        [HttpGet]
        public IActionResult Get(string key)
        {
            return Ok(_cache.Get(key));
        }

       [HttpPost]
        public async Task<IActionResult> Create(WordCreateDto dto)
        {           
            return View(await _service.CreateAsync(dto));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateMany(List<WordCreateDto> dto)
        {
            foreach (var item in dto)
            {
                await _service.CreateAsync(item);   
            }
           
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(string code,WordUpdateDto dto)
        {
            try
            {
                await _service.UpdateAsync(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex is IBaseException bEx)
                {
                    return StatusCode(bEx.StatusCode, new
                    {
                        Message = bEx.ErrorMessage,
                        StatusCode = bEx.StatusCode

                    });
                }
                else
                {
                    return BadRequest(new
                    {

                        Message = ex.Message

                    });
                }
            }
        }
        
       
    }
}
