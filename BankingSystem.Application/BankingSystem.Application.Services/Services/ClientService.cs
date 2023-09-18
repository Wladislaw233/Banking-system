using AutoMapper;
using BankingSystem.Application.Services.Dto;
using BankingSystem.Application.Services.Interfaces;
using BankingSystem.ContextDomain.Entities;
using BankingSystem.ContextDomain.Exceptions;
using BankingSystem.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Application.Services.Services;

public class ClientService : IClientService
{
    private readonly BankingSystemDbContext _bankingSystemDbContext;
    private readonly IMapper _mapper;
    private Currency? _defaultCurrency;

    public ClientService(BankingSystemDbContext bankingSystemDbContext, IMapper mapper)
    {
        _bankingSystemDbContext = bankingSystemDbContext;
        _mapper = mapper;
    }

    public async Task<Guid> AddClientAsync(ClientDto clientDto)
    {
        var client = _mapper.Map<Client>(clientDto);

        if (await ClientContainsInDatabase(client))
            throw new ArgumentException("Client with such data already exists in the banking system.",
                nameof(clientDto));

        _defaultCurrency ??= await GetDefaultCurrencyAsync();

        var defaultAccount = CreateAccount(client, _defaultCurrency);
        
        await _bankingSystemDbContext.Clients.AddAsync(client);
        await _bankingSystemDbContext.Accounts.AddAsync(defaultAccount);

        await _bankingSystemDbContext.SaveChangesAsync();

        return client.ClientId;
    }

    public async Task UpdateClientAsync(Guid clientId, ClientDto newClientDto)
    {
        var client = await GetClientByIdAsync(clientId);

        var clientTuple = new Tuple<ClientDto, Guid>(newClientDto, clientId);
        
        _mapper.Map(clientTuple, client);
        
        await _bankingSystemDbContext.SaveChangesAsync();
    }

    public async Task DeleteClientAsync(Guid clientId)
    {
        var bankClient = await GetClientByIdAsync(clientId);

        var clientAccounts = await _bankingSystemDbContext.Accounts.Where(account => account.ClientId.Equals(clientId))
            .ToListAsync();

        _bankingSystemDbContext.Accounts.RemoveRange(clientAccounts);
        _bankingSystemDbContext.Clients.Remove(bankClient);

        await _bankingSystemDbContext.SaveChangesAsync();
    }

    public async Task<ClientDto> GetClientAsync(Guid clientId)
    {
        var client = await GetClientByIdAsync(clientId);
        return _mapper.Map<ClientDto>(client);
    }
    private async Task<Client> GetClientByIdAsync(Guid clientId)
    {
        var client =
            await _bankingSystemDbContext.Clients.SingleOrDefaultAsync(client => client.ClientId.Equals(clientId));

        if (client == null)
            throw new ValueNotFoundException($"The client with identifier {clientId} does not exist!");

        return client;
    }

    private async Task<Currency> GetDefaultCurrencyAsync()
    {
        var currency =
            await _bankingSystemDbContext.Currencies.SingleOrDefaultAsync(currency => currency.Code == "USD");

        if (currency != null) return currency;
        
        currency = new Currency
        {
            Code = "USD",
            Name = "United States dollar",
            ExchangeRate = new decimal(1),
            CurrencyId = Guid.NewGuid()
        };
        await _bankingSystemDbContext.Currencies.AddAsync(currency);
        await _bankingSystemDbContext.SaveChangesAsync();

        return currency;
    }

    private static Account CreateAccount(Client client, Currency currency, decimal amount = 0)
    {
        return new Account
        {
            AccountId = Guid.NewGuid(),
            ClientId = client.ClientId,
            Client = client,
            Currency = currency,
            CurrencyId = currency.CurrencyId,
            Amount = amount
        };
    }
    
    private async Task<bool> ClientContainsInDatabase(Client client)
    {
        return await _bankingSystemDbContext.Clients.AnyAsync(c => c.FirstName == client.FirstName 
                                                                   && c.LastName == client.LastName 
                                                                   && c.PhoneNumber == client.PhoneNumber
                                                                   && c.Address == client.Address
                                                                   && c.Email == client.Email
                                                                   && c.DateOfBirth.Equals(client.DateOfBirth));
    }
}