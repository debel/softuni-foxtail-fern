namespace SupermarketChain.Data.Contracts
{
    using Models;
    using Repositories.Contracts;
    using SupermarketsChain.Data.Repositories.Contracts;

    public interface ISupermarketChainData
    {
        ISupermarketsChainDbContext Context { get; }

        IGenericRepository<Expense> Expenses { get; }

        IGenericRepository<Measure> Measures { get; }

        IGenericRepository<Product> Products { get; }

        IGenericRepository<Vendor> Vendors { get; }

        IGenericRepository<Supermarket> Supermarkets { get; }

        ISalesRepository Sales { get; }

        int SaveChanges();
    }
}
