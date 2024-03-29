﻿using System.ComponentModel.DataAnnotations.Schema;
using ToolRental.Application.Interfaces;

namespace ToolRental.Web.DTOs.ReservationDetail
{
    public class ReservationDetailDto : IReservationDetail
    {
        public int Id { get; set; }

        public int ToolId { get; set; }

        public string ToolName { get; set; } = string.Empty;

        public DateTime StartingDateTime { get; set; }

        public DateTime EndingDateTime { get; set; }

        public decimal PricePerHour { get; set; }

    }
}
