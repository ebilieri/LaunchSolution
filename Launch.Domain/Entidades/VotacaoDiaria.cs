using System;

namespace Launch.Domain.Entidades
{
    public class VotacaoDiaria : Entidade
    {
        public int Id { get; set; }
        public int CandidatoId { get; set; }     
        public DateTime DataVotacao { get; set; }
        public int TotalVotosDia { get; set; }

        // Vitual
        public virtual Candidato Candidato { get; set; }

        public override void Validate()
        {

            throw new NotImplementedException();
        }
    }
}
