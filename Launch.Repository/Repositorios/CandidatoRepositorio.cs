﻿using Launch.Domain.Contratos.IRepositorio;
using Launch.Domain.Entidades;
using Launch.Repository.Contexto;
using System.Linq;

namespace Launch.Repository.Repositorios
{
    public class CandidatoRepositorio : BaseRepositorio<Candidato>, ICandidatoRepositorio
    {
        protected readonly LaunchContexto _launchContexto;
        public CandidatoRepositorio(LaunchContexto launchContexto) : base(launchContexto)
        {
            _launchContexto = launchContexto;
        }

        public Candidato BusacarPorEmail(string email)
        {
            return _launchContexto.Set<Candidato>()
                .Where(x => x.Email == email).FirstOrDefault();
        }
    }
}
