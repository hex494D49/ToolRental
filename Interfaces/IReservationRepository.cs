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
        Task<Reservation> CreateAsync(Reservation tool);
        Task<Reservation?> UpdateAsync(int id, ReservationDto toolDto);
        Task<Reservation?> DeleteAsync(int id);
        Task<bool> ReservationlExists(int id);
        Task<int> GetCount();

    }
}
