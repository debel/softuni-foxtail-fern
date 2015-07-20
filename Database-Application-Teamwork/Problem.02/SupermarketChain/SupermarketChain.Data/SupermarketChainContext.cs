namespace SupermarketChain.Data
{
    using System.Data.Entity;
    using Models;
    using Migrations;

    public class SupermarketChainContext : DbContext
    {
        public SupermarketChainContext()
            : base("name=SupermarketChainContext")
        {
            var migrationStrategy = new MigrateDatabaseToLatestVersion<SupermarketChainContext, Configuration>();
            Database.SetInitializer(migrationStrategy);
        }

        public IDbSet<Vendor> Vendors { get; set; }
        public IDbSet<Measure> Measures { get; set; }
        public IDbSet<Product> Products { get; set; }
    }
}