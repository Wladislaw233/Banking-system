namespace BankingSystem.Infrastructure.Api.Validation;

public static class AgeValidator
{
    public static bool Over18YearsOld(DateTime dateOfBirth)
    {
        var age = CalculateAge(dateOfBirth); 
        return age >= 18;
    }

    public static bool ValidateAge(DateTime dateOfBirth, int age)
    {
        var calculatedAge = CalculateAge(dateOfBirth);
        return age == calculatedAge;
    }
    
    private static int CalculateAge(DateTime dateOfBirth)
    {
        var today = DateTime.Today;
        var age = today.Year - dateOfBirth.Year;
        if (dateOfBirth.Date > today.AddYears(-age)) age--;
        return age;
    }
}