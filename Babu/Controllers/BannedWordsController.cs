using Babu.DAL;
using Babu.DTOs.BannedWords;
using Babu.DTOs.Languages;
using Babu.Exceptions;
using Babu.Services.Abstarcts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Memory;

namespace Babu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannedWordsController(IBannedWordService _service,IMemoryCache _cache) : ControllerBase
    {
        [HttpGet("[action]")]
        public async Task<IActionResult> Get(string key)
        {
            return Ok(_cache.Get(key));

        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Update(int id,BannedWordUpdateDto dto)
        {
            try
            {
                await _service.UpdateAsync(id, dto);
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
