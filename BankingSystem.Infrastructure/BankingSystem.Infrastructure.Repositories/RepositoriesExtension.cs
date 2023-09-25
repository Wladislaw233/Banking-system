using BankingSystem.Application.Services.Interfaces;
using BankingSystem.Infrastructure.Repositories.Mapping;
using BankingSystem.Infrastructure.Repositories.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BankingSystem.Infrastructure.Repositories;

public static class RepositoriesExtension
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingClientProfile));
        services.AddAutoMapper(typeof(MappingAccountProfile));
        services.AddAutoMapper(typeof(MappingCurrencyProfile));
        services.AddAutoMapper(typeof(MappingEmployeeProfile));

        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
    }
}