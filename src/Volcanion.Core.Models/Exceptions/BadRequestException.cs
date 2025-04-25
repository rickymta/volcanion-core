namespace Volcanion.Core.Models.Exceptions;

/// <summary>
/// BadRequestException
/// </summary>
/// <param name="message"></param>
public class BadRequestException(string message) : Exception(message)
{
}
