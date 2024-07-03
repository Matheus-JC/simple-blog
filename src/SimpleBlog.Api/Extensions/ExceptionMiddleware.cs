using System.Net;

namespace SimpleBlog.Api.Extensions;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<ExceptionMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exc)
        {
            _logger.LogError(exc, "An unknown error has occurred");
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }
    }
}
