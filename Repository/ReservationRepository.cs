using ToolRental.Data;
using ToolRental.DTOs.Reservation;
using ToolRental.Helpers;
using ToolRental.Interfaces;
using ToolRental.Models;

namespace ToolRental.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly AppDbContext _context;

        public ReservationRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<Reservation> CreateAsync(Tool tool)
        {
            throw new NotImplementedException();
        }

        public Task<Tool?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Reservation>> GetAllAsync(QueryObject query)
        {
            throw new NotImplementedException();
        }

        public Task<Reservation?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ToolExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Reservation?> UpdateAsync(int id, ReservationDto toolDto)
        {
            throw new NotImplementedException();
        }
    }
}
