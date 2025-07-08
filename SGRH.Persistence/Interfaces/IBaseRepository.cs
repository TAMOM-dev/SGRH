using SGRH.Domain.Base;
using System.Linq.Expressions;


namespace SGRH.Persistence.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class //OJO
    {
        Task<TEntity?> GetEntityByIdAsync(int id);
        Task<OperationResult> UpdateEntityAsync(TEntity entity);
        Task<OperationResult> SaveEntityAsync(TEntity entity);
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter);
        Task<OperationResult> DeleteEntityAsync(TEntity entity);
    }
}

