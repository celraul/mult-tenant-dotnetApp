using Cupcake.Application.Interfaces;
using Cupcake.Domain.Entities;
using Cupcake.Infrastructure.Context;
using Cupcake.Infrastructure.Repositories;

namespace Cupcake.Infrastructure.Uow;

public class UnitOfWork : IUnitOfWork
{
    private readonly CupcakeDbContext _context;

    public IRepository<Product> Products { get; private set; }

    public UnitOfWork(CupcakeDbContext context)
    {
        _context = context;
        Products = new Repository<Product>(_context);
    }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}