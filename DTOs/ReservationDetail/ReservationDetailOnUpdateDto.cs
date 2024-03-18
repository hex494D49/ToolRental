namespace ToolRental.Web.DTOs.ReservationDetail
{
    public class ReservationDetailOnUpdateDto
    {
        public int Id { get; set; }

        public int ToolId { get; set; }

        public DateTime StartingDateTime { get; set; }

        public DateTime EndingDateTime { get; set; }

        public decimal PricePerHour { get; set; }

    }
}
