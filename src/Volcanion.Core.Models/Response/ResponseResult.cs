using System.Net;

namespace Volcanion.Core.Models.Response;

public class ResponseResult
{
    public bool Succeeded { get; set; } = true;

    public HttpStatusCode StatusCodes { get; set; } = HttpStatusCode.OK;

    public int ErrorCode { get; set; }

    public object? Data { get; set; }

    public string? Message { get; set; }

    public string? Detail { get; set; }
}

public class ResponseResult<T>
{
    public bool Succeeded { get; set; } = true;

    public HttpStatusCode StatusCodes { get; set; } = HttpStatusCode.OK;

    public int ErrorCode { get; set; }

    public T? Data { get; set; }

    public string? Message { get; set; }

    public string? Detail { get; set; }
}
