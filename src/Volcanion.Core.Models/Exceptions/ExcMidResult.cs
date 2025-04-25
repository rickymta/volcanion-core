using System.Net;

namespace Volcanion.Core.Models.Exceptions;

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
    public string ErrorStatus { get; set; } = null!;

    /// <summary>
    /// ErrorMessage
    /// </summary>
    public string ErrorMessage { get; set; } = null!;

    /// <summary>
    /// ErrorDetails
    /// </summary>
    public string ErrorDetails { get; set; } = null!;

    /// <summary>
    /// StackTrace
    /// </summary>
    public string? StackTrace { get; set; }
}
