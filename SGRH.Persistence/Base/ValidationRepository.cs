

using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using SGRH.Domain.Base;
using SGRH.Persistence.Context;

namespace SGRH.Persistence.Base
{
    public static class ValidationRepository
    {
        
        public static void ValidateContext(SGRHContext context, ILogger logger)
        {

            if (context == null)
            {
                logger.LogCritical("DB Context is null");
                throw new ArgumentNullException(nameof(context), "Database context not available");
            }
        }

        public static OperationResult ValidateID(int entityId, ILogger logger)
        {
            if (entityId <= 0)
            {
                LogError(logger, "Invalid ID");
                return OperationResult.Failure("This id is not valid");
            }

            LogInformation(logger, "Valid ID");
            return OperationResult.Success("Id is valid to use");
        }

        public static OperationResult ValidateQuery<T>(List<T> query, ILogger logger, string failedMsg)
        {
            if (query == null || !query.Any())
            {
                LogError(logger, "Query Null or Empty");
                return OperationResult.Failure(failedMsg);
            }

            LogInformation(logger, "Data found");
            return OperationResult.Success("Data found", query);
        }

        public static OperationResult ValidateEntity<T>(T entity, ILogger logger, string failedMsg)
        {
            if (entity == null)
            {
                LogError(logger, "Null Entity");
                return OperationResult.Failure(failedMsg);
            }

            LogInformation(logger, "Entity not NUll");
            return OperationResult.Success("Entity found", entity);
        }

        public static void ValidateFilter<TEntity>(Expression<Func<TEntity, bool>> filter, ILogger logger)
        {
            if (filter == null)
            {
                LogError(logger, "Filter is actually Null");
                throw new ArgumentNullException(nameof(filter));
            }

        }

        public static OperationResult ValidateStringEmpty(string value, string fieldName, ILogger logger)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                LogError(logger, $"{fieldName} is empty");
                return OperationResult.Failure($"Field {fieldName} cannot be empty");
            }

            LogInformation(logger, $"Field {fieldName} is valid");
            return OperationResult.Success("Valid field", value);
        }

        public static OperationResult ValidatePositiveNumber(int value, string fieldName, ILogger logger)
        {
            if (value <= 0)
            {
                LogError(logger, $"Field {fieldName} must be a positive number");
                return OperationResult.Failure("Invalid amount");
            }

            LogInformation(logger, $"{fieldName} is valid");
            return OperationResult.Success("Valid field");
        }

        // Looger
        public static void LogInformation(ILogger logger, string message)
        {
            logger.LogInformation(message);
        }

        public static void LogError(ILogger logger, string message)
        {
            logger.LogError(message);
        }

        
    }
}
