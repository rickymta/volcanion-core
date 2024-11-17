using Microsoft.Extensions.Logging;
using Volcanion.Core.Handlers.Abstractions;
using Volcanion.Core.Models.Entities;
using Volcanion.Core.Services.Abstractions;

namespace Volcanion.Core.Handlers.Implementations;

/// <inheritdoc/>
public class BaseHandler<T, TService> : IBaseHandler<T>
    where T : BaseEntity
    where TService : IBaseService<T>
{
    /// <summary>
    /// TService instance
    /// </summary>
    protected readonly TService _service;

    /// <summary>
    /// ILogger instance
    /// </summary>
    protected readonly ILogger<BaseHandler<T, TService>> _logger;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="service"></param>
    /// <param name="logger"></param>
    public BaseHandler(TService service, ILogger<BaseHandler<T, TService>> logger)
    {
        _service = service;
        _logger = logger;
    }

    /// <inheritdoc/>
    public async Task<Guid> CreateAsync(T entity)
    {
        return await _service.CreateAsync(entity);
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _service.DeleteAsync(id);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<T>?> GetAllAsync()
    {
        return await _service.GetAllAsync();
    }

    /// <inheritdoc/>
    public async Task<T?> GetAsync(Guid id)
    {
        return await _service.GetAsync(id);
    }

    /// <inheritdoc/>
    public async Task<bool> UpdateAsync(T entity)
    {
        return await _service.UpdateAsync(entity);
    }

    /// <inheritdoc/>
    public async Task<bool> SoftDeleteAsync(Guid id)
    {
        return await _service.SoftDeleteAsync(id);
    }
}
