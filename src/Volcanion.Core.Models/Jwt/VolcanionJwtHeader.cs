using Newtonsoft.Json;

namespace Volcanion.Core.Models.Jwt;

/// <summary>
/// JwtHeader
/// </summary>
public class VolcanionJwtHeader
{
    /// <summary>
    /// JWT type
    /// </summary>
    [JsonProperty("typ")]
    public string Type { get; set; } = "JWT";

    /// <summary>
    /// Encryption algorithm
    /// </summary>
    [JsonProperty("alg")]
    public string Algorithm { get; set; } = "RS512";
}
