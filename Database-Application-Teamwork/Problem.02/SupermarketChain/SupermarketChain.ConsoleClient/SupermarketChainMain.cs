namespace SupermarketChain.ConsoleClient
{
    using System.Linq;
    using Data;

    public class SupermarketChainMain
    {
        static void Main()
        {
            var dbContext = new SupermarketChainContext();
            var productsCount = dbContext.Products.Count();
        }
    }
}
