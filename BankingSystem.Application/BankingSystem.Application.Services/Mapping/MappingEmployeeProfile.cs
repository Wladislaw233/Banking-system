using AutoMapper;
using BankingSystem.ContextDomain.Entities;
using BankingSystemServices.Models.DTO;

namespace BankingSystem.Application.Services.Mapping;

public class MappingEmployeeProfile : Profile
{
    public MappingEmployeeProfile()
    {
        CreateMap<EmployeeDto, Employee>()
            .ForMember(dst => dst.EmployeeId, opt => opt.MapFrom(src => Guid.NewGuid()));

        CreateMap<Tuple<EmployeeDto, Guid>, Employee>()
            .ForMember(dst => dst.EmployeeId, opt => opt.MapFrom(src => src.Item2))
            .ForMember(dst => dst.FirstName, opt => opt.MapFrom(src => src.Item1.FirstName))
            .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.Item1.LastName))
            .ForMember(dst => dst.DateOfBirth, opt => opt.MapFrom(src => src.Item1.DateOfBirth))
            .ForMember(dst => dst.Age, opt => opt.MapFrom(src => src.Item1.Age))
            .ForMember(dst => dst.Bonus, opt => opt.MapFrom(src => src.Item1.Bonus))
            .ForMember(dst => dst.Address, opt => opt.MapFrom(src => src.Item1.Address))
            .ForMember(dst => dst.PhoneNumber, opt => opt.MapFrom(src => src.Item1.PhoneNumber))
            .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Item1.Email))
            .ForMember(dst => dst.Salary, opt => opt.MapFrom(src => src.Item1.Salary))
            .ForMember(dst => dst.Contract, opt => opt.MapFrom(src => src.Item1.Contract))
            .ForMember(dst => dst.IsOwner, opt => opt.MapFrom(src => src.Item1.IsOwner));
        
        CreateMap<Employee, EmployeeDto>();
    }
}