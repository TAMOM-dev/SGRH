
using SGRH.Application.Dtos.Room;

namespace SGRH.Application.Dtos.RoomCategory;

public record class RoomCategoryDto : BaseDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal NightlyRate { get; set; }
    public int MaxGuests { get; set; }
    public List<RoomDto>? Rooms { get; set; }
}
