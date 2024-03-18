using Toolental.Domain.Models;
using ToolRental.Web.DTOs.Reservation;
using ToolRental.Web.DTOs.ReservationDetail;
using ToolRental.Web.Mappers;

namespace ToolRental.Web.Mappers
{
    public static class ReservationMappers
    {
        public static ReservationDto ToReservationDto(this Reservation reservation)
        {
            return new ReservationDto
            {
                Id = reservation.Id,
                FirstName = reservation.FirstName,
                LastName = reservation.LastName,
                Note = reservation.Note,
                ReservationDetails = reservation
                                    .Details
                                    .Select(r => r.ToReservationDetailDto())
                                    .ToList(),
                Total = reservation.Details.Sum(x => x.PricePerHour * (decimal)(x.EndingDateTime - x.StartingDateTime).TotalHours)
            };

        }

        public static Reservation ToReservationDtoOnCreate(this ReservationOnCreateDto reservationDto)
        {
            return new Reservation
            {
                FirstName = reservationDto.FirstName,
                LastName = reservationDto.LastName,
                DateAdded = DateTime.Now,
                LastModified = DateTime.Now,
                Note = reservationDto.Note,
                Status = 1,
                Details = reservationDto
                                    .Details
                                    .Select(r => new ReservationDetail
                                    {
                                        ToolId = r.ToolId,
                                        StartingDateTime = r.StartingDateTime,
                                        EndingDateTime = r.EndingDateTime,
                                        PricePerHour = r.PricePerHour
                                    })
                                    .ToList()
            };
        }

        // ovo se ne kristi nigdje
        public static Reservation ToReservationDtoOnUpdate(this ReservationOnUpdateDto reservationDto)
        {
            return new Reservation
            {
                Id = reservationDto.Id,
                FirstName = reservationDto.FirstName,
                LastName = reservationDto.LastName,
                Note = reservationDto.Note,
                LastModified = DateTime.Now,
                Details = reservationDto
                                    .ReservationDetails
                                    .Select(r => r.ToReservationDetail())
                                    .ToList()
            };
        }

    }
}
