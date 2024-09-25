using Cupcake.Api.Core.Models;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace Cupcake.Api.Core.Middlewares;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = context.Response;
        response.ContentType = "application/json";

        var apiResponse = new ApiResponse<string>() { Success = false };

        int statusCode = (int)HttpStatusCode.InternalServerError;

        apiResponse.errors = new List<string>() { exception.Message };

        response.StatusCode = statusCode;

        return response.WriteAsync(JsonSerializer.Serialize(apiResponse));
    }
}
