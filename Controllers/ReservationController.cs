using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToolRental.Data;
using ToolRental.DTOs.Reservation;
using ToolRental.DTOs.Tool;
using ToolRental.Mappers;

namespace ToolRental.Controllers
{
    [Route("/reservations")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private protected AppDbContext _context;

        public ReservationController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            //var reservations = _context.Reservations.ToList().Select(r => r.ToReservationDto());

            
            var reservations = _context.Reservations
                                .Include(r => r.ReservationDetails)
                                .AsQueryable()
                                .ToList();

            return Ok(reservations);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {

            var reservation = _context.Reservations
                                      .Include(r => r.ReservationDetails)
                                      .FirstOrDefault(r => r.Id == id);

            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation.ToReservationDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ReservationDtoOnCreate toolDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var tool = toolDto;

            //return CreatedAtAction(nameof(GetById), new { id = tool.Id }, tool.ToReservationDto());

            return CreatedAtAction(nameof(tool), tool);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ReservationDtoOnUpdate toolDto)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {

            return NoContent();
        }

    }
}
