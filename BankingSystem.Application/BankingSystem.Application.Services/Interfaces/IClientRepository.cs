using BankingSystem.ContextDomain.Entities;

namespace BankingSystem.Application.Services.Interfaces;

public interface IClientRepository
{
    Task AddClientAsync(Client client);

    Task UpdateClientAsync(Client client);

    Task DeleteClientAsync(Guid clientId);

    Task<Client> GetClientAsync(Guid clientId);
}