using System;
using System.Collections.Generic;
using System.Text;

namespace Bach.DotNet.DRY.Model
{
    public class SystemOperationResult<T> : SystemOperationResult
    {
        private SystemOperationResult(bool isOk, T value = default(T), string message = null, Exception exception = null)
            : base(isOk, message, exception)
        {
            this.Value = value;
        }

        public T Value { get; private set; }

        public static SystemOperationResult<T> Ok(T value = default(T), string message = null)
        {
            return new SystemOperationResult<T>(true, value, message);
        }

        public static SystemOperationResult<T> Warning(T value = default(T), string message = null)
        {
            return new SystemOperationResult<T>(false, value, message);
        }

        public static SystemOperationResult<T> Error(Exception exception, T value = default(T), string message = null)
        {
            return new SystemOperationResult<T>(false, value, message, exception);
        }
        public static SystemOperationResult<T> Error(T value = default(T), string message = null)
        {
            return new SystemOperationResult<T>(false, value, message, null);
        }
    }
}
