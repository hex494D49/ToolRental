using System.ComponentModel.DataAnnotations.Schema;

namespace ToolRental.Models
{
    public class ReservationDetail
    {
        public int Id { get; set; }

        public int ReservationId { get; set; }

        public int ToolId { get; set; }

        public DateTime StartingDateTime { get; set; }

        public DateTime EndingDateTime { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal PricePerHour { get; set; }

        public Reservation? Reservation { get; set; } = null;

        public Tool? Tool { get; set; } = null;

    }
}
