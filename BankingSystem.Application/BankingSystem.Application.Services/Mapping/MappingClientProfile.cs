using AutoMapper;
using BankingSystem.Application.Services.Dto;
using BankingSystem.ContextDomain.Entities;

namespace BankingSystem.Application.Services.Mapping;

public class MappingClientProfile : Profile
{
    public MappingClientProfile()
    {
        CreateMap<ClientDto, Client>()
            .ForMember(dst => dst.ClientId
                , opt => opt.MapFrom(src => Guid.NewGuid()));

        CreateMap<Tuple<ClientDto, Guid>, Client>()
            .ForMember(dst => dst.ClientId, opt => opt.MapFrom(src => src.Item2))
            .ForMember(dst => dst.FirstName, opt => opt.MapFrom(src => src.Item1.FirstName))
            .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.Item1.LastName))
            .ForMember(dst => dst.DateOfBirth, opt => opt.MapFrom(src => src.Item1.DateOfBirth))
            .ForMember(dst => dst.Age, opt => opt.MapFrom(src => src.Item1.Age))
            .ForMember(dst => dst.Bonus, opt => opt.MapFrom(src => src.Item1.Bonus))
            .ForMember(dst => dst.Address, opt => opt.MapFrom(src => src.Item1.Address))
            .ForMember(dst => dst.PhoneNumber, opt => opt.MapFrom(src => src.Item1.PhoneNumber))
            .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Item1.Email));
        
        CreateMap<Client, ClientDto>();
    }
}