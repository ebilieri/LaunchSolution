using Launch.Domain.Entidades;
using Launch.MVC.Models;

namespace Launch.MVC.AutoMapperConfig
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<CandidatoModel, Candidato>();
               // .ForSourceMember(x => x.VotosCandidato, opt => opt.Ignore())
               // .ForSourceMember(x => x.VotosDiarioCandidato, opt => opt.Ignore())
                //.ForSourceMember(x => x.VotosSemanalCandidato, opt => opt.Ignore());
        }
    }
}
