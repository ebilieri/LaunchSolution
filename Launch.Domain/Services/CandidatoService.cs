using Launch.Domain.Contratos.IRepositorio;
using Launch.Domain.Contratos.IServices;
using Launch.Domain.Entidades;

namespace Launch.Domain.Services
{
    public class CandidatoService : ServiceBase<Candidato>, ICandidatoService
    {
        private readonly ICandidatoRepositorio _candidatoRepositorio;
        public CandidatoService(ICandidatoRepositorio candidatoRepositorio) : base(candidatoRepositorio)
        {
            _candidatoRepositorio = candidatoRepositorio;
        }

        public override void Adicionar(Candidato entity)
        {
            entity.Email = entity.Email.ToLower();

            if (BuscarPorEmail(entity.Email) == null)
            {
                base.Adicionar(entity);
            }
            else
            {
                entity.AdicionarMensagem("Email já está sendo utilizado");
            }
        }

        public Candidato BuscarPorEmail(string email)
        {            
            return _candidatoRepositorio.BusacarPorEmail(email);
        }
    }
}
