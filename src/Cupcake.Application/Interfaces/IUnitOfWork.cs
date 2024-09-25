using Cupcake.Domain.Entities;

namespace Cupcake.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<Product> Products { get; }
    Task<int> CompleteAsync();
}