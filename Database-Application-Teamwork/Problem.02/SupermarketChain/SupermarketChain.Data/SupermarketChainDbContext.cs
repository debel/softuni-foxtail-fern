namespace SupermarketChain.Data
{
    using System.Data.Entity;
    using SupermarketChain.Data.Contracts;
    using SupermarketChain.Data.Migrations;
    using SupermarketChain.Models;

    public class SupermarketsChainDbContext : DbContext, ISupermarketsChainDbContext
    {
        public SupermarketsChainDbContext()
            : base("name=SupermarketChainContext")
        {
            var migrationStrategy = new MigrateDatabaseToLatestVersion<SupermarketsChainDbContext, Configuration>();
            Database.SetInitializer(migrationStrategy);
        }

        public IDbSet<Measure> Measures { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Vendor> Vendors { get; set; }

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
