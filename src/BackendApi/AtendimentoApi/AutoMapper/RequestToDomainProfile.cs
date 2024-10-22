using AtendimentoApi.Dtos.Request;
using AtendimentoDomain.Entities;
using AutoMapper;

namespace AtendimentoApi.AutoMapper
{
    public class RequestToDomainProfile : Profile
    {
        public RequestToDomainProfile()
        {
            CreateMap<AtendimentoRequest, Atendimento>(MemberList.Destination);
            CreateMap<UserRequest, User>(MemberList.Destination);
            CreateMap<AuthRequest, Auth>(MemberList.Destination);
            CreateMap<GroupRequest, Group>(MemberList.Destination);

            CreateMap<AuthRequest, User>(MemberList.Destination);
        }
    }
}
