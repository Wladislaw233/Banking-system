using BankingSystem.Application.Services.Dto;
using FluentValidation;

namespace BankingSystem.Infrastructure.Api.Validation;

public class ClientDtoValidation : AbstractValidator<ClientDto>
{
    public ClientDtoValidation()
    {
        RuleFor(clientDto => clientDto.FirstName).NotEmpty().NotNull()
            .WithMessage("Client first name not specified!");
        
        RuleFor(clientDto => clientDto.LastName).NotEmpty().NotNull()
            .WithMessage("Client last name is not specified!");

        RuleFor(clientDto => clientDto.DateOfBirth).NotEmpty().NotNull()
            .WithMessage("Client date of birth is not specified!");
        
        RuleFor(clientDto => clientDto.DateOfBirth)
            .Must(dateOfBirth => AgeValidator.CalculateAge(dateOfBirth) > 17)
            .WithMessage("the client must be over 18 years old.");

        RuleFor(clientDto => clientDto.Age)
            .Must((clientDto, age) => age == AgeValidator.CalculateAge(clientDto.DateOfBirth))
            .WithMessage("Client age is incorrect.");

        RuleFor(clientDto => clientDto.PhoneNumber).NotEmpty().NotNull()
            .WithMessage("Client phone number not specified.")
            .Matches(@"^\+[1-9]\d{10,14}$").WithMessage("Client phone number is incorrect.");

        RuleFor(clientDto => clientDto.Email).NotEmpty().NotNull().WithMessage("Client email not specified.")
            .EmailAddress().WithMessage("The client's email is incorrect.");

        RuleFor(clientDto => clientDto.Address).NotEmpty().NotNull().WithMessage("Client address not specified.");
    }
}