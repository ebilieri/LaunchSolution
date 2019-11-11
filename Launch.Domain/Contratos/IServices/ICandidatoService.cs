using Launch.Domain.Entidades;

namespace Launch.Domain.Contratos.IServices
{
    public interface ICandidatoService : IServiceBase<Candidato>
    {
        Candidato BuscarPorEmail(string email);
    }
}
