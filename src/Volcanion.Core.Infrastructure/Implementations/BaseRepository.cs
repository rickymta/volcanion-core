using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using System.Reflection;
using Volcanion.Core.Infrastructure.Abstractions;
using Volcanion.Core.Models.Common;
using Volcanion.Core.Models.Entities;
using Volcanion.Core.Models.Filter;

namespace Volcanion.Core.Infrastructure.Implementations;

/// <inheritdoc/>
public class BaseRepository<T, TContext, TFilter> : IGenericRepository<T, TFilter>
    where T : BaseEntity
    where TContext : DbContext
    where TFilter : FilterBase
{
    /// <summary>
    /// TContext instance
    /// </summary>
    protected TContext _context;

    /// <summary>
    /// ILogger instance
    /// </summary>
    protected ILogger<BaseRepository<T, TContext, TFilter>> _logger;

    /// <summary>
    /// IHttpContextAccessor instance
    /// </summary>
    protected IHttpContextAccessor _httpContextAccessor;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="context"></param>
    /// <param name="logger"></param>
    public BaseRepository(TContext context, ILogger<BaseRepository<T, TContext, TFilter>> logger, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
    }

    /// <inheritdoc/>
    public async Task<Guid> CreateAsync(T entity)
    {
        try
        {
            var routeData = _httpContextAccessor.HttpContext.GetRouteData().Values;
            var accountId = routeData["AccountId"];
            entity.CreatedBy = accountId.ToString();
            entity.CreatedAt = DateTimeOffset.Now;
            // Add entity to the context
            await _context.Set<T>().AddAsync(entity);
            // Save changes
            await _context.SaveChangesAsync();
            // Return entity id
            return entity.Id;
        }
        catch (Exception ex)
        {
            // Log error
            _logger.LogError(ex.Message);
            _logger.LogError(ex.StackTrace);
            // Throw exception
            throw new Exception(ex.Message);
        }
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteAsync(Guid id)
    {
        try
        {
            // Find entity by id
            T? entity = await _context.Set<T>().FindAsync(id);
            // If entity found
            if (entity != null)
            {
                // Remove entity
                _context.Set<T>().Remove(entity);
                // Save changes
                await _context.SaveChangesAsync();
                return true;
            }
        }
        catch (Exception ex)
        {
            // Log error
            _logger.LogError(ex.Message);
            _logger.LogError(ex.StackTrace);
            // Throw exception
            throw new Exception(ex.Message);
        }

        return false;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<T>?> GetAllAsync()
    {
        try
        {
            // Get all entities
            var res = await _context.Set<T>().ToListAsync();
            // Return entities
            return res;
        }
        catch (Exception ex)
        {
            // Log error
            _logger.LogError(ex.Message);
            _logger.LogError(ex.StackTrace);
            // Throw exception
            throw new Exception(ex.Message);
        }
    }

    /// <inheritdoc/>
    public async Task<T?> GetAsync(Guid id)
    {
        try
        {
            // Find entity by id
            T? entity = await _context.Set<T>().FindAsync(id);
            // Return entity
            return entity;
        }
        catch (Exception ex)
        {
            // Log error
            _logger.LogError(ex.Message);
            _logger.LogError(ex.StackTrace);
            // Throw exception
            throw new Exception(ex.Message);
        }
    }

    /// <inheritdoc/>
    public async Task<bool> UpdateAsync(T entity)
    {
        try
        {
            // Find entity by id
            T? find = await _context.Set<T>().FindAsync(entity.Id);
            // If entity found
            if (find != null)
            {
                // Update entity properties
                foreach (PropertyInfo property in typeof(T).GetProperties().Where(p => p.CanWrite))
                {
                    // Skip CreatedAt and CreatedBy properties
                    if (property.Name.Equals("CreatedAt") || property.Name.Equals("CreatedBy"))
                    {
                        // Continue to next property
                        continue;
                    }

                    // Set property value
                    property.SetValue(find, property.GetValue(entity, null), null);
                }

                var routeData = _httpContextAccessor.HttpContext.GetRouteData().Values;
                var accountId = routeData["AccountId"];
                find.UpdatedBy = accountId.ToString();
                find.UpdatedAt = DateTimeOffset.Now;
                // Save changes
                await _context.SaveChangesAsync();
                return true;
            }
        }
        catch (Exception ex)
        {
            // Log error
            _logger.LogError(ex.Message);
            _logger.LogError(ex.StackTrace);
            // Throw exception
            throw new Exception(ex.Message);
        }

        return false;
    }

    /// <inheritdoc/>
    public async Task<bool> SoftDeleteAsync(Guid id)
    {
        try
        {
            // Find entity by id
            T? find = await _context.Set<T>().FindAsync(id);
            // If entity found
            if (find != null)
            {
                var routeData = _httpContextAccessor.HttpContext.GetRouteData().Values;
                var accountId = routeData["AccountId"];
                find.IsActived = false;
                find.IsDeleted = true;
                find.DeletedBy = accountId.ToString();
                find.DeletedAt = DateTimeOffset.Now;

                // Save changes
                await _context.SaveChangesAsync();
                return true;
            }
        }
        catch (Exception ex)
        {
            // Log error
            _logger.LogError(ex.Message);
            _logger.LogError(ex.StackTrace);
            // Throw exception
            throw new Exception(ex.Message);
        }

        return false;
    }

    /// <inheritdoc/>
    public Task<DataPaging<T>> FilterDataPagingAsync(TFilter filter)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public Task<DataPaging<T>> FilterDataPagingByExpressionAsync(Expression<Func<T, bool>> expression, TFilter filter)
    {
        throw new NotImplementedException();
    }
}
