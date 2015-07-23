namespace SupermarketChain.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using Contexts;

    internal sealed class MssqlConfiguration : DbMigrationsConfiguration<SupermarketsChainMssqlContext>
    {
        public MssqlConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "SupermarketChainContext";
        }

        protected override void Seed(SupermarketsChainMssqlContext context)
        {

        }
    }
}
