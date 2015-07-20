namespace SupermarketChain.Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;
    using Data.Contracts;
    using SupermarketChain.Data.Repositories.Contracts;

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private IDbSet<T> set;

        public GenericRepository(ISupermarketsChainDbContext context)
        {
            this.Context = context;
            this.set = context.Set<T>();
        }
        protected ISupermarketsChainDbContext Context { get; set; }

        public IQueryable<T> All()
        {
            return this.set.AsQueryable();
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> conditions)
        {
            return this.All().Where(conditions);
        }

        public T Add(T entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Added;
            return entity;
        }

        public T Update(T entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Modified;
            return entity;
        }

        public T Delete(T entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Deleted;
            return entity;
        }

        public void Detach(T entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Detached;
        }

        private DbEntityEntry AttachIfDetached(T entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            return entry;
        }
    }
}
