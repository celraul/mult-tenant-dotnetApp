namespace Cupcake.Infrastructure.Interfaces;

public interface ITenantProvider
{
    public string TenantId();
    string GetConnectionString();
}
