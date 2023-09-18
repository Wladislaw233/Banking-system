using Microsoft.Extensions.DependencyInjection;

namespace BankingSystem.Infrastructure.Data.Context;

public static class DbContextExtension
{
    public static void AddBankingSystemDbContext(this IServiceCollection services)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));

        services.AddDbContext<BankingSystemDbContext>();
    }
}