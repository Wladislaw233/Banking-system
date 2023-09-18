using BankingSystem.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BankingSystem.Application.Services.Services;

public static class BankServicesExtension
{
    public static void AddBankServices(this IServiceCollection services)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));
        
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IClientService, ClientService>();
    }
}