namespace SupermarketChain.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Data;

    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> All();

        IQueryable<T> SearchFor(Expression<Func<T, bool>> conditions);

        T Add(T entity);

        T Update(T entity);

        T Delete(T entity);

        void Detach(T entity);
    }
}
