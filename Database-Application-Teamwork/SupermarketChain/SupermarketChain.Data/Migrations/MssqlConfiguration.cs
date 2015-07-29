namespace SupermarketChain.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using Contexts;

    internal sealed class MssqlConfiguration : DbMigrationsConfiguration<SupermarketsChainMssqlContext>
    {
        public MssqlConfiguration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = true;
            ContextKey = "SupermarketChainContext";
        }

        protected override void Seed(SupermarketsChainMssqlContext context)
        {

        }
    }
}
