using System.ComponentModel.DataAnnotations;

namespace SGRH.Application.Dtos.RoomCategory;

public record class UpdateRoomCategoryDto : RoomCategoryDto
{
    [Required(ErrorMessage = "Room category Id is required")]
    public int Id { get; set; }
}
