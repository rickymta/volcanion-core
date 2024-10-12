using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;
using Volcanion.Core.Infrastructure.Abstractions;
using Volcanion.Core.Infrastructure.Models.Context;
using Volcanion.Core.Infrastructure.Models.Entities;

namespace Volcanion.Core.Infrastructure.Implementations;

/// <summary>
/// BaseRepository
/// </summary>
public class BaseRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly ApplicationDbContext _context;

    protected readonly IConfiguration _configuration;

    protected readonly ILogger<BaseRepository<T>> _logger;

    public BaseRepository(ApplicationDbContext context, IConfiguration configuration, ILogger<BaseRepository<T>> logger)
    {
        _context = context;
        _configuration = configuration;
        _logger = logger;
    }

    /// <inheritdoc/>
    public async Task<string> CreateAsync(T entity)
    {
        try
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            _logger.LogError(ex.StackTrace);
            throw new Exception(ex.Message);
        }
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteAsync(string id)
    {
        try
        {
            T? entity = await _context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            _logger.LogError(ex.StackTrace);
            throw new Exception(ex.Message);
        }

        return false;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<T>?> GetAllAsync()
    {
        try
        {
            var res = await _context.Set<T>().ToListAsync();
            return res;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            _logger.LogError(ex.StackTrace);
            throw new Exception(ex.Message);
        }
    }

    /// <inheritdoc/>
    public async Task<T?> GetAsync(string id)
    {
        try
        {
            T? entity = await _context.Set<T>().FindAsync(id);
            return entity;
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
            T? find = await _context.Set<T>().FindAsync(entity.Id);
            if (find != null)
            {
                foreach (PropertyInfo property in typeof(T).GetProperties().Where(p => p.CanWrite))
                {
                    if (property.Name.Equals("CreatedAt") || property.Name.Equals("CreatedBy"))
                    {
                        continue;
                    }

                    property.SetValue(find, property.GetValue(entity, null), null);
                }

                await _context.SaveChangesAsync();
                return true;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            _logger.LogError(ex.StackTrace);
            throw new Exception(ex.Message);
        }

        return false;
    }
}
