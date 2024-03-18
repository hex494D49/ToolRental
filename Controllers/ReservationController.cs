using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToolRental.Application.Interfaces;
using ToolRental.Infrastructure.Interfaces;
using ToolRental.Web.DTOs.Helpers;
using ToolRental.Web.DTOs.Reservation;
using ToolRental.Web.DTOs.ReservationDetail;
using ToolRental.Web.Mappers;

namespace ToolRental.Web.Controllers
{
    [Route("api/reservations")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _service;

        public ReservationController(IReservationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            var count = await _service.GetCount();
            var reservationsDto = await _service.GetAllQueryable(query).Select(reservation =>
                new ReservationDto
                {
                    Id = reservation.Id,
                    FirstName = reservation.FirstName,
                    LastName = reservation.LastName,
                    Note = reservation.Note,
                    ReservationDetails = reservation
                                        .Details
                                        .Select(reservationDetail => new ReservationDetailDto
                                        {
                                            Id = reservationDetail.Id,
                                            ToolId = reservationDetail.ToolId,
                                            ToolName = reservationDetail.Tool.Name ?? string.Empty,
                                            StartingDateTime = reservationDetail.StartingDateTime,
                                            EndingDateTime = reservationDetail.EndingDateTime,
                                            PricePerHour = reservationDetail.PricePerHour,
                                        })
                                        .ToList()

                }).ToListAsync();

            reservationsDto.ForEach(r => r.Total = r.ReservationDetails.Sum(x => x.PricePerHour * (decimal)(x.EndingDateTime - x.StartingDateTime).TotalHours));

            var result = new
            {
                data = reservationsDto,
                pager = new
                {
                    total = count,
                    current = query.PageNumber
                }
            };

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            var reservation = await _service.GetByIdAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation.ToReservationDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ReservationOnCreateDto reservationDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reservation = await _service.CreateAsync(reservationDto);

            return CreatedAtAction(nameof(GetById), new { id = reservation.Id }, reservation.ToReservationDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ReservationOnUpdateDto reservationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reservation = await _service.UpdateAsync(id, reservationDto);

            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation.ToReservationDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var reservation = _service.DeleteAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
