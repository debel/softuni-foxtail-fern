namespace _02.ZipManager
{
    using System;
    using System.Transactions;
    using SupermarketChain.Data.Contexts;
    using SupermarketChain.Data.Utilities;

    public static class ZipMain
    {
        public static void Main()
        {
            var sqlContext = new SupermarketsChainMssqlContext();

            Console.WriteLine();
            Console.WriteLine("Extracting data from reports...\n");
            var zipManager = new ZipManager(Constants.SalesImportPath, sqlContext);

            using (TransactionScope tran = new TransactionScope())
            {
                Console.WriteLine("\nSending data to SQL Server...");
                zipManager.TransferData();
                tran.Complete();
            }

            Console.WriteLine("Sales reports imported.");
        }
    }
}
