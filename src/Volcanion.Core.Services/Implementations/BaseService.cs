using Microsoft.Extensions.Logging;
using Volcanion.Core.Infrastructure.Abstractions;
using Volcanion.Core.Models.Common;
using Volcanion.Core.Models.Entities;
using Volcanion.Core.Models.Filter;
using Volcanion.Core.Services.Abstractions;

namespace Volcanion.Core.Services.Implementations;

/// <inheritdoc/>
public class BaseService<T, TRepository, TFilter> : IBaseService<T, TFilter>
    where T : BaseEntity
    where TFilter : FilterBase
    where TRepository : IGenericRepository<T, TFilter>
{
    /// <summary>
    /// TRepository instance
    /// </summary>
    protected readonly TRepository _repository;

    /// <summary>
    /// ILogger instance
    /// </summary>
    protected readonly ILogger<BaseService<T, TRepository, TFilter>> _logger;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="logger"></param>
    public BaseService(TRepository repository, ILogger<BaseService<T, TRepository, TFilter>> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    /// <inheritdoc/>
    public async Task<Guid> CreateAsync(T entity)
    {
        return await _repository.CreateAsync(entity);
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _repository.DeleteAsync(id);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<T>?> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    /// <inheritdoc/>
    public async Task<T?> GetAsync(Guid id)
    {
        return await _repository.GetAsync(id);
    }

    /// <inheritdoc/>
    public async Task<bool> UpdateAsync(T entity)
    {
        return await _repository.UpdateAsync(entity);
    }

    /// <inheritdoc/>
    public async Task<bool> SoftDeleteAsync(Guid id)
    {
        return await _repository.SoftDeleteAsync(id);
    }

    public async Task<DataPaging<T>> FilterDataPagingAsync(TFilter filter)
    {
        return await _repository.FilterDataPagingAsync(filter);
    }
}
