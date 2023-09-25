using BankingSystem.Application.Services.Interfaces;

namespace BankingSystem.Infrastructure.Api;

public class MyHostedService : IHostedService
{
    private readonly IClientService _clientService;

    public MyHostedService(IClientService clientService)
    {
        _clientService = clientService;
    }
    
    public Task StartAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}