using Newtonsoft.Json;

namespace Volcanion.Core.Models.Entities;

/// <summary>
/// Base Entity
/// </summary>
public class BaseEntity
{
    /// <summary>
    /// GUID
    /// </summary>
    [JsonProperty("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// IsActived
    /// </summary>
    [JsonIgnore]
    public bool IsActived { get; set; } = true;

    /// <summary>
    /// IsDeleted
    /// </summary>
    [JsonIgnore]
    public bool IsDeleted { get; set; } = false;

    /// <summary>
    /// CreatedAt
    /// </summary>
    [JsonIgnore]
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;

    /// <summary>
    /// CreatedId
    /// </summary>
    [JsonIgnore]
    public string? CreatedBy { get; set; }

    /// <summary>
    /// UpdatedAt
    /// </summary>
    [JsonIgnore]
    public DateTimeOffset? UpdatedAt { get; set; }

    /// <summary>
    /// UpdatedId
    /// </summary>
    [JsonIgnore]
    public string? UpdatedBy { get; set; }

    /// <summary>
    /// DeletedAt
    /// </summary>
    [JsonIgnore]
    public DateTimeOffset? DeletedAt { get; set; }

    /// <summary>
    /// DeletedId
    /// </summary>
    [JsonIgnore]
    public string? DeletedBy { get; set; }
}
