using System.ComponentModel.DataAnnotations.Schema;
using ToolRental.DTOs.Reservation;
using ToolRental.DTOs.Tool;

namespace ToolRental.DTOs.ReservationDetail
{
    public class ReservationDetailDto
    {
        public int Id { get; set; }

        public int ReservationId { get; set; }

        public int ToolId { get; set; }

        public DateTime StartingDateTime { get; set; }

        public DateTime EndingDateTime { get; set; }

        public decimal PricePerHour { get; set; }

        public ReservationDto? Reservation { get; set; } = null;

        public ToolDto? Tool { get; set; } = null;

    }
}
