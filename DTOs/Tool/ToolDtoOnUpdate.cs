using System.ComponentModel.DataAnnotations;

namespace ToolRental.DTOs.Tool
{
    public class ToolDtoOnUpdate
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
