namespace SupermarketChain.Data.Contexts
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations.History;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using Contracts;
    using Migrations;
    using Models;

    public class SupermarketChainMySqlContext : DbContext , ISupermarketsChainDbContext
    {
        public SupermarketChainMySqlContext()
            : base("MyContext")
        {
           //var migration  = new MigrateDatabaseToLatestVersion<SupermarketChainMySqlContext,MySqlConfiguration>();
            //var migration = new DropCreateDatabaseAlways<SupermarketChainMySqlContext>();
            //Database.SetInitializer(migration);
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
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }

}