using BankingSystem.Application.Services.Interfaces;
using BankingSystem.Application.Services.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace BankingSystem.Application.Services.Services;

public static class BankServicesExtension
{
    public static void AddBankServices(this IServiceCollection services)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));
        
        services.AddAutoMapper(typeof(MappingEmployeeProfile));
        services.AddAutoMapper(typeof(MappingClientProfile));
        
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IClientService, ClientService>();
    }
}