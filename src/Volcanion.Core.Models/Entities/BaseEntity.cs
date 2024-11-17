namespace Volcanion.Core.Models.Entities;

/// <summary>
/// Base Entity
/// </summary>
public class BaseEntity
{
    /// <summary>
    /// GUID
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// IsActived
    /// </summary>
    public bool IsActived { get; set; } = true;

    /// <summary>
    /// IsDeleted
    /// </summary>
    public bool IsDeleted { get; set; } = false;

    /// <summary>
    /// CreatedAt
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;

    /// <summary>
    /// CreatedId
    /// </summary>
    public string? CreatedBy { get; set; }

    /// <summary>
    /// UpdatedAt
    /// </summary>
    public DateTimeOffset? UpdatedAt { get; set; }

    /// <summary>
    /// UpdatedId
    /// </summary>
    public string? UpdatedBy { get; set; }

    /// <summary>
    /// DeletedAt
    /// </summary>
    public DateTimeOffset? DeletedAt { get; set; }

    /// <summary>
    /// DeletedId
    /// </summary>
    public string? DeletedBy { get; set; }
}
