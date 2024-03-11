using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Reservation>> GetAllAsync(QueryObject query)
        {
            var reservations = _context.Reservations.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                reservations = reservations.Where(r => r.FirstName.Contains(query.Name) || r.LastName.Contains(query.Name));
            }


            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    reservations = query.IsDecsending ? reservations.OrderByDescending(r => r.FirstName) : reservations.OrderBy(r => r.FirstName);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;


            return await reservations.Skip(skipNumber).Take(query.PageSize).ToListAsync();

        }

        public async Task<Reservation?> GetByIdAsync(int id)
        {
            return await _context.Reservations.FirstOrDefaultAsync(r => r.Id == id);
        }


        public async Task<Reservation> CreateAsync(Reservation reservation)
        {
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }

        public async Task<Reservation?> UpdateAsync(int id, ReservationDto reservationDto)
        {
            var reservation = await _context.Reservations.FirstOrDefaultAsync(r => r.Id == id);

            if (reservation == null)
            {
                return null;
            }

            reservation.FirstName = reservationDto.FirstName;
            reservation.LastName = reservationDto.LastName;
            reservation.Note = reservationDto.Note;
            reservation.LastModified = DateTime.Now;

            await _context.SaveChangesAsync();

            return reservation;
        }

        public async Task<Reservation?> DeleteAsync(int id)
        {
            var reservation = await _context.Reservations.FirstOrDefaultAsync(r => r.Id == id);

            if (reservation == null)
            {
                return null;
            }

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }

        public async Task<int> GetCount()
        {
            return await _context.Reservations.CountAsync();
        }

        public async Task<bool> ReservationlExists(int id)
        {
            return await _context.Reservations.AnyAsync(r => r.Id == id);
        }
    }
}
