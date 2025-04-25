using Volcanion.Core.Models.Enums;
using Volcanion.Core.Models.Jwt;

namespace Volcanion.Core.Common.Abstractions;

/// <summary>
/// IJwtProvider
/// </summary>
public interface IJwtProvider
{
    /// <summary>
    /// GenerateJwt
    /// </summary>
    /// <param name="data"></param>
    /// <param name="audience"></param>
    /// <param name="issuer"></param>
    /// <param name="allowedOrigins"></param>
    /// <param name="resourceAccess"></param>
    /// <param name="type"></param>
    /// <param name="sessionId"></param>
    /// <param name="email"></param>
    /// <returns></returns>
    string GenerateJwt(object data, string audience, string issuer, List<string> allowedOrigins, ResourceAccess resourceAccess, JwtType type, string sessionId);

    /// <summary>
    /// ValidateJwt
    /// </summary>
    /// <param name="jwt"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    bool ValidateJwt(string jwt, JwtType? type);

    /// <summary>
    /// DecodeJwt
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    (VolcanionJwtHeader? header, VolcanionJwtPayload? payload) DecodeJwt(string token);
}
