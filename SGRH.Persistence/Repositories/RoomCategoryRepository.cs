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
    public RoomCategoryRepository(SGRHContext context, ILogger<RoomCategoryRepository> logger) : base(context)
    {
        _context = context;
        _logger = logger;
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

    public override Task<OperationResult> GetAllAsync()
    {
        ValidationRepository.ValidateContext(_context, _logger);
        ValidationRepository.LogInformation(_logger, "Getting all categories");

        var categories = base.GetAllAsync();
        ValidationRepository.ValidateEntity(categories.Result, _logger, "Cannot found a category");

        return categories;
    }

    public override Task<OperationResult> GetEntityByIdAsync(int id)
    {

        ValidationRepository.ValidateContext(_context, _logger);
        ValidationRepository.ValidateID(id, _logger);
        ValidationRepository.LogInformation(_logger, "Getting category...");

        var category = base.GetEntityByIdAsync(id);
        ValidationRepository.ValidateEntity(category.Result, _logger, "Cannot found a category");

        return category;
    }

    public override Task<OperationResult> SaveEntityAsync(RoomCategory entity)
    {
        ValidationRepository.ValidateContext(_context, _logger);
        ValidationRepository.ValidateEntity(entity, _logger, "Invalid category");

        ValidationRepository.LogInformation(_logger, "Saving category...");
        return base.SaveEntityAsync(entity);
    }

    public override Task<OperationResult> DeleteEntityAsync(RoomCategory entity)
    {
        ValidationRepository.ValidateContext(_context, _logger);
        ValidationRepository.ValidateEntity(entity, _logger, "Cannot delete a category");
        

        ValidationRepository.LogInformation(_logger, "Deleting category...");
        return base.DeleteEntityAsync(entity);
    }


    public override Task<OperationResult> ExistsAsync(Expression<Func<RoomCategory, bool>> filter)
    {
        ValidationRepository.ValidateContext(_context, _logger);
        ValidationRepository.ValidateFilter(filter, _logger);
        

        return base.ExistsAsync(filter);
    }

    public override Task<OperationResult> GetAllAsync(Expression<Func<RoomCategory, bool>> filter)
    {
        ValidationRepository.ValidateContext(_context, _logger);
        ValidationRepository.ValidateFilter(filter, _logger);

        var categories = base.GetAllAsync(filter);
        ValidationRepository.ValidateEntity(categories.Result, _logger, "Cannot found a category");

        return categories;
    }

    public override Task<OperationResult> UpdateEntityAsync(RoomCategory entity)
    {
        ValidationRepository.ValidateContext(_context, _logger);
        ValidationRepository.ValidateEntity(entity, _logger, "Cannot update a category");

        ValidationRepository.LogInformation(_logger, "Updating category...");
        return base.UpdateEntityAsync(entity);
    }
}
