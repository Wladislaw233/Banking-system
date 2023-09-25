using AutoMapper;
using BankingSystem.Application.Services.Dto;
using BankingSystem.Application.Services.Interfaces;
using BankingSystem.ContextDomain.Entities;

namespace BankingSystem.Application.Services.Services;

public class ClientService : IClientService
{
    private readonly IMapper _mapper;
    private readonly IClientRepository _clientRepository;

    public ClientService(IMapper mapper, IClientRepository clientRepository)
    {
        _mapper = mapper;
        _clientRepository = clientRepository;
    }

    public async Task<Guid> AddClientAsync(ClientDto clientDto)
    {
        var client = _mapper.Map<Client>(clientDto);

        await _clientRepository.AddClientAsync(client);

        return client.ClientId;
    }

    public async Task UpdateClientAsync(Guid clientId, ClientDto newClientDto)
    {
        var client = new Client();

        var clientTuple = new Tuple<ClientDto, Guid>(newClientDto, clientId);
        
        _mapper.Map(clientTuple, client);

        await _clientRepository.UpdateClientAsync(client);
    }

    public async Task DeleteClientAsync(Guid clientId)
    {

        await _clientRepository.DeleteClientAsync(clientId);
    }

    public async Task<ClientDto> GetClientAsync(Guid clientId)
    {
        var client = await _clientRepository.GetClientAsync(clientId);
        return _mapper.Map<ClientDto>(client);
    }
}