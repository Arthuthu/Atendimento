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
        }
    }
}
