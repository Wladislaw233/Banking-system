using BankingSystem.Application.Services.Dto;
using BankingSystem.ContextDomain.Entities;

namespace BankingSystem.Application.Services.Interfaces;

public interface IClientService
{
    public Task<Client> AddClientAsync(ClientDto clientDto);

    public Task<Client> UpdateClientAsync(Guid clientId, ClientDto newClientDto);

    public Task DeleteClientAsync(Guid client);

    public Task<Client> GetClientByIdAsync(Guid clientId);
}