using System.Linq.Expressions;
using Volcanion.Core.Models.Common;
using Volcanion.Core.Models.Entities;
using Volcanion.Core.Models.Filter;

namespace Volcanion.Core.Infrastructure.Abstractions;

/// <summary>
/// IGenericRepository
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IGenericRepository<T, TFilter>
    where T : BaseEntity
    where TFilter : FilterBase
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
    /// FilterDataPagingAsync
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    Task<DataPaging<T>> FilterDataPagingAsync(TFilter filter);

    /// <summary>
    /// FilterDataPagingByExpressionAsync
    /// </summary>
    /// <param name="expression"></param>
    /// <param name="filter"></param>
    /// <returns></returns>
    Task<DataPaging<T>> FilterDataPagingByExpressionAsync(Expression<Func<T, bool>> expression, TFilter filter);

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
