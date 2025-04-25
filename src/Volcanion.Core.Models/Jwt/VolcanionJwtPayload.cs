using Newtonsoft.Json;

namespace Volcanion.Core.Models.Jwt;

/// <summary>
/// JwtPayload
/// </summary>
public class VolcanionJwtPayload
{
    /// <summary>
    /// Expiration
    /// Token expiration time (timestamp).
    /// </summary>
    [JsonProperty("exp")]
    public long Expiration { get; set; }

    /// <summary>
    /// IssuedAt
    /// Token creation time.
    /// </summary>
    [JsonProperty("iat")]
    public long IssuedAt { get; set; } = DateTimeOffset.Now.ToUnixTimeSeconds();

    /// <summary>
    /// TokenId
    /// The ID of the token, to distinguish between tokens.
    /// </summary>
    [JsonProperty("token_id")]
    public string TokenId { get; set; } = Guid.NewGuid().ToString();

    /// <summary>
    /// Issuer
    /// Token issuer, here is the URL of the Identity server.
    /// </summary>
    [JsonProperty("iss")]
    public string Issuer { get; set; } = "";

    /// <summary>
    /// Audience
    /// </summary>
    [JsonProperty("aud")]
    public string Audience { get; set; } = "";

    /// <summary>
    /// SessionId
    /// </summary>
    [JsonProperty("session_id")]
    public string SessionId { get; set; } = Guid.NewGuid().ToString();

    /// <summary>
    /// AllowedOrigins
    /// </summary>
    [JsonProperty("allowed_origins")]
    public List<string> AllowedOrigins { get; set; } = [];

    /// <summary>
    /// ResourceAccess
    /// </summary>
    [JsonProperty("resource_access")]
    public ResourceAccess ResourceAccess { get; set; } = null!;

    /// <summary>
    /// Data
    /// </summary>
    [JsonProperty("data")]
    public object? Data { get; set; }
}

/// <summary>
/// ResourceAccess
/// </summary>
public class ResourceAccess
{
    /// <summary>
    /// RoleAccess
    /// </summary>
    [JsonProperty("role_access")]
    public RoleAccess RoleAccess { get; set; } = null!;
}

/// <summary>
/// RoleAccess
/// </summary>
public class RoleAccess
{
    /// <summary>
    /// Roles
    /// </summary>
    [JsonProperty("roles")]
    public List<string> Roles { get; set; } = [];
}
