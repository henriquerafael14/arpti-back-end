using Arpti.Domain.Interface.Repository;
using Arpti.Infra.Data.Context;

namespace Arpti.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected ArptiDbContext Db;
        protected Microsoft.EntityFrameworkCore.DbSet<TEntity> DbSet;

        public Repository(ArptiDbContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual TEntity Adicionar(TEntity obj)
        {
            var objreturn = DbSet.Add(obj);
            return objreturn.Entity;
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> ObterTodos()
        {
            return DbSet;
        }

        public virtual void Atualizar(TEntity obj)
        {
            Db.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            DbSet.Update(obj);
        }

        public virtual void Remover(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
