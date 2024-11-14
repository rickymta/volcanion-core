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
        try
        {
            return await _service.CreateAsync(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            _logger.LogError(ex.StackTrace);
            throw new Exception(ex.Message);
        }
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteAsync(Guid id)
    {
        try
        {
            return await _service.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            _logger.LogError(ex.StackTrace);
            throw new Exception(ex.Message);
        }
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<T>?> GetAllAsync()
    {
        try
        {
            return await _service.GetAllAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            _logger.LogError(ex.StackTrace);
            throw new Exception(ex.Message);
        }
    }

    /// <inheritdoc/>
    public async Task<T?> GetAsync(Guid id)
    {
        try
        {
            return await _service.GetAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            _logger.LogError(ex.StackTrace);
            throw new Exception(ex.Message);
        }
    }

    /// <inheritdoc/>
    public async Task<bool> UpdateAsync(T entity)
    {
        try
        {
            return await _service.UpdateAsync(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            _logger.LogError(ex.StackTrace);
            throw new Exception(ex.Message);
        }
    }
}
