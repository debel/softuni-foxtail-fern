namespace _06.LoadExpenseDataFromXml
{
    using System;
    using System.IO;
    using System.Text;
    using System.Transactions;
    using System.Xml;
    using SupermarketChain.Data.Contexts;
    using SupermarketChain.Data.Utilities;

    class XmlMain
    {
        static void Main(string[] args)
        {
            var sqlContext = new SupermarketsChainMssqlContext();

            Console.WriteLine();
            Console.WriteLine("Extracting data from reports...\n");
            var xmlManager = new XmlManager(Constants.XmlExpensesPath, sqlContext);

            using (TransactionScope tran = new TransactionScope())
            {
                Console.WriteLine("\nSending data to SQL Server...");
                xmlManager.TransferData();
                tran.Complete();
            }

            Console.WriteLine("Sales reports imported.");
        }
    }
}
