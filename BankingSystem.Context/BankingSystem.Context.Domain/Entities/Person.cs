namespace BankingSystem.ContextDomain.Entities;

public class Person
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public DateTime DateOfBirth { get; set; }
    
    public int Age { get; set; }
    
    public decimal Bonus { get; set; }
}