using AutoMapper;
using BankingSystem.Application.Services.Interfaces;
using BankingSystem.ContextDomain.Entities;
using BankingSystem.ContextDomain.Exceptions;
using BankingSystem.Infrastructure.Data.Context;
using BankingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Infrastructure.Repositories.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly IMapper _mapper;
    private readonly BankingSystemDbContext _bankingSystemDbContext;
    private CurrencyDb? _defaultCurrency;

    public ClientRepository(IMapper mapper, BankingSystemDbContext bankingSystemDbContext)
    {
        _mapper = mapper;
        _bankingSystemDbContext = bankingSystemDbContext;
    }

    public async Task AddClientAsync(Client client)
    {
        if (await ClientContainsInDatabase(client))
            throw new ArgumentException("Client with such data already exists in the banking system.",
                nameof(client));
        
        var clientDb = _mapper.Map<ClientDb>(client);

        _defaultCurrency ??= await GetDefaultCurrencyAsync();
        
        var defaultAccount = CreateAccount(clientDb, _defaultCurrency);
        
        await _bankingSystemDbContext.Clients.AddAsync(clientDb);

        await _bankingSystemDbContext.Accounts.AddAsync(defaultAccount);

        await _bankingSystemDbContext.SaveChangesAsync();
    }

    public async Task UpdateClientAsync(Client client)
    {
        var clientDb = _mapper.Map<ClientDb>(client);

        _bankingSystemDbContext.Clients.Update(clientDb);

        await _bankingSystemDbContext.SaveChangesAsync();
    }

    public async Task DeleteClientAsync(Guid clientId)
    {
        var bankClient = await GetClientByIdAsync(clientId);
        
        _bankingSystemDbContext.Accounts.RemoveRange(bankClient.ClientAccounts);
        
        _bankingSystemDbContext.Clients.Remove(bankClient);

        await _bankingSystemDbContext.SaveChangesAsync();
    }

    public async Task<Client> GetClientAsync(Guid clientId)
    {
        var clientDb = await GetClientByIdAsync(clientId);
        return _mapper.Map<Client>(clientDb);
    }

    private async Task<ClientDb> GetClientByIdAsync(Guid clientId)
    {
        var client =
            await _bankingSystemDbContext.Clients.SingleOrDefaultAsync(client => client.ClientId.Equals(clientId));

        if (client == null)
            throw new ValueNotFoundException($"The client with identifier {clientId} does not exist!");

        return client;
    }
    
    private async Task<CurrencyDb> GetDefaultCurrencyAsync()
    {
        var currency =
            await _bankingSystemDbContext.Currencies.SingleOrDefaultAsync(currency => currency.Code == "USD");

        if (currency != null) return currency;
        
        currency = new CurrencyDb
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
    
    private static AccountDb CreateAccount(ClientDb client, CurrencyDb currency, decimal amount = 0)
    {
        return new AccountDb
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