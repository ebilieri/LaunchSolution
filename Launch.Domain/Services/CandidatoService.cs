using Launch.Domain.Contratos;
using Launch.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Launch.Domain.Services
{
    public class CandidatoService : ServiceBase<Candidato>, ICandidatoService
    {
        public CandidatoService(IBaseRepositorio<Candidato> repository) : base(repository)
        {
        }

        public override void Adicionar(Candidato entity)
        {
            base.Adicionar(entity);
        }
    }
}
