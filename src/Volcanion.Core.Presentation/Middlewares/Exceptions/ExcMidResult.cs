using System.Net;

namespace Volcanion.Core.Presentation.Middlewares.Exceptions;

/// <summary>
/// ExcMidResult
/// </summary>
public class ExcMidResult
{
    /// <summary>
    /// ErrorCode
    /// </summary>
    public HttpStatusCode ErrorCode { get; set; }

    /// <summary>
    /// ErrorStatus
    /// </summary>
    public string ErrorStatus { get; set; }

    /// <summary>
    /// ErrorMessage
    /// </summary>
    public string ErrorMessage { get; set; }

    /// <summary>
    /// ErrorDetails
    /// </summary>
    public string ErrorDetails { get; set; }

    /// <summary>
    /// StackTrace
    /// </summary>
    public string? StackTrace { get; set; }
}
