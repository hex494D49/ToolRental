using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToolRental.Application.Interfaces;

namespace ToolRental.Web.DTOs.Tool
{
    public class ToolOnCreateDto : IToolOnCreate
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
