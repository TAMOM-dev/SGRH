using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGRH.Domain.Base
{
    public class OperationResult
    {
        
        public bool isSuccess { get; set; }
        public string? Message { get; set; }
        public dynamic? Data { get; set; }

        public OperationResult(bool iSuccess, string message, dynamic? data = null)
        {
            isSuccess = iSuccess;
            Message = message;
            Data = data;
        }

        public static OperationResult Success(string message, dynamic? data = null)
        {
            return new OperationResult(true, message, data);
        }

        public static OperationResult Failure(string message)
        {
            return new OperationResult(false, message);
        }
    }
}
