﻿namespace Volcanion.Core.Models.Exceptions;

/// <summary>
/// VolcanionAuthException
/// </summary>
/// <param name="message"></param>
public class VolcanionAuthException(string message) : Exception(message)
{
}
