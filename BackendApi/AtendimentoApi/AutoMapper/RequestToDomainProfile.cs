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
        }
    }
}
