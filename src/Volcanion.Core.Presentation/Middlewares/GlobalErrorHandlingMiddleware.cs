using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;
using Volcanion.Core.Presentation.Middlewares.Exceptions;

namespace Volcanion.Core.Presentation.Middlewares;

/// <summary>
/// GlobalErrorHandlingMiddleware
/// </summary>
public class GlobalErrorHandlingMiddleware
{
    /// <summary>
    /// RequestDelegate
    /// </summary>
    private readonly RequestDelegate next;

    /// <summary>
    /// ILogger instance
    /// </summary>
    private readonly ILogger<GlobalErrorHandlingMiddleware> _logger;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="next"></param>
    public GlobalErrorHandlingMiddleware(RequestDelegate next, ILogger<GlobalErrorHandlingMiddleware> logger)
    {
        this.next = next;
        _logger = logger;
    }

    /// <summary>
    /// InvokeAsync method to handle exceptions
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // Call the next middleware
            await next(context);
        }
        catch (Exception ex)
        {
            // Handle exception
            await HandleExceptionAsync(context, ex);
        }
    }

    /// <summary>
    /// HandleExceptionAsync method to handle exceptions
    /// </summary>
    /// <param name="context"></param>
    /// <param name="exception"></param>
    /// <returns></returns>
    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        // Get exception type
        var exceptionType = exception.GetType();

        // Set status code, error code, error status, error details, error message and stack trace
        HttpStatusCode status;
        HttpStatusCode errorCode;

        string errorStatus;
        string errorDetails;
        string errorMessage;

        // Check exception type
        if (exceptionType == typeof(BadRequestException))
        {
            // Set status code, error code, error status, error details, error message and stack trace
            // Default status code is BadRequest
            status = HttpStatusCode.BadRequest;
            // Default error code is BadRequest
            errorCode = status;
            // Default error details is https://httpstatuses.io/400
            errorDetails = $"https://httpstatuses.io/{(int)status}";
            // Default error status is BadRequest
            errorStatus = "BadRequest";
            // Default error message is exception message
            errorMessage = exception.Message;
        }
        else if (exceptionType == typeof(NotFoundException))
        {
            // Set status code, error code, error status, error details, error message and stack trace
            // Default status code is NotFound
            status = HttpStatusCode.NotFound;
            // Default error code is NotFound
            errorCode = status;
            // Default error details is https://httpstatuses.io/404
            errorDetails = $"https://httpstatuses.io/{(int)status}";
            // Default error status is NotFound
            errorStatus = "NotFound";
            // Default error message is exception message
            errorMessage = exception.Message;
        }
        else if (exceptionType == typeof(FormatException))
        {
            // Set status code, error code, error status, error details, error message and stack trace
            // Default status code is FormatException
            status = HttpStatusCode.BadRequest;
            // Default error code is FormatException
            errorCode = status;
            // Default error details is https://httpstatuses.io/400
            errorDetails = $"https://httpstatuses.io/{(int)status}";
            // Default error status is FormatException
            errorStatus = "Format exception";
            // Default error message is exception message
            errorMessage = exception.Message;
        }
        else if (exceptionType == typeof(VolcanionBusinessException))
        {
            // Set status code, error code, error status, error details, error message and stack trace
            // Default status code is FormatException
            status = HttpStatusCode.BadRequest;
            // Default error code is FormatException
            errorCode = status;
            // Default error details is https://httpstatuses.io/400
            errorDetails = $"https://httpstatuses.io/{(int)status}";
            // Default error status is FormatException
            errorStatus = "Volcanion busniess exception";
            // Default error message is exception message
            errorMessage = exception.Message;
        }
        else
        {
            // Set status code, error code, error status, error details, error message and stack trace
            // Default status code is InternalServerError
            status = HttpStatusCode.InternalServerError;
            // Default error code is InternalServerError
            errorCode = status;
            // Default error details is https://httpstatuses.io/500
            errorDetails = $"https://httpstatuses.io/{(int)status}";
            // Default error status is InternalServerError
            errorStatus = "InternalServerError";
            // Default error message is exception message
            errorMessage = exception.Message;
        }

        // Serialize exception result
        var exceptionResult = JsonSerializer.Serialize(new ExcMidResult()
        {
            ErrorStatus = errorStatus,
            ErrorCode = errorCode,
            ErrorDetails = errorDetails,
            ErrorMessage = errorMessage,
        });

        // Log error message and stack trace
        _logger.LogError(errorMessage);
        _logger.LogError(exception.StackTrace);

        // Set response content type, status code and write exception result
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)status;
        // Write exception result
        return context.Response.WriteAsync(exceptionResult);
    }
}

/// <summary>
/// GlobalErrorHandlingMiddlewareExtension
/// </summary>
public static class GlobalErrorHandlingMiddlewareExtension
{
    /// <summary>
    /// UseGlobalErrorHandlingMiddleware
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseGlobalErrorHandlingMiddleware(this IApplicationBuilder builder)
    {
        // Use GlobalErrorHandlingMiddleware
        return builder.UseMiddleware<GlobalErrorHandlingMiddleware>();
    }
}
