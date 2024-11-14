using System.Text.Json.Serialization;

namespace Volcanion.Core.Models.Jwt;

/// <summary>
/// JwtPayload
/// </summary>
public class JwtPayload
{
    /// <summary>
    /// Expiration
    /// Token expiration time (timestamp).
    /// </summary>
    [JsonPropertyName("exp")]
    public long Expiration { get; set; }

    /// <summary>
    /// IssuedAt
    /// Token creation time.
    /// </summary>
    [JsonPropertyName("iat")]
    public long IssuedAt { get; set; } = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

    /// <summary>
    /// TokenId
    /// The ID of the token, to distinguish between tokens.
    /// </summary>
    [JsonPropertyName("jti")]
    public string TokenId { get; set; } = Guid.NewGuid().ToString();

    /// <summary>
    /// Issuer
    /// Token issuer, here is the URL of the Identity server.
    /// </summary>
    [JsonPropertyName("iss")]
    public string Issuer { get; set; }

    /// <summary>
    /// Audience
    /// </summary>
    [JsonPropertyName("aud")]
    public string Audience { get; set; }

    /// <summary>
    /// Type
    /// </summary>
    [JsonPropertyName("typ")]
    public string Type { get; set; } = "Bearer";

    /// <summary>
    /// SessionId
    /// </summary>
    [JsonPropertyName("sid")]
    public string SessionId { get; set; } = Guid.NewGuid().ToString();

    /// <summary>
    /// AllowedOrigins
    /// </summary>
    [JsonPropertyName("allowed-origins")]
    public List<string> AllowedOrigins { get; set; } = new();

    /// <summary>
    /// ResourceAccess
    /// </summary>
    [JsonPropertyName("resource_access")]
    public ResourceAccess ResourceAccess { get; set; }

    /// <summary>
    /// GroupAccess
    /// </summary>
    [JsonPropertyName("group_access")]
    public List<string> GroupAccess { get; set; } = new();

    /// <summary>
    /// Name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// Email
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; }

    /// <summary>
    /// Additional properties to convert UNIX timestamp to DateTime
    /// </summary>
    public DateTime ExpirationDate => DateTimeOffset.FromUnixTimeSeconds(Expiration).UtcDateTime;

    /// <summary>
    /// Additional properties to convert UNIX timestamp to DateTime
    /// </summary>
    public DateTime IssuedAtDate => DateTimeOffset.FromUnixTimeSeconds(IssuedAt).UtcDateTime;
}

/// <summary>
/// ResourceAccess
/// </summary>
public class ResourceAccess
{
    /// <summary>
    /// RoleAccess
    /// </summary>
    [JsonPropertyName("role_access")]
    public RoleAccess RoleAccess { get; set; }
}

/// <summary>
/// RoleAccess
/// </summary>
public class RoleAccess
{
    /// <summary>
    /// Roles
    /// </summary>
    [JsonPropertyName("roles")]
    public List<string> Roles { get; set; } = [];
}
