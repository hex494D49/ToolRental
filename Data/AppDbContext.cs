using Microsoft.EntityFrameworkCore;
using ToolRental.Models;

namespace ToolRental.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {

        }

        public DbSet<Tool> Tools { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<ReservationDetail> ReservationDetails { get; set; }

        public DbSet<Customer> Customers{ get; set; }

    }
}
