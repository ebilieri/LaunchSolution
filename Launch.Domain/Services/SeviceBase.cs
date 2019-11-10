using Launch.Domain.Contratos;
using System.Collections.Generic;

namespace Launch.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IBaseRepositorio<TEntity> _repository;

        public ServiceBase(IBaseRepositorio<TEntity> repository)
        {
            _repository = repository;
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public virtual void Adicionar(TEntity entity)
        {
            _repository.Adicionar(entity);
        }

        public void Atualizar(TEntity entity)
        {
            _repository.Atualizar(entity);
        }

        public TEntity ObterPorId(int id)
        {
           return _repository.ObterPorId(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return _repository.ObterTodos();
        }
    }
}
