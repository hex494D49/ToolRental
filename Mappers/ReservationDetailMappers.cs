using ToolRental.DTOs.ReservationDetail;
using ToolRental.Models;

namespace ToolRental.Mappers
{
    public static class ReservationDetailMappers
    {
        public static ReservationDetailDto ToReservationDetailDto(this ReservationDetail reservationDetail)
        {
            return new ReservationDetailDto
            {
                Id = reservationDetail.Id,
                ReservationId = reservationDetail.ReservationId,
                ToolId = reservationDetail.ToolId,
                StartingDateTime = reservationDetail.StartingDateTime,
                EndingDateTime = reservationDetail.EndingDateTime,
                PricePerHour = reservationDetail.PricePerHour
            };
        }
    }
}
