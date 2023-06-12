using Arpti.Domain.Interface.Repository;
using Arpti.Domain.Interface.Service;

namespace Arpti.Domain.Service
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual TEntity Adicionar(TEntity obj)
        {
            return _repository.Adicionar(obj);
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return _repository.ObterPorId(id);
        }

        public virtual IQueryable<TEntity> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        public virtual void Atualizar(TEntity obj)
        {
            _repository.Atualizar(obj);
        }

        public virtual void Remover(Guid id)
        {
            _repository.Remover(id);
        }

        public void Dispose()
        {
            _repository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}