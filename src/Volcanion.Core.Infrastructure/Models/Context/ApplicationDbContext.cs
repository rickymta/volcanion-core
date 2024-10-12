using Microsoft.EntityFrameworkCore;

namespace Volcanion.Core.Infrastructure.Models.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingInternal(modelBuilder);
    }

    internal static void OnModelCreatingInternal(ModelBuilder modelBuilder)
    {

    }
}
