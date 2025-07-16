using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SGRH.Domain.Base;
using SGRH.Persistence.Repository;
using SGRH.Persistence.Context;
using System.Linq.Expressions;

namespace SGRH.Persistence.Base
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {  
        private readonly SGRHContext _context;
        private readonly ILogger _logger;

        protected DbSet<TEntity> Entity { get; private set; }

        protected BaseRepository(SGRHContext context)
        {
            _context = context;
            Entity = _context.Set<TEntity>();
        }

        public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter)
        {

            try
            {
                ValidationRepository.ValidateContext(_context, _logger);
                ValidationRepository.ValidateFilter(filter, _logger);

                return await Entity.AnyAsync(filter);
            }
            catch (Exception e)
            {
                ValidationRepository.LogError(_logger, $"Error checking existence: {e.Message}");
                return false;
            }
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            try
            {
                ValidationRepository.ValidateContext(_context, _logger);
                ValidationRepository.LogInformation(_logger, "Getting all entities");

                var data = await Entity.ToListAsync();
                ValidationRepository.ValidateQuery(data, _logger, "Cannot found any entities");

                return data;
            }
            catch (Exception e)
            {
                ValidationRepository.LogError(_logger, $"Error retrieving all entities: {e.Message}");
                return new List<TEntity>();
            }
        }

        public virtual async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                ValidationRepository.ValidateContext(_context, _logger);
                ValidationRepository.ValidateFilter(filter, _logger);

                return await Entity.Where(filter).ToListAsync();

            }
            catch (Exception e)
            {
                ValidationRepository.LogError(_logger, $"Error retrieving filtered entities: {e.Message}");
                return new List<TEntity>();
            }

        }

        public virtual async Task<TEntity?> GetEntityByIdAsync(int id)
        {
            try
            {
                ValidationRepository.ValidateID(id, _logger);
                ValidationRepository.ValidateContext(_context, _logger);

                return await Entity.FindAsync(id);
            }
            catch (Exception e)
            {
                ValidationRepository.LogError(_logger,$"Error retrieving entity {id}: {e.Message}");
                return null;
            }
        }
        public virtual async Task<OperationResult> SaveEntityAsync(TEntity entity)
        {
            try
            {
                ValidationRepository.ValidateEntity(entity, _logger, "The entity is actually Null");

                Entity.Add(entity);
                await _context.SaveChangesAsync();

                ValidationRepository.LogInformation(_logger, "Entity Saved.");
                return OperationResult.Success("Entity saved correctly.", entity);
            }
            catch (Exception e)
            {
                ValidationRepository.LogError(_logger, "Error saving entity: " + e.Message);
                return OperationResult.Failure("Error ocurred while saving the entity");
            }
        }
        public virtual async Task<OperationResult> UpdateEntityAsync(TEntity entity)
        {
            try
            {
                ValidationRepository.ValidateEntity(entity, _logger, "The entity is actually Null");

                Entity.Update(entity);
                await _context.SaveChangesAsync();

                ValidationRepository.LogInformation(_logger, "Updated Successfully");
                return OperationResult.Success("Entity updated correctly");
            }
            catch (Exception e)
            {
                ValidationRepository.LogError(_logger, "Error ocurred while updating the entity: " + e.Message);
                return OperationResult.Failure("Error ocurred while updating the entity: " + e.Message);
            }
        }

        public virtual async Task<OperationResult> DeleteEntityAsync(TEntity entity)
        {
            try
            {
                ValidationRepository.ValidateEntity(entity, _logger, "The entity is actually Null");

                Entity.Remove(entity);
                await _context.SaveChangesAsync();

                ValidationRepository.LogInformation(_logger, "Deleted Successfully");
                return OperationResult.Success("Entity deleted correctly");
            }
            catch (Exception e)
            {
                ValidationRepository.LogError(_logger, "Error deleting entity: " + e.Message);
                return OperationResult.Failure("Error ocurred while deleting the entity");
            }

        }

    }

    
}
