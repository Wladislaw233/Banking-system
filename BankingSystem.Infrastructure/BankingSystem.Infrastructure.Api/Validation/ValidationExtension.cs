using BankingSystem.Application.Services.Dto;
using BankingSystemServices.Models.DTO;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace BankingSystem.Infrastructure.Api.Validation;

public static class ValidationExtension
{
    public static void AddValidation(this IServiceCollection services)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));

        services.AddFluentValidationAutoValidation();
        
        services.AddScoped<IValidator<ClientDto>, ClientDtoValidation>();
        services.AddScoped<IValidator<EmployeeDto>, EmployeeDtoValidation>();
    }
}