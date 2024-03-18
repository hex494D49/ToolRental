using System.ComponentModel.DataAnnotations;
using ToolRental.Web.DTOs.ReservationDetail;

namespace ToolRental.Web.DTOs.Reservation
{
    public class ReservationDto
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "First Name must be 2 characters")]
        [MaxLength(32, ErrorMessage = "First Name cannot be over 32 characters")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MinLength(2, ErrorMessage = "Last Name must be 2 characters")]
        [MaxLength(32, ErrorMessage = "Last Name cannot be over 32 characters")]
        public string LastName { get; set; } = string.Empty;

        public string? Note { get; set; }

        public List<ReservationDetailDto> ReservationDetails { get; set; } = new List<ReservationDetailDto>();

        //public decimal Total => ReservationDetails.Sum(x => x.SubTotal);

        public decimal Total { get; set; }
    }
}