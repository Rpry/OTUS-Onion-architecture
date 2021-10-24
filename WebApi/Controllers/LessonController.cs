using System.Threading.Tasks;
using BusinessLogic.Abstractions;
using BusinessLogic.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LessonController: ControllerBase
    {
        private ILessonService _service;
        private readonly ILogger<LessonController> _logger;

        public LessonController(ILessonService service, ILogger<LessonController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(LessonDto lessonDto)
        {
            return Ok(await _service.Create(lessonDto));
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, LessonDto lessonDto)
        {
            await _service.Update(id, lessonDto);
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
        
        [HttpGet("list/{page}/{itemsPerPage}")]
        public async Task<IActionResult> GetList(int page, int itemsPerPage)
        {
            return Ok(await _service.GetPaged(page, itemsPerPage));
        }
    }
}