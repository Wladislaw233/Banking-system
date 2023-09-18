namespace BankingSystem.Infrastructure.Api.Middlewares;

public static class ExceptionHandlerMiddlewareExtension
{
    public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
    {
        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder));
        }
        
        return builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}