using SGRH.Domain.Base;
using System.Linq.Expressions;


namespace SGRH.Persistence.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class //OJO
    {
        Task<OperationResult> GetEntityByIdAsync(int id);
        Task<OperationResult> UpdateEntityAsync(TEntity entity);
        Task<OperationResult> SaveEntityAsync(TEntity entity);
        Task<OperationResult> GetAllAsync();
        Task<OperationResult> GetAllAsync(Expression<Func<TEntity, bool>> filter);
        Task<OperationResult> ExistsAsync(Expression<Func<TEntity, bool>> filter);
        Task<OperationResult> DeleteEntityAsync(TEntity entity);
    }
}

