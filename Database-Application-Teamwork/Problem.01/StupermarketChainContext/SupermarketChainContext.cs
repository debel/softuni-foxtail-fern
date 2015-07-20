using StupermarketChainContext.Migrations;

namespace StupermarketChainContext
{
    using System.Data.Entity;

    public class SupermarketChainContext : DbContext
    {
        public SupermarketChainContext()
            : base("OracleDbContext")
        {
            var migration = new MigrateDatabaseToLatestVersion<SupermarketChainContext,Configuration>();
            Database.SetInitializer(migration);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Measure> Measures { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("JINJAAR");

            // ...
        }
    }

}