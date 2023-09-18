using System.Net;
using BankingSystem.ContextDomain.Exceptions;
using BankingSystem.Infrastructure.Api.Middlewares.Details;

namespace BankingSystem.Infrastructure.Api.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception exc)
        {
            await ExceptionHandleAsync(httpContext, exc);
        }
    }

    private async Task ExceptionHandleAsync(HttpContext httpContext, Exception exception)
    {
        var statusCode = exception switch
        {
            ArgumentException => HttpStatusCode.BadRequest,
            ValueNotFoundException => HttpStatusCode.NotFound,
            _ => HttpStatusCode.InternalServerError
        };

        var excMsg = exception.ToString();
        
        _logger.LogError(excMsg);
        
        var response = httpContext.Response;

        response.ContentType = "application/json";
        response.StatusCode = (int)statusCode;
        
        var errorDetails = new ErrorDetails()
        {
            StatusCode = (int)statusCode,
            ErrorMessage = excMsg
        };
        
        await response.WriteAsJsonAsync(errorDetails.ToString());
    }
}