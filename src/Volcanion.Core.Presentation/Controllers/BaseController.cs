using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Volcanion.Core.Models.Response;

namespace Volcanion.Core.Presentation.Controllers;

/// <summary>
/// BaseController
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    /// <summary>
    /// InternalServerError
    /// </summary>
    /// <param name="ex"></param>
    /// <returns></returns>
    protected IActionResult InternalServerError(Exception ex)
    {
        return StatusCode(StatusCodes.Status500InternalServerError, new ResponseResult
        {
            ErrorCode = -1,
            Message = ex.ToString(),
        });
    }

    /// <summary>
    /// ErrorMessage
    /// </summary>
    /// <param name="statusCode"></param>
    /// <param name="data"></param>
    /// <param name="message"></param>
    /// <param name="errorCode"></param>
    /// <returns></returns>
    protected ResponseResult ErrorMessage(HttpStatusCode statusCode, object? data, string message, int errorCode = -1)
    {
        return new ResponseResult { Message = message, ErrorCode = errorCode, Data = data, StatusCodes = statusCode };
    }

    /// <summary>
    /// ErrorMessage
    /// </summary>
    /// <param name="message"></param>
    /// <param name="errorCode"></param>
    /// <param name="statusCode"></param>
    /// <returns></returns>
    protected ResponseResult ErrorMessage(string message, int errorCode = -1, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    {
        return new ResponseResult { Message = message, ErrorCode = errorCode, StatusCodes = statusCode };
    }

    /// <summary>
    /// SuccessData
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    protected ResponseResult SuccessData(object? data)
    {
        return new ResponseResult { ErrorCode = 0, Data = data };
    }

    /// <summary>
    /// SuccessData
    /// </summary>
    /// <param name="data"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    protected ResponseResult SuccessData(object? data, string message)
    {
        return new ResponseResult { ErrorCode = 0, Data = data, Message = message };
    }

    /// <summary>
    /// SuccessData
    /// </summary>
    /// <returns></returns>
    protected ResponseResult SuccessData()
    {
        return new ResponseResult { ErrorCode = 0 };
    }

    /// <summary>
    /// SuccessMessage
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    protected ResponseResult SuccessMessage(string message)
    {
        return new ResponseResult { ErrorCode = 0, Message = message };
    }
}
