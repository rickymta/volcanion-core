namespace Volcanion.Core.Models.Request;

/// <summary>
/// EntityStatusUpdate
/// </summary>
public class EntityStatusUpdate
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// IsActived
    /// </summary>
    public bool IsActived { get; set; }
}
