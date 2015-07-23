namespace SupermarketsChain.Data.Repositories
{
    using System;
    using System.Linq;
    using SupermarketChain.Data.Contracts;
    using SupermarketChain.Data.Repositories;
    using SupermarketChain.Models;
    using SupermarketsChain.Data.Repositories.Contracts;

    public class SalesRepository : GenericRepository<Sale>, ISalesRepository
    {
        public SalesRepository(ISupermarketsChainDbContext supermarketsChainDbContext)
            : base(supermarketsChainDbContext)
        {
        }

        public IQueryable<Sale> GetAllByDateInterval(DateTime startDate, DateTime endDate)
        {
            return this.Context.Sales.Where(x => x.SoldDate >= startDate && x.SoldDate <= endDate);
        }
    }
}
