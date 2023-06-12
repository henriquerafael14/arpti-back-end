namespace Arpti.Domain.Interface.Service
{
    public interface IService<TEntity> : IDisposable where TEntity : class
    {
        TEntity Adicionar(TEntity obj);
        TEntity ObterPorId(Guid id);
        IQueryable<TEntity> ObterTodos();
        void Atualizar(TEntity obj);
        void Remover(Guid id);
    }
}
