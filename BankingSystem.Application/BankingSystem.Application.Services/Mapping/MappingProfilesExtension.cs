using Microsoft.Extensions.DependencyInjection;

namespace BankingSystem.Application.Services.Mapping;

public static class MappingProfilesExtension
{
    public static void AddMapping(this IServiceCollection services)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));

        services.AddAutoMapper(typeof(MappingEmployeeProfile));
        services.AddAutoMapper(typeof(MappingClientProfile));
    }
}