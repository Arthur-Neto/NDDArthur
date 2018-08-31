﻿using Arthur.MF7.Domain.Exceptions;
using Newtonsoft.Json;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Arthur.MF7.WebAPI.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class ExceptionPayload
    {
        [JsonIgnore]
        public Exception Exception { get; set; }

        public int ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        public static ExceptionPayload New<T>(T exception) where T : Exception
        {
            int errorCode;
            if (exception is BusinessException)
                errorCode = (exception as BusinessException).ErrorCode.GetHashCode();
            else
                errorCode = ErrorCodes.Unhandled.GetHashCode();
            return new ExceptionPayload
            {
                ErrorCode = errorCode,
                ErrorMessage = exception.Message,
                Exception = exception
            };
        }
    }
}