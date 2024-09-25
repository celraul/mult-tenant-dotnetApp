namespace Cupcake.Infrastructure.Options;

public class TenantSettings
{
    public List<Tenant> Tenants { get; set; } = new();
}

public class Tenant
{
    public string ConnectionString { get; set; } = string.Empty;
    public string TenantId { get; set; } = string.Empty;
}
