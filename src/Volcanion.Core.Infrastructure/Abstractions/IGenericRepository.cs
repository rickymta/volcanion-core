using Volcanion.Core.Models.Entities;

namespace Volcanion.Core.Infrastructure.Abstractions;

/// <summary>
/// IGenericRepository
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IGenericRepository<T>
    where T : BaseEntity
{
    /// <summary>
    /// CreateAsync
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<Guid> CreateAsync(T entity);

    /// <summary>
    /// GetAsync
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<T?> GetAsync(Guid id);

    /// <summary>
    /// GetAllAsync
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<T>?> GetAllAsync();

    /// <summary>
    /// UpdateAsync
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<bool> UpdateAsync(T entity);

    /// <summary>
    /// DeleteAsync
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteAsync(Guid id);

    /// <summary>
    /// SoftDeleteAsync
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> SoftDeleteAsync(Guid id);
}
