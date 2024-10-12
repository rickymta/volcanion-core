using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Volcanion.Core.Models.Response;

namespace Volcanion.Core.Presentation.Controllers;


[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    protected IActionResult InternalServerError(Exception ex)
    {
        return StatusCode(StatusCodes.Status500InternalServerError, new ResponseResult
        {
            ErrorCode = -1,
            Message = ex.ToString(),
        });
    }

    protected ResponseResult ErrorMessage(HttpStatusCode statusCode, object? data, string message, int errorCode = -1)
    {
        return new ResponseResult { Message = message, ErrorCode = errorCode, Data = data, StatusCodes = statusCode };
    }

    protected ResponseResult ErrorMessage(string message, int errorCode = -1, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    {
        return new ResponseResult { Message = message, ErrorCode = errorCode, StatusCodes = statusCode };
    }

    protected ResponseResult SuccessData(object? data)
    {
        return new ResponseResult { ErrorCode = 0, Data = data };
    }

    protected ResponseResult SuccessData(object? data, string message)
    {
        return new ResponseResult { ErrorCode = 0, Data = data, Message = message };
    }

    protected ResponseResult SuccessData()
    {
        return new ResponseResult { ErrorCode = 0 };
    }

    protected ResponseResult SuccessMessage(string message)
    {
        return new ResponseResult { ErrorCode = 0, Message = message };
    }
}
