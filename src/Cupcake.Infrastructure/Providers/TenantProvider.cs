using Cupcake.Infrastructure.Interfaces;
using Cupcake.Infrastructure.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Cupcake.Infrastructure.Providers;

public sealed class TenantProvider : ITenantProvider
{
    private const string TenantIdHeaderName = "X-TenantId";

    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly TenantSettings _tenantSettings;

    public TenantProvider(IHttpContextAccessor httpContextAccessor, IOptions<TenantSettings> tenantsOptions)
    {
        _httpContextAccessor = httpContextAccessor;
        _tenantSettings = tenantsOptions.Value;
    }

    public string TenantId()
    {
        string? tenantId = _httpContextAccessor.HttpContext.Request.Headers[TenantIdHeaderName];
        if (tenantId is null)
            throw new Exception("Tenant header not found.");

        return tenantId ?? string.Empty;
    }

    public string GetConnectionString()
    {
        Tenant tenant = _tenantSettings.Tenants.FirstOrDefault(t => t.TenantId == TenantId()) ??
             throw new Exception("Tenant header not found.");

        return tenant.ConnectionString;
    }
}
