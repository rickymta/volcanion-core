﻿namespace Volcanion.Core.Models.Jwt;

/// <summary>
/// JwtPayload
/// </summary>
public class JwtPayload
{
    /// <summary>
    /// Mã người dùng
    /// </summary>
    public string AccountId { get; set; } = null!;

    /// <summary>
    /// Email người dùng
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Fullname
    /// </summary>
    public string Fullname { get; set; } = null!;

    /// <summary>
    /// Avatar
    /// </summary>
    public string Avatar { get; set; } = null!;

    /// <summary>
    /// Hệ thống tạo ra token
    /// </summary>
    public string Audiencer { get; set; } = null!;

    /// <summary>
    /// Hệ thống sẽ sử dụng token
    /// </summary>
    public string Issuer { get; set; } = null!;

    /// <summary>
    /// Session Id
    /// </summary>
    public string SessionId { get; set; } = null!;

    /// <summary>
    /// Thời gian hết hạn
    /// </summary>
    public DateTime Expired { get; set; }
}
