using Babu.DTOs.Words;
using Babu.Services.Abstarcts;
using Microsoft.AspNetCore.Mvc;

namespace Babu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController(IWordService _service) : Controller
    {
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
    }
}
