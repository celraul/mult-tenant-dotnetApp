using Cupcake.Infrastructure.Context;
using Cupcake.Infrastructure.Options;
using Cupcake.Infrastructure.Providers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Cupcake.Infrastructure.Repositories;
using Cupcake.Application.Interfaces;
using Cupcake.Infrastructure.Uow;
using Cupcake.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Cupcake.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<TenantSettings>(option => configuration.GetSection(nameof(TenantSettings)).Bind(option));

        services
            .AddDbContext()
            .AddRepositories();

        return services;
    }

    private static IServiceCollection AddDbContext(this IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddTransient<ITenantProvider, TenantProvider>();

        services.AddDbContext<CupcakeDbContext>((sp, o) =>
        {
            var tenantProvider = sp.GetRequiredService<ITenantProvider>();

            var connectionString = tenantProvider.GetConnectionString();

            o.UseSqlServer(connectionString);
        });

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        return services;
    }
}
