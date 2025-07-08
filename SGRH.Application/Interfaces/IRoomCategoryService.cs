using SGRH.Application.Base;
using SGRH.Application.Dtos.RoomCategory;

namespace SGRH.Application.Interfaces;

public interface IRoomCategoryService : IBaseService<SaveRoomCategoryDto, UpdateRoomCategoryDto, RemoveRoomCategoryDto>
{

}
