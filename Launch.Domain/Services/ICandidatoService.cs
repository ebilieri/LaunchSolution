using Launch.Domain.Entidades;

namespace Launch.Domain.Services
{
    public interface ICandidatoService : IServiceBase<Candidato>
    {
        Candidato BuscarPorEmail(string email);
    }
}
