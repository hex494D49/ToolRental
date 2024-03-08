using ToolRental.DTOs.Reservation;
using ToolRental.DTOs.Tool;
using ToolRental.Helpers;
using ToolRental.Models;

namespace ToolRental.Interfaces
{
    public interface IReservationRepository
    {
        Task<List<Reservation>> GetAllAsync(QueryObject query);
        Task<Reservation?> GetByIdAsync(int id);
        Task<Reservation> CreateAsync(Tool tool);
        Task<Reservation?> UpdateAsync(int id, ReservationDto toolDto);
        Task<Tool?> DeleteAsync(int id);
        Task<bool> ToolExists(int id);

    }
}
