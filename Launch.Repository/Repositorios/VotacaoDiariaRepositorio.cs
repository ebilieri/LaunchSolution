using Launch.Domain.Contratos;
using Launch.Domain.Entidades;
using Launch.Repository.Contexto;

namespace Launch.Repository.Repositorios
{
    public class VotacaoDiariaRepositorio : BaseRepositorio<VotacaoDiaria>, IVotacaoDiariaRepositorio
    {
        public VotacaoDiariaRepositorio(LaunchContexto launchContexto) : base(launchContexto)
        {
        }
    }
}
