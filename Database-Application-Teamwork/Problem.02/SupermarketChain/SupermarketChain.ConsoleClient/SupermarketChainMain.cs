namespace SupermarketChain.ConsoleClient
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using Data;

    public class SupermarketChainMain
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var dbData = new SupermarketsChainData();
            var products = dbData.Products.All();
            foreach (var product in products)
            {
                Console.WriteLine(
                    product.Name);
            }
            

        }
    }
}
