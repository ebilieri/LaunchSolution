using Launch.Domain.Contratos;
using Launch.Domain.Entidades;
using Launch.Repository.Contexto;

namespace Launch.Repository.Repositorios
{
    public class VotacaoSemanalRepositorio : BaseRepositorio<VotacaoSemanal>, IVotacaoSemanalRepositorio
    {
        public VotacaoSemanalRepositorio(LaunchContexto launchContexto) : base(launchContexto)
        {
        }
    }
}
