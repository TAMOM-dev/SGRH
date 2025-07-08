
using SGRH.Domain.Base;
using SGRH.Domain.Entities.Configuration;
using SGRH.Persistence.Repository;

namespace SGRH.Persistence.Interfaces;

public interface IRoomCategoryRepository : IBaseRepository<RoomCategory>
{
    Task<List<OperationResult>> GetAvailableRoomCategoriesAsync();
    Task<OperationResult> GetByNameAsync(string name);
}
