using ToolRental.Application.Interfaces;
using ToolRental.Web.DTOs.ReservationDetail;

namespace ToolRental.Web.DTOs.Reservation
{
    public class ReservationOnUpdateDto : IReservationOnUpdate
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string? Note { get; set; }

        public int Status { get; set; }

        public IEnumerable<IReservationDetail> ReservationDetails { get; set; } = new List<ReservationDetailDto>();
    }
}
