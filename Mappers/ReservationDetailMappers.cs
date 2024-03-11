using ToolRental.DTOs.ReservationDetail;
using ToolRental.DTOs.Tool;
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

        public static ReservationDetail ToReservationDetail(this ReservationDetailDto reservationDetailDto)
        {
            return new ReservationDetail
            {
                Id = reservationDetailDto.Id,
                ReservationId = reservationDetailDto.ReservationId,
                ToolId = reservationDetailDto.ToolId,
                StartingDateTime = reservationDetailDto.StartingDateTime,
                EndingDateTime = reservationDetailDto.EndingDateTime,
                PricePerHour = reservationDetailDto.PricePerHour
            };
        }

        public static ReservationDetail ToReservationDetailDtoOnCreate(this ReservationDetail reservationDetailDto)
        {
            return new ReservationDetail
            {
                ReservationId = reservationDetailDto.ReservationId,
                ToolId = reservationDetailDto.ToolId,
                StartingDateTime = reservationDetailDto.StartingDateTime,
                EndingDateTime = reservationDetailDto.EndingDateTime,
                PricePerHour = reservationDetailDto.PricePerHour
            };
        }

        public static ReservationDetail ToReservationDetailDtoOnUpdate(this ReservationDetail reservationDetailDto)
        {
            return new ReservationDetail
            {
                Id = reservationDetailDto.Id,
                ReservationId = reservationDetailDto.ReservationId,
                ToolId = reservationDetailDto.ToolId,
                StartingDateTime = reservationDetailDto.StartingDateTime,
                EndingDateTime = reservationDetailDto.EndingDateTime,
                PricePerHour = reservationDetailDto.PricePerHour
            };
        }

    }
}
