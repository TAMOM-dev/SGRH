
using SGRH.Domain.Entities.Configuration;
using SGRH.Persistence.Repository;

namespace SGRH.Persistence.Interfaces;

public interface IRoomCategoryRepository : IBaseRepository<RoomCategory>
{
    Task<bool> HasRoomCategoryNameAsync(int categoryId);
    Task<IEnumerable<RoomCategory>> GetCategoriesWithRoomsAsync();
}
