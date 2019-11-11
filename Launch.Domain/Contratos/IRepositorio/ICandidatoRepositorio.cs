using Launch.Domain.Entidades;

namespace Launch.Domain.Contratos.IRepositorio
{
    public interface ICandidatoRepositorio : IBaseRepositorio<Candidato>
    {
        Candidato BusacarPorEmail(string email);
    }
}
