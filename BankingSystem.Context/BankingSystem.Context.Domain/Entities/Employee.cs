namespace BankingSystem.ContextDomain.Entities;

public class Employee : Person
{
    public Guid EmployeeId { get; set; }
    
    public string Contract { get; set; }
    
    public decimal Salary { get; set; }
    
    public string Address { get; set; }
    
    public string Email { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public bool IsOwner { get; set; }
    
    public override bool Equals(object? obj)
    {
        if (obj == null || !(obj is Employee))
            return false;

        var employee = (Employee)obj;

        return employee.FirstName == FirstName &&
               employee.LastName == LastName &&
               employee.PhoneNumber == PhoneNumber &&
               employee.Address == Address &&
               employee.Email == Email &&
               employee.DateOfBirth.Equals(DateOfBirth) &&
               employee.Age == Age &&
               employee.Contract == Contract &&
               employee.Salary.Equals(Salary) &&
               employee.IsOwner == IsOwner &&
               employee.Bonus == Bonus;
    }

    public override int GetHashCode()
    {
        var hash = 11;
        hash = hash * 17 + FirstName.GetHashCode();
        hash = hash * 17 + LastName.GetHashCode();
        hash = hash * 17 + DateOfBirth.GetHashCode();
        hash = hash * 17 + Age.GetHashCode();
        hash = hash * 17 + PhoneNumber.GetHashCode();
        hash = hash * 17 + Email.GetHashCode();
        hash = hash * 17 + Address.GetHashCode();
        hash = hash * 17 + Contract.GetHashCode();
        hash = hash * 17 + Salary.GetHashCode();
        hash = hash * 17 + IsOwner.GetHashCode();
        hash = hash * 17 + Bonus.GetHashCode();
        
        return hash;
    }
}