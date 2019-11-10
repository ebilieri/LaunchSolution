using Launch.Domain.Contratos;
using Launch.Domain.Entidades;
using Launch.Repository.Contexto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Launch.Repository.Repositorios
{
    public class CandidatoRepositorio : BaseRepositorio<Candidato>, ICandidatoRepositorio
    {
        public CandidatoRepositorio(LaunchContexto launchContexto) : base(launchContexto)
        {
        }
    }
}
