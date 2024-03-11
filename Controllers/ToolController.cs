using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToolRental.Data;
using ToolRental.DTOs.Tool;
using ToolRental.Helpers;
using ToolRental.Interfaces;
using ToolRental.Mappers;

namespace ToolRental.Controllers
{
    [Route("/tools")]
    [ApiController]
    public class ToolController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IToolRepository _repository;


        public ToolController(AppDbContext context, IToolRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            var count = await _repository.GetCount();
            var tools = await _repository.GetAllAsync(query);  
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

            var tool = await _repository.GetByIdAsync(id);

            if (tool == null)
            {
                return NotFound();
            }

            return Ok(tool.ToToolDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ToolDtoOnCreate toolDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var tool = toolDto.ToToolDtoOnCreate();
            await _repository.CreateAsync(tool);

            return CreatedAtAction(nameof(GetById), new { id = tool.Id }, tool.ToToolDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ToolDtoOnUpdate toolDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var tool = await _repository.UpdateAsync(id, toolDto);

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
            var tool = await _repository.DeleteAsync(id);

            if (tool == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
