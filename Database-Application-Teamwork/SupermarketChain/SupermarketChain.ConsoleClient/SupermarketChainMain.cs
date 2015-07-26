namespace SupermarketChain.ConsoleClient
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using Data.Data;
    using _05.ExportToJSON;

    public class SupermarketChainMain
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var oracleData = new SupermarketChainOracleData();

            var myssqlData = new SupermarketChainMssqlData();
            var salesQuery = myssqlData.Sales
                    .All()
                    .Select(
                        s => new
                        {
                            productName = s.Product.Name,
                            totalQuantitySold = s.Quantity,
                            unitPrice = s.Product.Price,
                            location = s.Supermarket.Name,
                            totalIncomes = s.Quantity * s.Product.Price
                        }).ToList();

            Console.WriteLine(salesQuery.Count);

            oracleData.Products.All().Count();

            //ReplicateData.Replicate(oracleData, myssqlData);
        }
    }
}
