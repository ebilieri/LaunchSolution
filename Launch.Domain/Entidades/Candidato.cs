using System;
using System.Collections.Generic;
using System.Text;

namespace Launch.Domain.Entidades
{
    public class Candidato : Entidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string ImagemUrl { get; set; }
        public string Senha { get; set; }
        public string ConfirmaSenha { get; set; }

        public virtual ICollection<Votacao> VotosCandidato  { get; set; }
        public virtual ICollection<VotacaoDiaria> VotosDiarioCandidato { get; set; }
        public virtual ICollection<VotacaoSemanal> VotosSemanalCandidato { get; set; }

        public override void Validate()
        {
            LimparMensagemValidacao();

            if (string.IsNullOrEmpty(Nome))
                AdicionarMensagem("Nome é de preenchimento Obrigatorio");

            if (string.IsNullOrEmpty(Email))
                AdicionarMensagem("Email é de preenchimento Obrigatorio");

            if (string.IsNullOrEmpty(Senha))
                AdicionarMensagem("Senha é de preenchimento Obrigatorio");
        }
    }
}
