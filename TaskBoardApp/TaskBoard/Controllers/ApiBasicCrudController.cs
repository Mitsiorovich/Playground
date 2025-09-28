using Microsoft.AspNetCore.Mvc;
using TaskBoard.Application.Services.Interfaces;

namespace TaskBoard.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiBasicCrudController<TDto> : ControllerBase where TDto : class
    {
        private readonly ICrudService<TDto> _service;

        public ApiBasicCrudController(ICrudService<TDto> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dtos = await _service.GetAllAsync();
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null) return NotFound();
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = _service.GetId(created) }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] TDto dto)
        {
            if (id != _service.GetId(dto)) return BadRequest();

            var updated = await _service.UpdateAsync(dto);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteByIdAsync(id);
            return NoContent();
        }
    }
}
