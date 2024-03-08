﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ToolRental.Models
{
    public class Tool
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal PricePerHour { get; set; }

    }
}