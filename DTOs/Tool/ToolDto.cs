using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToolRental.DTOs.Tool
{
    public class ToolDto
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Tool Name must be 2 characters")]
        [MaxLength(128, ErrorMessage = "Tool Name cannot be over 128 characters")]

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }
        
        [Required]
        [Range(1, 100)]
        public decimal PricePerHour { get; set; }

    }
}
