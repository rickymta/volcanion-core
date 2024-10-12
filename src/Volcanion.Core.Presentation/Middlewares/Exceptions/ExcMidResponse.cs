namespace Volcanion.Core.Presentation.Middlewares.Exceptions
{
    public record ExcMidResponse(string ErrorCode, string ErrorStatus, object ErrorMessage, string StackTrace = null);
}
