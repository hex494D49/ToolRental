using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToolRental.Application.Interfaces;
using ToolRental.Infrastructure.Interfaces;
using ToolRental.Web.DTOs.Helpers;
using ToolRental.Web.DTOs.Tool;
using ToolRental.Web.Mappers;

namespace ToolRental.Web.Controllers
{
    [Route("api/tools")]
    [ApiController]
    public class ToolController : ControllerBase
    {
        private readonly IToolService _service;

        public ToolController(IToolService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            var count = await _service.GetCount();
            var tools = await _service.GetAllAsync(query);
            var toolsDto = tools.Select(t => t.ToToolDto());

            var result = new
            {
                data = toolsDto,
                pager = new
                {
                    total = count,
                    current = query.PageNumber
                }
            };

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var tool = await _service.GetByIdAsync(id);

            if (tool == null)
            {
                return NotFound();
            }

            return Ok(tool.ToToolDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ToolOnCreateDto toolDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var tool = await _service.CreateAsync(toolDto);

            return CreatedAtAction(nameof(GetById), new { id = tool.Id }, tool.ToToolDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ToolOnUpdateDto toolDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var tool = await _service.UpdateAsync(id, toolDto);

            if (tool == null)
            {
                return NotFound();
            }

            return Ok(tool.ToToolDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var tool = await _service.DeleteAsync(id);

            if (tool == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
