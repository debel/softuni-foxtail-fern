namespace SupermarketChain.Data.Contracts
{
    using System;
    using System.Linq;
    using SupermarketChain.Models;

    public interface ISalesRepository : IGenericRepository<Sale>
    {
        IQueryable<Sale> GetAllByDateInterval(DateTime startDate, DateTime endDate);
    }
}
