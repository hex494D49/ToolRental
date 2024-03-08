namespace ToolRental.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public string Email { get; set; } = string.Empty;

        public List<Reservation>? Reservations { get; set; } = [];

    }
}
