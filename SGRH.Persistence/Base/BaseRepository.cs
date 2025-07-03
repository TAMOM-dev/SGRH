using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SGRH.Domain.Base;
using SGRH.Domain.Repository;
using SGRH.Persistence.Context;
using System.Linq.Expressions;

namespace SGRH.Persistence.Base
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly SGRHContext _context;
        private readonly ILogger _logger;

        private DbSet<TEntity> Entity { get; set; }

        protected BaseRepository(SGRHContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            Entity = _context.Set<TEntity>();
        }

        public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await Entity.AnyAsync(filter);
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await Entity.ToListAsync();
        }

        public virtual async Task<OperationResult> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            OperationResult result;

            try
            {
                
                var data = await Entity.Where(filter).ToListAsync();

                result = OperationResult.Success("Entity found succesfully", data);

            } catch (Exception e)
            {
                result = OperationResult.Failure("Error finding Entity. :" + e.Message);
            }

            return result;
        }

        public virtual async Task<TEntity> GetEntityByIdAsync(int id)
        {
            ValidationRepository.ValidateID(id, _logger);
            return await Entity.FindAsync(id); //OJO
        }

        public virtual async Task<OperationResult> SaveEntityAsync(TEntity entity)
        {
            OperationResult result;

            try
            {
                ValidationRepository.ValidateEntity(entity,_logger, "The entity is actually Null");

                Entity.Add(entity);
                await _context.SaveChangesAsync();

                result = OperationResult.Success("Entity saved correctly.", entity);
            }
            catch (Exception e)
            {
                result = OperationResult.Failure("Error ocurred while saving the entity: " + e.Message);
            }

            return result;
        }

        public virtual async Task<OperationResult> UpdateEntityAsync(TEntity entity)
        {
            OperationResult result; 

            try
            {

                Entity.Update(entity);
                await _context.SaveChangesAsync();
                result = OperationResult.Success("Entity updated correctly");
            }
            catch (Exception e)
            {
                result = OperationResult.Failure("Error ocurred while updating the entity: " + e.Message);
            }

            return result;
        }
    }


}
