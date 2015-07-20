namespace SupermarketChain.Data.Contracts
{
    using Models;
    using Repositories.Contracts;

    public interface ISupermarketChainData
    {
        ISupermarketsChainDbContext Context { get; }

        IGenericRepository<Measure> Measures { get; }

        IGenericRepository<Product> Products { get; }

        IGenericRepository<Vendor> Vendors { get; }

        int SaveChanges();
    }
}
