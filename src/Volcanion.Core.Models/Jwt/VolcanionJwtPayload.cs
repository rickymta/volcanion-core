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
    public long Expiration { get; set; }

    /// <summary>
    /// IssuedAt
    /// Token creation time.
    /// </summary>
    public long IssuedAt { get; set; } = DateTimeOffset.Now.ToUnixTimeSeconds();

    /// <summary>
    /// TokenId
    /// The ID of the token, to distinguish between tokens.
    /// </summary>
    public string TokenId { get; set; } = Guid.NewGuid().ToString();

    /// <summary>
    /// Issuer
    /// Token issuer, here is the URL of the Identity server.
    /// </summary>
    public string Issuer { get; set; } = "";

    /// <summary>
    /// Audience
    /// </summary>
    public string Audience { get; set; } = "";

    /// <summary>
    /// Type
    /// </summary>
    public string Type { get; set; } = "Bearer";

    /// <summary>
    /// SessionId
    /// </summary>
    public string SessionId { get; set; } = Guid.NewGuid().ToString();

    /// <summary>
    /// AllowedOrigins
    /// </summary>
    public List<string> AllowedOrigins { get; set; } = [];

    /// <summary>
    /// ResourceAccess
    /// </summary>
    public ResourceAccess ResourceAccess { get; set; } = null!;

    /// <summary>
    /// GroupAccess
    /// </summary>
    public List<string> GroupAccess { get; set; } = [];

    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// Email
    /// </summary>
    public string Email { get; set; } = "";

    /// <summary>
    /// Data
    /// </summary>
    public object? Data { get; set; }

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
    public List<string> Roles { get; set; } = [];
}
