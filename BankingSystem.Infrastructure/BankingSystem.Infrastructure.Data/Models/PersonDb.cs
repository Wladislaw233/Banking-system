using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Infrastructure.Data.Models;

public class PersonDb
{
    [Required]
    [StringLength(150, MinimumLength = 2)]
    [Column("first_name", Order = 1)]
    public string FirstName { get; set; }
    
    [Required]
    [StringLength(150, MinimumLength = 2)]
    [Column("last_name", Order = 2)]
    public string LastName { get; set; }
    
    [Required]
    [Column("date_of_birth", Order = 3)]
    public DateTime DateOfBirth { get; set; }
    
    [Required]
    [Column("age", Order = 4)]
    public int Age { get; set; }
    
    [Column("bonus", Order = 5)]
    [Precision(14,2)]
    public decimal Bonus { get; set; }
}