using System.Text.Json.Serialization;

namespace Volcanion.Core.Models.Jwt;

/// <summary>
/// JwtHeader
/// </summary>
public class JwtHeader
{
    /// <summary>
    /// JWT type
    /// </summary>
    [JsonPropertyName("typ")]
    public string Type { get; set; } = "JWT";

    /// <summary>
    /// Encryption algorithm
    /// </summary>
    [JsonPropertyName("alg")]
    public string Algorithm { get; set; } = "HS512";
}
