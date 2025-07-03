

using Microsoft.Extensions.Logging;
using SGRH.Domain.Base;
using SGRH.Persistence.Context;

namespace SGRH.Persistence.Base
{
    public static class ValidationRepository
    {
        public static OperationResult ValidateContext(SGRHContext context, ILogger logger)
        {

            if (context == null)
            {
                logger.LogCritical("DB Context is null");
                return OperationResult.Failure("Database not connected");
            }

            return null;
        }

        public static OperationResult ValidateID(int entityId, ILogger logger)
        {
            if(entityId <= 0 )
            {
                logger.LogError("Invalid ID");
                return OperationResult.Failure("This id is not valid");
            }

            return null;
        }

        public static OperationResult ValidateQuery<T>(List<T> query, ILogger logger,string failedMsg)
        {
            if(query == null || !query.Any())
            {
                logger.LogError("Query Null or Empty");
                return OperationResult.Failure(failedMsg);
            }

            logger.LogInformation("Data found");
            return null;
        }

        public static OperationResult ValidateEntity<T>(T entity, ILogger logger, string failedMsg)
        {
            if(entity == null)
            {
                logger.LogError("Null Entity");
                return OperationResult.Failure(failedMsg);
            }

            logger.LogInformation("Entity not Null");
            return null;
        }
    }
}
