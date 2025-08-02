using Microsoft.EntityFrameworkCore;
using SGRH.Domain.Base;
using SGRH.Persistence.Repository;
using SGRH.Persistence.Context;
using System.Linq.Expressions;
using SGRH.Persistence.Base.Intefaces;

namespace SGRH.Persistence.Base
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {  
        private readonly SGRHContext _context;
        protected DbSet<TEntity> Entity { get; private set; }

        protected BaseRepository(SGRHContext context)
        {
            _context = context;
            Entity = _context.Set<TEntity>();
        }

        public virtual async Task<OperationResult> ExistsAsync(Expression<Func<TEntity, bool>> filter)
        {

            
            try
            {
                
                var data = await Entity.AnyAsync(filter);
                return OperationResult.Success("Entity exists", data);
            }
            catch (Exception e)
            {
                return OperationResult.Failure("Error ocurred while checking if the entity exists: " + e.Message);
            }
        }

        public virtual async Task<OperationResult> GetAllAsync()
        {
            try
            {
                var data = await Entity.ToListAsync();
                return OperationResult.Success("All entities found", data);
            }
            catch (Exception e)
            {
                return  OperationResult.Failure("Error ocurred while retrieving all entities: " + e.Message);
            }
        }

        public virtual async Task<OperationResult> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                var data = await Entity.Where(filter).ToListAsync();
                return OperationResult.Success("All entities found", data);
            }
            catch (Exception e)
            {
                return  OperationResult.Failure("Error ocurred while retrieving all entities: " + e.Message);    
            }

        }

        public virtual async Task<OperationResult> GetEntityByIdAsync(int id)
        {
                try
                {
                    var data = await Entity.FindAsync(id);
                    return OperationResult.Success("Entity found", data);
                }
                catch (Exception e)
                {
                    return  OperationResult.Failure("Error ocurred while retrieving the entity: " + e.Message);
                }

        }
        public virtual async Task<OperationResult> SaveEntityAsync(TEntity entity)
        {
            try
            {
                Entity.Add(entity);
                var data =await _context.SaveChangesAsync();

                return OperationResult.Success("Entity saved correctly.", entity);
            }
            catch (Exception e)
            {
                return OperationResult.Failure("Error ocurred while saving the entity" + e.Message);
            }
        }
        public virtual async Task<OperationResult> UpdateEntityAsync(TEntity entity)
        {
            try
            {
                Entity.Update(entity);
                var data =await _context.SaveChangesAsync();

                return OperationResult.Success("Entity updated correctly", data);
            }
            catch (Exception e)
            {
                return OperationResult.Failure("Error ocurred while updating the entity: " + e.Message);
            }
        }

        public virtual async Task<OperationResult> DeleteEntityAsync(TEntity entity)

        {
            try
            {
                Entity.Remove(entity);
                await _context.SaveChangesAsync();

                return OperationResult.Success("Entity deleted correctly");
            }
            catch (Exception e)
            {
                return OperationResult.Failure("Error ocurred while deleting the entity" + e.Message);
            }

        }
        
    }
}
