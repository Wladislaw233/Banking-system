using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Infrastructure.Data.Models;

[Table("currencies")]
[Index(nameof(Code), IsUnique = true)]
public class CurrencyDb
{
    [Key]
    [Column("currency_id", Order = 0)]
    public Guid CurrencyId { get; set; }
    
    [Required]
    [StringLength(3)]
    [Column("code", Order = 1)]
    public string Code { get; set; }
    
    [Required]
    [Column("name", Order = 2)]
    public string Name { get; set; }
    
    [Required]
    [Column("exchange_rate", Order = 3)]
    [Precision(14,2)]
    public decimal ExchangeRate { get; set; }
}