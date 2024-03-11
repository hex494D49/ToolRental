using ToolRental.DTOs.ReservationDetail;

namespace ToolRental.DTOs.Reservation
{
    public class ReservationDtoOnCreate
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string? Note { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.Now;

        public DateTime LastModified { get; set; } = DateTime.Now;

        public int Status { get; set; }

        public List<ReservationDetailDto> ReservationDetails { get; set; } = [];

    }
}
