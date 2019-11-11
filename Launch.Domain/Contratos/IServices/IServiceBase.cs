using System;
using System.Collections.Generic;

namespace Launch.Domain.Contratos.IServices
{
    public interface IServiceBase<TEntity> : IDisposable where TEntity : class
    {
        void Adicionar(TEntity entity);
        TEntity ObterPorId(int id);
        IEnumerable<TEntity> ObterTodos();
        void Atualizar(TEntity entity);
    }
}
