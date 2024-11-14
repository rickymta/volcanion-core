namespace Volcanion.Core.Presentation.Middlewares.Exceptions;

/// <summary>
/// NotFoundException
/// </summary>
/// <param name="message"></param>
public class NotFoundException(string message) : Exception(message)
{
}
