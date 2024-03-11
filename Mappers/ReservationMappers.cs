using ToolRental.DTOs.Reservation;
using ToolRental.DTOs.Tool;
using ToolRental.Models;

namespace ToolRental.Mappers
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
                                    .ReservationDetails
                                    .Select(r => r.ToReservationDetailDto())
                                    .ToList()
            };
        }

        public static ReservationDto ToReservationDtoOnUpdate(this Reservation reservation)
        {
            return new ReservationDto
            {
                Id = reservation.Id,
                FirstName = reservation.FirstName,
                LastName = reservation.LastName,
                Note = reservation.Note,
                ReservationDetails = reservation
                                    .ReservationDetails
                                    .Select(r => r.ToReservationDetailDto())
                                    .ToList()
            };
        }

        public static Reservation ToReservationDtoOnCreate(this Reservation reservation)
        {
            return new Reservation
            {
                Id = reservation.Id,
                FirstName = reservation.FirstName,
                LastName = reservation.LastName,
                DateAdded = reservation.DateAdded,
                LastModified = reservation.LastModified,
                Note = reservation.Note,
                Status = reservation.Status
            };
        }

    }
}
