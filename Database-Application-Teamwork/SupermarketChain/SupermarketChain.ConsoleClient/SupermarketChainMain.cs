namespace SupermarketChain.ConsoleClient
{
    using System;
    using System.Globalization;
    using System.Threading;
    using Engine;

    public static class SupermarketChainMain
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            PrintMenu();
            
            try
            {
                var command = int.Parse(Console.ReadLine());
                switch (command)
                {
                    case 0:
                        return;
                    case 1: Engine.TransferDataFromOracleToMssql();
                        break;
                    case 2: Engine.ExecuteTransferFromZipToMssql();
                        break;
                    case 3: Engine.ExecutePdfReport();
                        break;
                    case 4: Engine.ExecuteXmlReport();
                        break;
                    case 5: Engine.ExecuteJsonReportAndExportToJson();
                        break;
                    case 6: Engine.ExecuteTransferFromXmlToMssql();
                        break;
                    case 7: Engine.TransferFromMssqlToMysql();
                        break;
                    case 8: //Engine.
                        break;
                    default: throw new InvalidOperationException("Invalid operation.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private static void PrintMenu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("Choose 1: To transfer data from Oracle to MSSQL");
            Console.WriteLine("Choose 2: To transfer data from Zip and Excel to MSSQL");
            Console.WriteLine("Choose 3: To generate PDF Report");
            Console.WriteLine("Choose 4: To generate Xml Report");
            Console.WriteLine("Choose 5: To generate JSON Report and transfer data to MongoDB");
            Console.WriteLine("Choose 6: To transfer data from XML to MSSQL");
            Console.WriteLine("Choose 7: To transfer data from MSSQL to MySQL");
            Console.WriteLine("Choose 8: To generate Excel Report from both SQLite and MySQL");
        }
    }
}
