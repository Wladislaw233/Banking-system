using BankingSystem.Infrastructure.Api.Validation;

namespace BankingSystem.Context.Tests.Validation;

public class AgeValidatorTests
{
    [Theory]
    [InlineData("2000-01-01", "2023-09-19", 23)]
    [InlineData("1995-12-31", "2023-09-19", 27)]
    [InlineData("2023-09-19", "2023-09-19", 0)]
    [InlineData("2023-09-20", "2023-09-19", -1)]
    [InlineData("1990-12-31", "2023-09-19", 32)]
    public void CalculateAge_ValidInput_ReturnsCorrectAge(string dateOfBirthString, string currentDataString, int currentAge)
    {
        //Arrange
        var dateOfBirth = DateTime.Parse(dateOfBirthString);
        var currentDate = DateTime.Parse(currentDataString);
        
        //Act
        var age = AgeValidator.CalculateAge(dateOfBirth, currentDate);
        
        //Assert
        Assert.Equal(age, currentAge);
    }
}