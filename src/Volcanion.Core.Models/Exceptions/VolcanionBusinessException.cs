namespace Volcanion.Core.Models.Exceptions;

/// <summary>
/// VolcanionBusinessException
/// </summary>
/// <param name="message"></param>
public class VolcanionBusinessException(string message) : Exception(message)
{
}
