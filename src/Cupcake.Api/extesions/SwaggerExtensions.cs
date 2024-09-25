using Cupcake.Api.HeaderParams;

namespace Cupcake.Api.extesions;

public static class SwaggerExtensions
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new() { Title = "Cupcake API", Version = "v1" });

            // Add custom header globally to all endpoints
            c.OperationFilter<AddHeaderParameterOperationFilter>();
        });

        return services;
    }
}
