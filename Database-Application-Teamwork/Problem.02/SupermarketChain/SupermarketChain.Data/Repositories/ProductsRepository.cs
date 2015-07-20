namespace SupermarketChain.Data.Repositories
{
    using Contracts;
    using Data.Contracts;
    using Models;

    class ProductsRepository : GenericRepository<Product>, IGenericRepository<Product>
    {
        public ProductsRepository(ISupermarketsChainDbContext context) 
            : base(context)
        {
        }
    }
}
