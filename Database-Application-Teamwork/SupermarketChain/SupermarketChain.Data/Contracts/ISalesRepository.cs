namespace SupermarketsChain.Data.Repositories.Contracts
{
    using System;
    using System.Linq;
    using SupermarketChain.Data.Repositories.Contracts;
    using SupermarketChain.Models;

    public interface ISalesRepository : IGenericRepository<Sale>
    {
        IQueryable<Sale> GetAllByDateInterval(DateTime startDate, DateTime endDate);
    }
}
