namespace SupermarketChain.Data
{
    using System;
    using System.Collections.Generic;
    using SupermarketChain.Data.Contracts;
    using SupermarketChain.Data.Repositories;
    using SupermarketChain.Data.Repositories.Contracts;
    using SupermarketChain.Models;
    using SupermarketsChain.Data.Repositories;
    using SupermarketsChain.Data.Repositories.Contracts;

    public abstract class SupermarketsChainData : ISupermarketChainData
    {
        private ISupermarketsChainDbContext context;

        private readonly IDictionary<Type, object> repositories;

        public SupermarketsChainData(ISupermarketsChainDbContext supermarketsChainDbContext)
        {
            this.context = supermarketsChainDbContext;
            this.repositories = new Dictionary<Type, object>();
        }

        public ISupermarketsChainDbContext Context
        {
            get
            {
                return this.context;
            }
        }

        public IGenericRepository<Expense> Expenses
        {
            get { return this.GetRepository<Expense>(); }
        }

        public IGenericRepository<Measure> Measures
        {
            get
            {
                return this.GetRepository<Measure>();
            }
        }

        public IGenericRepository<Product> Products
        {
            get
            {
                return this.GetRepository<Product>();
            }
        }

        public IGenericRepository<Vendor> Vendors
        {
            get
            {
                return this.GetRepository<Vendor>();
            }
        }

        public IGenericRepository<Supermarket> Supermarkets
        {
            get { return this.GetRepository<Supermarket>(); }
        }

        public ISalesRepository Sales
        {
            get { return (ISalesRepository)this.GetRepository<Sale>(); }
        }

        public virtual int SaveChanges()
        {
            return this.Context.SaveChanges();
        }

        public virtual void Dispose()
        {
            this.Context.Dispose();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                if (typeof(Sale).IsAssignableFrom(typeof(T)))
                {
                    type = typeof(SalesRepository);
                }

                var newRepo = Activator.CreateInstance(type, this.context);
                this.repositories.Add(typeof(T), newRepo);
            }

            return (IGenericRepository<T>)this.repositories[typeof(T)];
        }
    }
}
