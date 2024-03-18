using Toolental.Domain.Models;
using ToolRental.Web.DTOs.Tool;

namespace ToolRental.Web.Mappers
{
    public static class ToolMappers
    {
        public static ToolDto ToToolDto(this Tool tool)
        {
            return new ToolDto
            {
                Id = tool.Id,
                Name = tool.Name,
                Description = tool.Description,
                PricePerHour = tool.PricePerHour
            };
        }

        public static Tool ToTool(this ToolDto toolDto)
        {
            return new Tool
            {
                Id = toolDto.Id,
                Name = toolDto.Name,
                Description = toolDto.Description,
                PricePerHour = toolDto.PricePerHour
            };
        }

        public static Tool ToTool(this ToolOnCreateDto toolOnCreateDto)
        {
            return new Tool
            {
                Name = toolOnCreateDto.Name,
                Description = toolOnCreateDto.Description,
                PricePerHour = toolOnCreateDto.PricePerHour
            };
        }

        public static Tool ToTool(this ToolOnUpdateDto toolOnUpdatDto)
        {
            return new Tool
            {
                Id = toolOnUpdatDto.Id,
                Name = toolOnUpdatDto.Name,
                Description = toolOnUpdatDto.Description,
                PricePerHour = toolOnUpdatDto.PricePerHour
            };
        }

    }
}
