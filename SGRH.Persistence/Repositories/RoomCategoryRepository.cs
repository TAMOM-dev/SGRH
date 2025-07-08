using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SGRH.Domain.Base;
using SGRH.Domain.Entities.Configuration;
using SGRH.Persistence.Base;
using SGRH.Persistence.Context;
using SGRH.Persistence.Interfaces;

namespace SGRH.Persistence.Repositories;

public class RoomCategoryRepository : BaseRepository<RoomCategory>, IRoomCategoryRepository
{
    private readonly SGRHContext _context;
    private readonly ILogger<RoomCategoryRepository> _logger;
    public RoomCategoryRepository(SGRHContext context) : base(context)
    {
        _context = context;
    }
    public async Task<IEnumerable<RoomCategory>> GetCategoriesWithRoomsAsync()
    {
        try
        {
            ValidationRepository.ValidateContext(_context, _logger);
            ValidationRepository.LogInformation(_logger, "Getting all categories with rooms");

            return await Entity
                .Include(c => c.Rooms)
                .ToListAsync();

        }
        catch (Exception e)
        {
            ValidationRepository.LogError(_logger, $"Error retrieving all categories with rooms: {e.Message}");
            return new List<RoomCategory>();
        }
    }

    public async Task<bool> HasRoomCategoryNameAsync(int categoryId)
    {
        try
        {
            ValidationRepository.ValidateContext(_context, _logger);
            ValidationRepository.ValidateID(categoryId, _logger);

            return await Entity
                .Where(c => c.Id == categoryId)
                .SelectMany(c => c.Rooms)
                .AnyAsync();
        }
        catch (Exception e)
        {
            ValidationRepository.LogError(_logger, $"Error checking existence: {e.Message}");
            return false;
        }
    }

    public override Task<List<RoomCategory>> GetAllAsync()
    {
        return base.GetAllAsync();
    }

    public override Task<RoomCategory> GetEntityByIdAsync(int id)
    {
        return base.GetEntityByIdAsync(id);
    }

    public override Task<OperationResult> SaveEntityAsync(RoomCategory entity)
    {
        return base.SaveEntityAsync(entity);
    }

    public override Task<OperationResult> DeleteEntityAsync(RoomCategory entity)
    {
        return base.DeleteEntityAsync(entity);
    }


    public override Task<bool> ExistsAsync(Expression<Func<RoomCategory, bool>> filter)
    {
        return base.ExistsAsync(filter);
    }

    public override Task<List<RoomCategory>> GetAllAsync(Expression<Func<RoomCategory, bool>> filter)
    {
        return base.GetAllAsync(filter);
    }

    public override Task<OperationResult> UpdateEntityAsync(RoomCategory entity)
    {
        return base.UpdateEntityAsync(entity);
    }
}
