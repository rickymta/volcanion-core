namespace Volcanion.Core.Presentation.Middlewares.Exceptions;

/// <summary>
/// VolcanionBusinessException
/// </summary>
/// <param name="message"></param>
public class VolcanionBusinessException(string message) : Exception(message)
{
}
