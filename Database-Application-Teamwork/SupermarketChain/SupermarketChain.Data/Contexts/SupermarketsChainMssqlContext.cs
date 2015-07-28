namespace SupermarketChain.Data.Contexts
{
    using System.Data.Entity;
    using Contracts;
    using Migrations;
    using Models;

    public class SupermarketsChainMssqlContext : DbContext, ISupermarketsChainDbContext
    {
        public SupermarketsChainMssqlContext()
            : base("SupermarketChainContext")
        {
            //var migrationStrategy = new MigrateDatabaseToLatestVersion<SupermarketsChainMssqlContext, MssqlConfiguration>();
            //Database.SetInitializer(migrationStrategy);
        }

        public IDbSet<Expense> Expenses { get; set; }

        public IDbSet<Measure> Measures { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Sale> Sales { get; set; }

        public IDbSet<Supermarket> Supermarkets { get; set; }

        public IDbSet<Vendor> Vendors { get; set; }

        public IDbSet<Income> Incomes { get; set; }
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public new int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
