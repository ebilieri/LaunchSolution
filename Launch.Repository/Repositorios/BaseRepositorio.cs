using Launch.Domain.Contratos;
using Launch.Repository.Contexto;
using System.Collections.Generic;
using System.Linq;

namespace Launch.Repository.Repositorios
{
    public class BaseRepositorio<TEntity> : IBaseRepositorio<TEntity> where TEntity : class
    {
        private readonly LaunchContexto _launchContexto;

        public BaseRepositorio(LaunchContexto launchContexto)
        {
            _launchContexto = launchContexto;
        }

        public void Adicionar(TEntity entity)
        {
            _launchContexto.Set<TEntity>().Add(entity);
            _launchContexto.SaveChanges();
        }

        public void Atualizar(TEntity entity)
        {
            _launchContexto.Set<TEntity>().Update(entity);
            _launchContexto.SaveChanges();
        }

        public TEntity ObterPorId(int id)
        {
            return _launchContexto.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return _launchContexto.Set<TEntity>().ToList();
        }

        public void Dispose()
        {
            _launchContexto.Dispose();
        }

    }
}
