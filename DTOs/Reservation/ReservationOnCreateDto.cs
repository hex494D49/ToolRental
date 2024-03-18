using ToolRental.Application.Interfaces;

namespace ToolRental.Web.DTOs.Reservation
{
    public class ReservationOnCreateDto : IReservationOnCreate
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string? Note { get; set; }

        public IEnumerable<IReservationDetailOnCreate> Details { get; set; } = [];

    }
}
