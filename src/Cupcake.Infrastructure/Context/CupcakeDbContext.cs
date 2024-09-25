using Cupcake.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cupcake.Infrastructure.Context;

public class CupcakeDbContext : DbContext
{
    public CupcakeDbContext(DbContextOptions<CupcakeDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Product>()
            .HasQueryFilter(o => !o.IsDeleted);
    }
}
