namespace BankingSystem.Infrastructure.Api.Middlewares;

public static class ExceptionHandlerMiddlewareExtension
{
    public static void UseExceptionMiddleware(this IApplicationBuilder builder)
    {
        if (builder == null)
            throw new ArgumentNullException(nameof(builder));

        builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}