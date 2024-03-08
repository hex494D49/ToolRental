using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToolRental.DTOs.Tool
{
    public class ToolDtoOnCreate
    {
        [Required]
        [MaxLength(128, ErrorMessage = "Name cannot be over 128 characters")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(256, ErrorMessage = "Description cannot be over 256 characters")]
        public string? Description { get; set; }

        [Required]
        [Range(1, 100)]
        public decimal PricePerHour { get; set; }

    }
}
