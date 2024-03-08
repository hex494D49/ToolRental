using Microsoft.EntityFrameworkCore;
using ToolRental.Data;
using ToolRental.DTOs.Tool;
using ToolRental.Helpers;
using ToolRental.Interfaces;
using ToolRental.Models;

namespace ToolRental.Repository
{
    public class ToolRepository : IToolRepository
    {
        private readonly AppDbContext _context;

        public ToolRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Tool> CreateAsync(Tool tool)
        {
            await _context.Tools.AddAsync(tool);
            await _context.SaveChangesAsync();
            return tool;
        }

        public async Task<Tool?> DeleteAsync(int id)
        {
            var tool = await _context.Tools.FirstOrDefaultAsync(t => t.Id == id);

            if (tool == null)
            {
                return null;
            }

            _context.Tools.Remove(tool);
            await _context.SaveChangesAsync();
            return tool;
        }

        public async Task<List<Tool>> GetAllAsync()
        {
            return await _context.Tools.ToListAsync();
        }

        public async Task<List<Tool>> GetAllAsync(QueryObject query)
        {
            var tools = _context.Tools.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                tools = tools.Where(t => t.Name.Contains(query.Name));
            }


            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    tools = query.IsDecsending ? tools.OrderByDescending(t => t.Name) : tools.OrderBy(t => t.Name);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;


            return await tools.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Tool?> GetByIdAsync(int id)
        {
            return await _context.Tools.FirstOrDefaultAsync(t => t.Id == id);
        }

        public Task<bool> ToolExists(int id)
        {
            return _context.Tools.AnyAsync(t => t.Id == id);
        }

        public async Task<Tool?> UpdateAsync(int id, ToolDtoOnUpdate toolDto)
        {
            var tool = await _context.Tools.FirstOrDefaultAsync(t => t.Id == id);

            if (tool == null)
            {
                return null;
            }

            tool.Name = toolDto.Name;
            tool.Description = toolDto.Description;
            tool.PricePerHour = toolDto.PricePerHour;

            await _context.SaveChangesAsync();

            return tool;

        }
    }
}
