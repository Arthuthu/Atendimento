using AtendimentoApi.Dtos.Request;
using AtendimentoApi.Dtos.Response;
using AtendimentoDomain.Entities;
using AutoMapper;

namespace AtendimentoApi.AutoMapper
{
    public class DomainToResponseProfile : Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<Atendimento, AtendimentoResponse>(MemberList.Destination);
            CreateMap<User, UserResponse>(MemberList.Destination);
            CreateMap<Auth, AuthResponse>(MemberList.Destination);

            CreateMap<Auth, UserResponse>(MemberList.Destination);
        }
    }
}
