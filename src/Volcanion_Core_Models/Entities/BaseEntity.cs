namespace Volcanion_Core_Models.Entities;

/// <summary>
/// Base Entity
/// </summary>
public class BaseEntity
{
    /// <summary>
    /// GUID
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// IsActived
    /// </summary>
    public bool IsActived { get; set; }

    /// <summary>
    /// IsDeleted
    /// </summary>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// CreatedAt
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// CreatedId
    /// </summary>
    public string? CreatedBy { get; set; }

    /// <summary>
    /// UpdatedAt
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// UpdatedId
    /// </summary>
    public string? UpdatedBy { get; set; }

    /// <summary>
    /// DeletedAt
    /// </summary>
    public DateTime? DeletedAt { get; set; }

    /// <summary>
    /// DeletedId
    /// </summary>
    public string? DeletedBy { get; set; }
}
