using System.Net;

namespace Volcanion.Core.Presentation.Middlewares.Exceptions
{
    public class ExcMidResult
    {
        public HttpStatusCode ErrorCode { get; set; }

        public string ErrorStatus { get; set; }

        public string ErrorMessage { get; set; }

        public string ErrorDetails { get; set; }

        public string? StackTrace { get; set; }
    }
}
