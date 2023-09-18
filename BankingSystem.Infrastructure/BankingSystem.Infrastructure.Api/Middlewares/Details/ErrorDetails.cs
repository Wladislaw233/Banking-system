using System.Text.Json;

namespace BankingSystem.Infrastructure.Api.Middlewares.Details;

/// <summary>
///     Exception details.
/// </summary>
public class ErrorDetails
{
    /// <summary>
    ///     Status code.
    /// </summary>
    public int StatusCode { get; set; }
    
    /// <summary>
    ///     Error message.
    /// </summary>
    public string ErrorMessage { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}