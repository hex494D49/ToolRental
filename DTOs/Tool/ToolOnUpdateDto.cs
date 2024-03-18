using System.ComponentModel.DataAnnotations;
using ToolRental.Application.Interfaces;

namespace ToolRental.Web.DTOs.Tool
{
    public class ToolOnUpdateDto : IToolOnUpdate
    {
        public int Id { get; set; }

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
