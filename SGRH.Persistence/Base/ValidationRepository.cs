

using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using SGRH.Domain.Base;
using SGRH.Persistence.Base.Intefaces;
using SGRH.Persistence.Context;

namespace SGRH.Persistence.Base
{
    public class ValidationRepository : IValidationRepository
    {
        private readonly ILogger<ValidationRepository> _logger;

        public ValidationRepository(ILogger<ValidationRepository> logger)
        {
            _logger = logger;
        }
        
        public void ValidateContext(SGRHContext context)
        {

            if (context == null)
            {
                _logger.LogCritical("DB Context is null");
                throw new ArgumentNullException(nameof(context), "Database context not available");
            }
        }

        public  OperationResult ValidateID(int entityId)
        {
            if (entityId <= 0)
            {
                _logger.LogError("Invalid ID");
                return OperationResult.Failure("This id is not valid");
            }

            LogInformation("Valid ID");
            return OperationResult.Success("Id is valid to use");
        }

        public OperationResult ValidateQuery<T>(List<T> query, string failedMsg)
        {
            if (query == null || !query.Any())
            {
               _logger.LogError("Query Null or Empty");
                return OperationResult.Failure(failedMsg);
            }

            LogInformation("Data found");
            return OperationResult.Success("Data found", query);
        }

        public OperationResult ValidateEntity<T>(T entity, string failedMsg)
        {
            if (entity == null)
            {
                LogError(_logger, "Null Entity");
                return OperationResult.Failure(failedMsg);
            }

            LogInformation("Entity not NUll");
            return OperationResult.Success("Entity found", entity);
        }

        public  void ValidateFilter<TEntity>(Expression<Func<TEntity, bool>> filter)
        {
            if (filter == null)
            {
                _logger.LogError("Filter is actually Null");
                throw new ArgumentNullException(nameof(filter));
            }

        }

        // Looger
        public void LogInformation(string message)
        {
            _logger.LogInformation(message);
        }

        public void LogError(ILogger logger, string message)
        {
            _logger.LogError(message);
        }

        
    }
}
