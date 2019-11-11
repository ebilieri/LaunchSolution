using System;
using Launch.Domain.Entidades;

namespace Launch.Domain.Contratos.IRepositorio
{
    public interface IVotacaoDiariaRepositorio : IBaseRepositorio<VotacaoDiaria>
    {
        VotacaoDiaria BuscarVotoCandidato(int candidatoId, DateTime date);
        VotacaoDiaria BuscarReidoAlmoco();
    }
}
