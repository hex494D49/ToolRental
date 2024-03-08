using ToolRental.DTOs.Tool;
using ToolRental.Models;

namespace ToolRental.Mappers
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

        public static Tool ToToolDtoOnCreate(this ToolDtoOnCreate toolDto)
        {
            return new Tool
            {
                Name = toolDto.Name,
                Description = toolDto.Description,
                PricePerHour = toolDto.PricePerHour
            };
        }

    }
}
