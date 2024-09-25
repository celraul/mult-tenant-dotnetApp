using Cupcake.Infrastructure;
using Cupcake.Application;
using Cupcake.Api.Core.Middlewares;
using Cupcake.Api.extesions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services
    .AddEndpointsApiExplorer();

builder.Services.AddSwagger();

// configure services
builder.Services
    .AddInfraServices(builder.Configuration)
    .AddServices();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
