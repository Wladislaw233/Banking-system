using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Infrastructure.Data.Models;

[Table("accounts")]
public class AccountDb
{
    [Key]
    [Column("account_id", Order = 0)]
    public Guid AccountId { get; set; }
    
    [Required]
    [Column("amount", Order = 1)]
    [Precision(14,2)]
    public decimal Amount { get; set; }
    
    [ForeignKey("Client")]
    public Guid ClientId { get; set; }
    
    [ForeignKey("Currency")]
    public Guid CurrencyId { get; set; }
    
    public virtual ClientDb? Client { get; set; }
    
    public virtual CurrencyDb? Currency { get; set; }
}