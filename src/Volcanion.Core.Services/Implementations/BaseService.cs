using Microsoft.Extensions.Logging;
using Volcanion.Core.Infrastructure.Abstractions;
using Volcanion.Core.Models.Entities;
using Volcanion.Core.Services.Abstractions;

namespace Volcanion.Core.Services.Implementations;

/// <inheritdoc/>
public class BaseService<T, TRepository> : IBaseService<T>
    where T : BaseEntity
    where TRepository : IGenericRepository<T>
{
    /// <summary>
    /// TRepository
    /// </summary>
    protected readonly TRepository _repository;

    /// <summary>
    /// ILogger
    /// </summary>
    protected readonly ILogger<BaseService<T, TRepository>> _logger;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="logger"></param>
    public BaseService(TRepository repository, ILogger<BaseService<T, TRepository>> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    /// <inheritdoc/>
    public async Task<Guid> CreateAsync(T entity)
    {
        try
        {
            return await _repository.CreateAsync(entity);
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
            return await _repository.DeleteAsync(id);
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
            return await _repository.GetAllAsync();
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
            return await _repository.GetAsync(id);
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
            return await _repository.UpdateAsync(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            _logger.LogError(ex.StackTrace);
            throw new Exception(ex.Message);
        }
    }
}
