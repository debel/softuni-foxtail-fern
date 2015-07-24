namespace SupermarketChain.Data.Contexts
{
    using System.Data.Entity;
    using Contracts;
    using Migrations;
    using Models;

    public class SupermarketChainOracleContext : DbContext, ISupermarketsChainDbContext
    {
        public SupermarketChainOracleContext() 
            : base("OracleDbContext")
        {
            var migration = new MigrateDatabaseToLatestVersion<SupermarketChainOracleContext, OracleConfiguration>();
            //var migration = new DropCreateDatabaseAlways<SupermarketChainOracleContext>();
            Database.SetInitializer(migration);
        }
        public IDbSet<Expense> Expenses { get; set; }

        public IDbSet<Measure> Measures { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Sale> Sales { get; set; }

        public IDbSet<Supermarket> Supermarkets { get; set; }

        public IDbSet<Vendor> Vendors { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public new int SaveChanges()
        {
            return base.SaveChanges();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ROSI");
            modelBuilder.Ignore<Expense>();
            modelBuilder.Ignore<Supermarket>();
            modelBuilder.Ignore<Sale>();
        }
    }
}
