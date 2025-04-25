namespace Volcanion.Identity.Models.Setting;

/// <summary>
/// JwtSetting
/// </summary>
public class JwtSettings
{
    /// <summary>
    /// PrivateKeyFilePath
    /// </summary>
    public string PrivateKeyFilePath { get; set; } = "volcanion-private.pem";

    /// <summary>
    /// PublicKeyFilePath
    /// </summary>
    public string PublicKeyFilePath { get; set; } = "volcanion-public.pem";

    /// <summary>
    /// AccessTokenExpiredTime
    /// </summary>
    public string AccessTokenExpiredTime { get; set; } = "10";

    /// <summary>
    /// RefreshTokenExpiredTime
    /// </summary>
    public string RefreshTokenExpiredTime { get; set; } = "30";
}
