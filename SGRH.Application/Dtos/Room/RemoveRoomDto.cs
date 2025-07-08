namespace SGRH.Application.Dtos.Room;

public record class RemoveRoomDto : BaseDto
{
    public int Id { get; set; }
    public bool Removed { get; set; }
}
