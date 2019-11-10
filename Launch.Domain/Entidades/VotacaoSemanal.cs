using System;
using System.Collections.Generic;
using System.Text;

namespace Launch.Domain.Entidades
{
    public class VotacaoSemanal : Entidade
    {
        public int Id { get; set; }
        public int CandidatoId { get; set; }        
        public int NumeroSemana { get; set; }
        public int TotalVotosSemana { get; set; }

        // Virtual
        public virtual Candidato Candidato { get; set; }

        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
