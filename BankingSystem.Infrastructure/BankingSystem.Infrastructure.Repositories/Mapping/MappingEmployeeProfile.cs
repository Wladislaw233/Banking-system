using AutoMapper;
using BankingSystem.ContextDomain.Entities;
using BankingSystem.Infrastructure.Data.Models;

namespace BankingSystem.Infrastructure.Repositories.Mapping;

public class MappingEmployeeProfile : Profile
{
    public MappingEmployeeProfile()
    {
        CreateMap<EmployeeDb, Employee>();
        CreateMap<Employee, EmployeeDb>();
    }
}