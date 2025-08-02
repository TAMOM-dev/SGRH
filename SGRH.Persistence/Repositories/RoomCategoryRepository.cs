using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SGRH.Domain.Base;
using SGRH.Domain.Entities.Configuration;
using SGRH.Persistence.Base;
using SGRH.Persistence.Base.Intefaces;
using SGRH.Persistence.Context;
using SGRH.Persistence.Interfaces;

namespace SGRH.Persistence.Repositories;

public class RoomCategoryRepository : BaseRepository<RoomCategory>, IRoomCategoryRepository
{
    private readonly SGRHContext _context;
    protected readonly IValidationRepository _validator;
    public RoomCategoryRepository(SGRHContext context, IValidationRepository validator) : base(context)
    {
        _context = context;
        _validator = validator;
    }

    public override async Task<OperationResult> GetAllAsync()
    {
        _validator.ValidateContext(_context);

        var result = await base.GetAllAsync();
        if(!result.isSuccess)
            return OperationResult.Failure("Failed to retrieve categories.");

        return OperationResult.Success("Categories retrieved successfully", result.Data);
    }

    public override async Task<OperationResult> GetEntityByIdAsync(int id)
    {
        _validator.ValidateContext(_context);
        _validator.ValidateID(id);

        var result = await base.GetEntityByIdAsync(id);
        if(!result.isSuccess || result.Data == null)
            return OperationResult.Failure("Category not found.");

        return OperationResult.Success("Category retrieved successfully", result.Data);
    }

    public override async Task<OperationResult> SaveEntityAsync(RoomCategory entity)
    {   
        _validator.ValidateContext(_context);
        _validator.ValidateEntity(entity, "The category cannot be null.");

        await base.SaveEntityAsync(entity);
        return OperationResult.Success("Category saved successfully.");
    }

    public override async Task<OperationResult> DeleteEntityAsync(RoomCategory entity)
    {
        _validator.ValidateContext(_context);
        _validator.ValidateEntity(entity, "The category cannot be null.");
        
        await base.DeleteEntityAsync(entity);
        return OperationResult.Success("Category deleted successfully.");
    }


    public override async Task<OperationResult> ExistsAsync(Expression<Func<RoomCategory, bool>> filter)
    {
        _validator.ValidateContext(_context);
        _validator.ValidateFilter(filter);

        var exists = await base.ExistsAsync(filter);
        return OperationResult.Success("Existence check completed.", exists);
    }

    public override async Task<OperationResult> GetAllAsync(Expression<Func<RoomCategory, bool>> filter)
    {
        _validator.ValidateContext(_context);
        _validator.ValidateFilter(filter);

        var categories = await base.GetAllAsync(filter);
        return OperationResult.Success("All categories retrieved successfully.", categories);
    }

    public override async Task<OperationResult> UpdateEntityAsync(RoomCategory entity)
    {
        _validator.ValidateContext(_context);
        _validator.ValidateEntity(entity, "The category cannot be null.");

        await base.UpdateEntityAsync(entity);
        return OperationResult.Success("Category updated successsfully");
    }

    public async Task<bool> CategoryNameExistsAsync(string name)
    {
        return await Entity.AnyAsync(c => c.Name.ToLower() == name.ToLower());
    }
}
