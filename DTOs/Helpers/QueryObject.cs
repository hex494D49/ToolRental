using ToolRental.Infrastructure.Interfaces;

namespace ToolRental.Web.DTOs.Helpers
{
    public class QueryObject : IQueryObject
    {
        public string? Name { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool IsDecsending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;

    }
}
