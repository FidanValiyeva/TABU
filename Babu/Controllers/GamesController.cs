﻿using Babu.Services.Abstarcts;
using Babu.Validators.Games;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Babu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController(IGameService _service,IMemoryCache _cache) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult>Create(GameCreateDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> Get (string key)
        {
           return Ok( _cache.Get(key));
           
        }
        [HttpGet("[action]")]   
        public async Task<IActionResult> Set(string key,string value)
        {            
            return Ok(_cache.Set(key, value, DateTime.Now.AddSeconds(20)));
        }
    }
}