using AutoMapper;
using BankingSystem.ContextDomain.Entities;
using BankingSystem.Infrastructure.Data.Models;

namespace BankingSystem.Infrastructure.Repositories.Mapping;

public class MappingAccountProfile : Profile
{
    public MappingAccountProfile()
    {
        CreateMap<AccountDb, Account>();
        CreateMap<Account, AccountDb>();
    }
}