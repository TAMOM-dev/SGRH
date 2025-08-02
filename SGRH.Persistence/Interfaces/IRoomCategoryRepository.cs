
using SGRH.Domain.Entities.Configuration;
using SGRH.Persistence.Repository;

namespace SGRH.Persistence.Interfaces;

public interface IRoomCategoryRepository : IBaseRepository<RoomCategory>
{
    public Task<bool> CategoryNameExistsAsync(string name);
}
