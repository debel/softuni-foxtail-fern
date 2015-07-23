namespace SupermarketChain.ConsoleClient
{
    using System.Globalization;
    using System.Threading;
    using Data.Data;

    public class SupermarketChainMain
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var oracleData = new SupermarketChainOracleData();

            var myssqlData = new SupermarketChainMssqlData();

            ReplicateData.Replicate(oracleData, myssqlData);
        }
    }
}
