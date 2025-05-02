namespace Wallet.Api.Middleware;

/// <summary>
/// Handler the exceptions
/// </summary>
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        if (httpContext == null)
        {
            return;
        }

        try
        {
            await _next(httpContext);
        }
        catch (Exception ex) when (!httpContext.Response.HasStarted)
        {
            await httpContext.HandleExceptionAsync(ex);
        }
    }
}