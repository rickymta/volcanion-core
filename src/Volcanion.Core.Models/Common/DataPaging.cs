namespace Volcanion.Core.Models.Common;

/// <summary>
/// DataPaging
/// </summary>
public class DataPaging
{
    /// <summary>
    /// Data
    /// </summary>
    public IEnumerable<object> Data { get; set; } = [];

    /// <summary>
    /// PaginationCount
    /// </summary>
    public int PaginationCount { get; set; } = 0;
}

/// <summary>
/// DataPaging
/// </summary>
/// <typeparam name="T"></typeparam>
public class DataPaging<T>
{
    /// <summary>
    /// Data
    /// </summary>
    public IEnumerable<T> Data { get; set; } = [];

    /// <summary>
    /// PaginationCount
    /// </summary>
    public int PaginationCount { get; set; } = 0;
}
