namespace SGRH.Application.Dtos.RoomCategory;

public record class RemoveRoomCategoryDto : BaseDto
{
    public int Id { get; set; }
    public bool Removed { get; set; }
}
