using BankingSystemServices.Models.DTO;
using FluentValidation;

namespace BankingSystem.Infrastructure.Api.Validation;

public class EmployeeDtoValidation : AbstractValidator<EmployeeDto>
{
    public EmployeeDtoValidation()
    {
        RuleFor(employeeDto => employeeDto.FirstName).NotEmpty().NotNull()
            .WithMessage("Employee first name not specified!");
        
        RuleFor(employeeDto => employeeDto.LastName).NotEmpty().NotNull()
            .WithMessage("Employee last name is not specified!");

        RuleFor(employeeDto => employeeDto.DateOfBirth).NotEmpty().NotNull()
            .WithMessage("Employee date of birth is not specified!");
        
        RuleFor(employeeDto => employeeDto.DateOfBirth)
            .Must(dateOfBirth => AgeValidator.CalculateAge(dateOfBirth) > 17)
            .WithMessage("the employee must be over 18 years old.");

        RuleFor(employeeDto => employeeDto.Age)
            .Must((clientDto, age) => age == AgeValidator.CalculateAge(clientDto.DateOfBirth))
            .WithMessage("Employee age is incorrect.");

        RuleFor(employeeDto => employeeDto.PhoneNumber).NotEmpty().NotNull()
            .WithMessage("Employee phone number not specified.")
            .Matches(@"^\+[1-9]\d{10,14}$").WithMessage("Employee phone number is incorrect.");

        RuleFor(employeeDto => employeeDto.Email).NotEmpty().NotNull().WithMessage("Employee email not specified.")
            .EmailAddress().WithMessage("The employee's email is incorrect.");

        RuleFor(employeeDto => employeeDto.Address).NotEmpty().NotNull().WithMessage("Employee address not specified.");

        RuleFor(employeeDto => employeeDto.Contract).NotEmpty().NotNull()
            .WithMessage("Employee contract not specified.");

        RuleFor(employeeDto => employeeDto.Salary).NotEmpty().NotNull().WithMessage("Employee salary not specified.");
    }
}