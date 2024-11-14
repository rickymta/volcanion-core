using System.Net;

namespace Volcanion.Core.Models.Response;

/// <summary>
/// ResponseResult
/// </summary>
public class ResponseResult
{
    /// <summary>
    /// Succeeded
    /// </summary>
    public bool Succeeded { get; set; } = true;

    /// <summary>
    /// StatusCodes
    /// </summary>
    public HttpStatusCode StatusCodes { get; set; } = HttpStatusCode.OK;

    /// <summary>
    /// ErrorCode
    /// </summary>
    public int ErrorCode { get; set; }

    /// <summary>
    /// Data
    /// </summary>
    public object? Data { get; set; }

    /// <summary>
    /// Message
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// Detail
    /// </summary>
    public string? Detail { get; set; }
}

/// <summary>
/// ResponseResult
/// </summary>
/// <typeparam name="T"></typeparam>
public class ResponseResult<T>
{
    /// <summary>
    /// Succeeded
    /// </summary>
    public bool Succeeded { get; set; } = true;

    /// <summary>
    /// StatusCodes
    /// </summary>
    public HttpStatusCode StatusCodes { get; set; } = HttpStatusCode.OK;

    /// <summary>
    /// ErrorCode
    /// </summary>
    public int ErrorCode { get; set; }

    /// <summary>
    /// T Data
    /// </summary>
    public T? Data { get; set; }

    /// <summary>
    /// Message
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// Detail
    /// </summary>
    public string? Detail { get; set; }
}
