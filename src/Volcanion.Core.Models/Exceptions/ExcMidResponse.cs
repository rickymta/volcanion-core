﻿namespace Volcanion.Core.Models.Exceptions
{
    /// <summary>
    /// ExcMidResponse
    /// </summary>
    /// <param name="ErrorCode"></param>
    /// <param name="ErrorStatus"></param>
    /// <param name="ErrorMessage"></param>
    /// <param name="StackTrace"></param>
    public record ExcMidResponse(string ErrorCode, string ErrorStatus, object ErrorMessage, string StackTrace = "");
}
