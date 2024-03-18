using Toolental.Domain.Models;
using ToolRental.Application.Interfaces;
using ToolRental.Web.DTOs.ReservationDetail;

namespace ToolRental.Web.Mappers
{
    public static class ReservationDetailMappers
    {
        public static ReservationDetailDto ToReservationDetailDto(this ReservationDetail reservationDetail)
        {
            return new ReservationDetailDto
            {
                Id = reservationDetail.Id,
                ToolId = reservationDetail.ToolId,
                ToolName = reservationDetail.Tool?.Name ?? string.Empty,
                StartingDateTime = reservationDetail.StartingDateTime,
                EndingDateTime = reservationDetail.EndingDateTime,
                PricePerHour = reservationDetail.PricePerHour,
            };
        }

        public static ReservationDetail ToReservationDetail(this IReservationDetail reservationDetailDto)
        {
            return new ReservationDetail
            {
                Id = reservationDetailDto.Id,
                ToolId = reservationDetailDto.ToolId,
                StartingDateTime = reservationDetailDto.StartingDateTime,
                EndingDateTime = reservationDetailDto.EndingDateTime,
                PricePerHour = reservationDetailDto.PricePerHour
            };
        }

        public static ReservationDetail ToReservationDetail(this ReservationDetailOnCreateDto reservationDetailDto)
        {
            return new ReservationDetail
            {
                ToolId = reservationDetailDto.ToolId,
                StartingDateTime = reservationDetailDto.StartingDateTime,
                EndingDateTime = reservationDetailDto.EndingDateTime,
                PricePerHour = reservationDetailDto.PricePerHour
            };
        }

        public static ReservationDetail ToReservationDetail(this ReservationDetailOnUpdateDto reservationDetailDto)
        {
            return new ReservationDetail
            {
                Id = reservationDetailDto.Id,
                ToolId = reservationDetailDto.ToolId,
                StartingDateTime = reservationDetailDto.StartingDateTime,
                EndingDateTime = reservationDetailDto.EndingDateTime,
                PricePerHour = reservationDetailDto.PricePerHour
            };
        }

    }
}
