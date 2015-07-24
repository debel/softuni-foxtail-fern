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

            Console.WriteLine(myssqlData.Products.All().Count());

            //ReplicateData.Replicate(oracleData, myssqlData);
        }
    }
}
