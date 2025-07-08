using SGRH.Application.Dtos.RoomCategory;

namespace SGRH.Application.Dtos.Room;

public record class RoomDto : BaseDto
{
    public string? RoomNumber { get; set; }
    public RoomCategoryDto? Category { get; set; }
}
