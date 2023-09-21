namespace BankingSystem.Infrastructure.Api.Validation;

public static class AgeValidator
{
    public static int CalculateAge(DateTime dateOfBirth, DateTime? currentDate = null)
    {
        currentDate ??= DateTime.Today;
        
        var today = (DateTime)currentDate;
        
        var age = today.Year - dateOfBirth.Year;
        
        if (dateOfBirth.Date > today.AddYears(-age))
        {
            age--;
        }
        
        return age;
    }
}