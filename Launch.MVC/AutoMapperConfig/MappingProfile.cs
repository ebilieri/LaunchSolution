using Launch.Domain.Entidades;
using Launch.MVC.Models;

namespace Launch.MVC.AutoMapperConfig
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<CandidatoModel, Candidato>()
                .ReverseMap()
             // .ForMember(x => x.VotosCandidato, op => op.Ignore())
             .ForPath(x => x.VotosDiario, opt => opt.Ignore());
            // .ForMember(x => x.VotosDiarioCandidato, opt => opt.Ignore())
            //.ForMember(x => x.VotosSemanalCandidato, opt => opt.Ignore());
        }
    }
}
