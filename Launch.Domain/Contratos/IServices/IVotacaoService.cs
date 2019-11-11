using Launch.Domain.Entidades;

namespace Launch.Domain.Contratos.IServices
{
    public interface IVotacaoService : IServiceBase<Votacao>
    {
        int BuscarTotalVotosDiario(int candidatoId);
        VotacaoDiaria BuscarReiDoAlmoco();
    }
}
