using Exchange.Api.Models;
using Exchange.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exchange.Api.Controllers
{
    public class ExchangeController : ControllerBase
    {
        protected IActionResult Respond(Result result)
        {
            return StatusCode((int)result.HttpStatus, new ApiResponse() { 
                Success = result.IsSuccess,
                ErrorMessage = result.Message,
                Code = (int)result.HttpStatus
            });
        }

        protected IActionResult Respond<T>(Result<T> result)
        {
            return StatusCode((int)result.HttpStatus, new ApiResponse<T>() {
                Success = result.IsSuccess,
                ErrorMessage = result.Message,
                Code = (int)result.HttpStatus,
                Data = result.Value
            });
        }
    }
}
