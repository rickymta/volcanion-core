namespace Volcanion_Core_Models.Filter;

/// <summary>
/// FilterBase
/// </summary>
public class FilterBase
{
    /// <summary>
    /// Limit
    /// </summary>
    public int? Limit { get; set; }

    /// <summary>
    /// Page
    /// </summary>
    public int? Page { get; set; }

    /// <summary>
    /// Offset
    /// </summary>
    public int? Offset { get; set; }

    /// <summary>
    /// IsActived
    /// </summary>
    public bool? IsActived { get; set; }
}
