using System;
using System.Linq.Expressions;
using SGRH.Domain.Base;
using SGRH.Persistence.Context;

namespace SGRH.Persistence.Base.Intefaces;

public interface IValidationRepository
{
    void ValidateContext(SGRHContext context);
    OperationResult ValidateID(int entityId);
    OperationResult ValidateQuery<T>(List<T> query, string failedMsg);
    OperationResult ValidateEntity<T>(T entity, string failedMsg);
    void ValidateFilter<TEntity>(Expression<Func<TEntity, bool>> filter);
}
