namespace SupermarketChain.Data
{
    using System;
    using System.Collections.Generic;
    using SupermarketChain.Data.Contracts;
    using SupermarketChain.Data.Repositories;
    using SupermarketChain.Data.Repositories.Contracts;
    using SupermarketChain.Models;

    public class SupermarketsChainData : ISupermarketChainData
    {
        private ISupermarketsChainDbContext context;

        private readonly IDictionary<Type, object> repositories;

        public SupermarketsChainData()
            : this(new SupermarketsChainDbContext())
        {
        }

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

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                //if (typeof(Sale).IsAssignableFrom(typeof(T)))
                //{
                //    type = typeof(SalesRepository);
                //}

                var newRepo = Activator.CreateInstance(type, this.context);
                this.repositories.Add(typeof(T), newRepo);
            }

            return (IGenericRepository<T>)this.repositories[typeof(T)];
        }
    }
}
