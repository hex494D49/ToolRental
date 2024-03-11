using ToolRental.DTOs.Tool;
using ToolRental.Helpers;
using ToolRental.Models;

namespace ToolRental.Interfaces
{
    public interface IToolRepository
    {
        Task<List<Tool>> GetAllAsync(QueryObject query);
        Task<Tool?> GetByIdAsync(int id);
        Task<Tool> CreateAsync(Tool tool);
        Task<Tool?> UpdateAsync(int id, ToolDtoOnUpdate stockDto);
        Task<Tool?> DeleteAsync(int id);
        Task<int> GetCount();
        Task<bool> ToolExists(int id);
    }
}
