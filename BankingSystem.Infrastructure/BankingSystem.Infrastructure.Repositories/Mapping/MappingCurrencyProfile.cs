using AutoMapper;
using BankingSystem.ContextDomain.Entities;
using BankingSystem.Infrastructure.Data.Models;

namespace BankingSystem.Infrastructure.Repositories.Mapping;

public class MappingCurrencyProfile : Profile
{
    public MappingCurrencyProfile()
    {
        CreateMap<CurrencyDb, Currency>();
        CreateMap<Currency, CurrencyDb>();
    }
}