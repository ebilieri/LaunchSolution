using Launch.Domain.Contratos.IRepositorio;
using Launch.Domain.Entidades;
using Launch.Repository.Contexto;
using System.Linq;

namespace Launch.Repository.Repositorios
{
    public class VotacaoSemanalRepositorio : BaseRepositorio<VotacaoSemanal>, IVotacaoSemanalRepositorio
    {
        protected readonly LaunchContexto _launchContexto;

        public VotacaoSemanalRepositorio(LaunchContexto launchContexto) : base(launchContexto)
        {
            _launchContexto = launchContexto;
        }

        public VotacaoSemanal BuscarVotoCandidato(int candidatoId, int numeroSemana)
        {
            return _launchContexto.Set<VotacaoSemanal>()
                .Where(x => x.CandidatoId == candidatoId && x.NumeroSemana == numeroSemana)
                .FirstOrDefault();
        }
    }
}
