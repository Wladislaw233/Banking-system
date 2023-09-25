using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Infrastructure.Data.Models;

[Table("clients")]
[Index(nameof(FirstName), nameof(LastName))]
[Index(nameof(PhoneNumber), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
public class ClientDb : PersonDb
{
    [Key]
    [Column("client_id", Order = 0)]
    public Guid ClientId { get; set; }
    
    [Required]
    [DataType(DataType.PhoneNumber)]
    [Column("phone_number", Order = 6)]
    public string PhoneNumber { get; set; }
    
    [Required]
    [DataType(DataType.EmailAddress)]
    [Column("email", Order = 7)]
    public string Email { get; set; }
    
    [Required]
    [Column("address", Order = 8)]
    public string Address { get; set; }
    
    public ICollection<AccountDb> ClientAccounts { get; set; }
}