﻿using Launch.Domain.Entidades;

namespace Launch.Domain.Contratos
{
    public interface ICandidatoRepositorio : IBaseRepositorio<Candidato>
    {
        Candidato BusacarPorEmail(string email);
    }
}
