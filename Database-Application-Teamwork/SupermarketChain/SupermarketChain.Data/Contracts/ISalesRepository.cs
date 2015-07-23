namespace SupermarketChain.Data.Contracts
{
    using System;
    using System.Linq;
    using Models;

    public interface ISalesRepository : IGenericRepository<Sale>
    {
        IQueryable<Sale> GetAllByDateInterval(DateTime startDate, DateTime endDate);
    }
}
