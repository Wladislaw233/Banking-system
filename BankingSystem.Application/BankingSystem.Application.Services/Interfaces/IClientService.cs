using BankingSystem.Application.Services.Dto;

namespace BankingSystem.Application.Services.Interfaces;

public interface IClientService
{
    public Task<Guid> AddClientAsync(ClientDto clientDto);

    public Task UpdateClientAsync(Guid clientId, ClientDto newClientDto);

    public Task DeleteClientAsync(Guid client);

    public Task<ClientDto> GetClientAsync(Guid clientId);
}