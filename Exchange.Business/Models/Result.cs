using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Exchange.Business.Models
{

    public class Result<T> : Result
    {
        public T Value { get; }
        private Result(bool isSuccess, HttpStatusCode httpStatus, T value = default(T), string message = null) : base(isSuccess: isSuccess, httpStatus: httpStatus, message: message)
        {
            Value = value;
        }
        public static Result<T> Ok(T value) => new Result<T>(isSuccess: true, httpStatus: HttpStatusCode.OK, value: value);
        public static new Result<T> Fail(HttpStatusCode httpStatus, string message) => new Result<T>(isSuccess: false, httpStatus: httpStatus, message: message);

    }

    public class Result
    {
        public bool IsSuccess { get; }
        public bool IsFailure
        {
            get { return !IsSuccess; }
        }
        public HttpStatusCode HttpStatus { get; }

        public string Message { get; }

        protected Result(bool isSuccess, HttpStatusCode httpStatus, string message = null)
        {
            IsSuccess = isSuccess;
            Message = message;
            HttpStatus = httpStatus;
        }

        public static Result Ok() => new Result(isSuccess: true, httpStatus: HttpStatusCode.NoContent);
        public static Result Fail(HttpStatusCode httpStatus, string message) => new Result(isSuccess: false, httpStatus: httpStatus, message: message);
    }
}

