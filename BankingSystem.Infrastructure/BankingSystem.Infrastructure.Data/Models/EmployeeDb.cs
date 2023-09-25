using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Infrastructure.Data.Models;

[Table("employees")]
[Index(nameof(FirstName), nameof(LastName))]
[Index(nameof(PhoneNumber), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
public class EmployeeDb : PersonDb
{
    [Key]
    [Column("employee_id", Order = 0)]
    public Guid EmployeeId { get; set; }
    
    [Required]
    [DataType(DataType.PhoneNumber)]
    [Column("phone_number", Order = 6)]
    public string PhoneNumber { get; set; }
    
    [Required]
    [DataType(DataType.EmailAddress)]
    [Column("email", Order = 7)]
    public string Email { get; set; }
    
    [Required]
    [StringLength(1024)]
    [Column("address", Order = 8)]
    public string Address { get; set; }
    
    [Required]
    [Column("contract", Order = 9)]
    public string Contract { get; set; }
    
    [Required]
    [Column("salary", Order = 10)]
    [Precision(14,2)]
    public decimal Salary { get; set; }
    
    [Column("is_owner", Order = 11)]
    public bool IsOwner { get; set; }
}