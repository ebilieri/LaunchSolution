using System;
using System.Collections.Generic;
using System.Text;

namespace Launch.Domain.Entidades
{
    public class Votacao : Entidade
    {
        public int Id { get; set; }
        public int CandidatoId { get; set; }   
        public DateTime DataVotacao { get; set; }

        // Virtual
        public virtual Candidato Candidato { get; set; }

        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
