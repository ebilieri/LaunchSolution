using Launch.Domain.Entidades;

namespace Launch.Domain.Contratos.IRepositorio
{
    public interface IVotacaoSemanalRepositorio : IBaseRepositorio<VotacaoSemanal>
    {
        VotacaoSemanal BuscarVotoCandidato(int candidatoId, int numeroSemana);
    }
}
