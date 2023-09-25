using AutoMapper;
using BankingSystem.ContextDomain.Entities;
using BankingSystem.Infrastructure.Data.Models;

namespace BankingSystem.Infrastructure.Repositories.Mapping;

public class MappingClientProfile : Profile
{
    public MappingClientProfile()
    {
        CreateMap<ClientDb, Client>().ReverseMap();
        CreateMap<Client, ClientDb>();
    }
}