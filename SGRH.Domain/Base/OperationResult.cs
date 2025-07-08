namespace SGRH.Domain.Base
{
    public class OperationResult
    {

        public bool isSuccess { get; }
        public string? Message { get; }
        public dynamic? Data { get; }

        private OperationResult(bool iSuccess, string message, dynamic? data = null)
        {
            isSuccess = iSuccess;
            Message = message;
            Data = data;
        }

        public static OperationResult Success(string message, dynamic? data = null)
        => new OperationResult(true, message, data);

        public static OperationResult Failure(string message)
        => new OperationResult(false, message);
    }
}
