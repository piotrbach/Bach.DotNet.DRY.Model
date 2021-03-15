using System;
using System.Collections.Generic;
using System.Text;

namespace Bach.DotNet.DRY.Model
{
    public class SystemOperationResult
    {
        protected SystemOperationResult(bool isOk, string message = "", Exception exception = null)
        {
            this.IsOk = isOk;
            this.Message = message;
            this.Exception = exception;
        }

        public bool IsOk { get; private set; }

        public string Message { get; private set; }

        public Exception Exception { get; private set; }

        public static SystemOperationResult Ok(string message = "")
        {
            return new SystemOperationResult(true, message);
        }

        public static SystemOperationResult Warning(string message = "")
        {
            return new SystemOperationResult(false, message);
        }

        public static SystemOperationResult Error(string message = "")
        {
            return new SystemOperationResult(false, message);
        }

        public static SystemOperationResult Error(Exception exception, string message = "")
        {
            return new SystemOperationResult(false, message, exception);
        }

        public static implicit operator bool(SystemOperationResult value)
        {
            return value.IsOk;
        }

        public bool HasException => this.Exception != null;
    }
}
