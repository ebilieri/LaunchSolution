using System;
using System.Linq;
using Launch.Domain.Contratos.IRepositorio;
using Launch.Domain.Entidades;
using Launch.Repository.Contexto;

namespace Launch.Repository.Repositorios
{
    public class VotacaoDiariaRepositorio : BaseRepositorio<VotacaoDiaria>, IVotacaoDiariaRepositorio
    {
        protected readonly LaunchContexto _launchContexto;
        public VotacaoDiariaRepositorio(LaunchContexto launchContexto) : base(launchContexto)
        {
            _launchContexto = launchContexto;
        }

        public VotacaoDiaria BuscarReidoAlmoco()
        {
            return _launchContexto.Set<VotacaoDiaria>()
                .Where(x => x.DataVotacao == DateTime.Now.Date)
                .OrderByDescending(x => x.TotalVotosDia)
                .FirstOrDefault();
        }

        public VotacaoDiaria BuscarVotoCandidato(int candidatoId, DateTime dataVotacao)
        {
            return _launchContexto.Set<VotacaoDiaria>()
                .Where(x => x.CandidatoId == candidatoId && x.DataVotacao == dataVotacao)
                .FirstOrDefault();
        }
    }
}
