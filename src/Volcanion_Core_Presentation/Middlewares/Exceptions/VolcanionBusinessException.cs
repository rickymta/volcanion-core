namespace Volcanion_Core_Presentation.Middlewares.Exceptions;

/// <summary>
/// VolcanionBusinessException
/// </summary>
/// <param name="message"></param>
public class VolcanionBusinessException(string message) : Exception(message)
{
}
