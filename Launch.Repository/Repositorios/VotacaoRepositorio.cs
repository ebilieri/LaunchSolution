using Launch.Domain.Contratos;
using Launch.Domain.Entidades;
using Launch.Repository.Contexto;

namespace Launch.Repository.Repositorios
{
    public class VotacaoRepositorio : BaseRepositorio<Votacao>, IVotacaoRepositorio
    {
        public VotacaoRepositorio(LaunchContexto launchContexto) : base(launchContexto)
        {
        }
    }
}
