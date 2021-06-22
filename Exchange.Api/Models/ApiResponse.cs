using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exchange.Api.Models
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public int Code { get; set; }

        public ApiResponse()
        { 
        }
    }

    public class ApiResponse<T> : ApiResponse
    {
        public T Data { get; set; }
        public ApiResponse() : base()
        { 
        }
    }
}
