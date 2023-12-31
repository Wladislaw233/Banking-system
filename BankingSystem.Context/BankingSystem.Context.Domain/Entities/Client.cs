﻿namespace BankingSystem.ContextDomain.Entities;

public class Client : Person
{
    public Guid ClientId { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public string Email { get; set; }
    
    public string Address { get; set; }
    
    public override bool Equals(object? obj)
    {
        if (obj == null || !(obj is Client))
            return false;

        var client = (Client)obj;

        return client.FirstName == FirstName &&
               client.LastName == LastName &&
               client.PhoneNumber == PhoneNumber &&
               client.Address == Address &&
               client.Email == Email &&
               client.DateOfBirth.Equals(DateOfBirth) &&
               client.Age == Age;
    }

    public override int GetHashCode()
    {
        var hash = 14;
        hash = hash * 17 + FirstName.GetHashCode();
        hash = hash * 17 + LastName.GetHashCode();
        hash = hash * 17 + DateOfBirth.GetHashCode();
        hash = hash * 17 + Age.GetHashCode();
        hash = hash * 17 + PhoneNumber.GetHashCode();
        hash = hash * 17 + Email.GetHashCode();
        hash = hash * 17 + Address.GetHashCode();
        
        return hash;
    }
}