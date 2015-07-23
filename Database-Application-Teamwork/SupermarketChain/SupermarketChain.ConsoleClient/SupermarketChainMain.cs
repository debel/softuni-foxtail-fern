namespace SupermarketChain.ConsoleClient
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using Data;
    using Data.Data;

    public class SupermarketChainMain
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            
            var oracleData = new SupermarketChainOracleData();
            var oracleProducts = oracleData.Products.All();

            foreach (var product in oracleProducts)
            {
                Console.WriteLine(
                    product.Name);
            }

            var myssqlData = new SupermarketChainMssqlData();
            var products = myssqlData.Products.All();

            foreach (var product in products)
            {
                Console.WriteLine(
                    product.Name);
            }

            //ReplicateData.Replicate(oracleData, myssqlData);

            
        }
    }
}
