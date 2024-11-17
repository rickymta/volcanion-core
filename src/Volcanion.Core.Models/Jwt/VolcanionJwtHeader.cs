namespace Volcanion.Core.Models.Jwt;

/// <summary>
/// JwtHeader
/// </summary>
public class VolcanionJwtHeader
{
    /// <summary>
    /// JWT type
    /// </summary>
    public string Type { get; set; } = "JWT";

    /// <summary>
    /// Encryption algorithm
    /// </summary>
    public string Algorithm { get; set; } = "RS512";
}
