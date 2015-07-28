namespace SupermarketChain.Engine
{
    using System;
    using System.Linq;
    using System.Transactions;
    using Data.Contexts;
    using Data.Data;
    using Data.Utilities;
    using Managers;
    using Models;

    public static class Engine
    {
        public static void ExecuteTransferFromZipToMssql()
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

        public static void ExecutePdfReport()
        {
            Console.WriteLine("Enter startDate and endDate separated by whitespace. (e.g. 2014-07-21 2014-07-21)");
            string input = Console.ReadLine();
            try
            {
                string[] dates = input.Split(' ');
                PdfManager.ExportDataToPdf(DateTime.Parse(dates[0]), DateTime.Parse(dates[1]));
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input." + e.Message);
            }
        }

        public static void ExecuteXmlReport()
        {
            Console.WriteLine("Enter startDate and endDate separated by space in format(yyyy-mm-dd), e.g. (2014-07-01 2014-07-30):");

            XmlReportManager.Generate();

            Console.WriteLine("Report generated.");
        }

        public static void ExecuteJsonReportAndExportToJson()
        {
            JsonManager.GenerateJsonReports();
        }

        public static void ExecuteTransferFromXmlToMssql()
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

        public static void TransferDataFromOracleToMssql()
        {
            var oracleData = new SupermarketChainOracleData();
            oracleData.Products.All().Count();
            var mssqlData = new SupermarketChainMssqlData();

            Console.WriteLine("Data trasfer...");
            var oracleVendors = oracleData.Vendors.All()
                .ToList();
            var oracleMeasures = oracleData.Measures.All()
                .ToList();
            var oracleProducts = oracleData.Products.All()
                .ToList();

            foreach (var oracleVendor in oracleVendors)
            {
                var a = new Vendor
                {
                    Name = oracleVendor.Name
                };
                mssqlData.Vendors.Add(a);
                mssqlData.SaveChanges();
            }

            foreach (var oracleMeasure in oracleMeasures)
            {
                var a = new Measure
                {
                    Name = oracleMeasure.Name
                };
                mssqlData.Measures.Add(a);
                mssqlData.SaveChanges();
            }

            foreach (var oracleProduct in oracleProducts)
            {
                var a = new Product
                {
                    Name = oracleProduct.Name,
                    MeasureId = mssqlData.Measures.All().FirstOrDefault(m => m.Name == oracleProduct.Measure.Name).Id,
                    Price = oracleProduct.Price,
                    VendorId = mssqlData.Vendors.All().FirstOrDefault(m => m.Name == oracleProduct.Vendor.Name).Id
                };
                mssqlData.Products.Add(a);
                mssqlData.SaveChanges();
            }
            Console.WriteLine("Data is transferred to MSSQL");
        }

        public static void TransferFromMssqlToMysql()
        {
            var mssqlData = new SupermarketChainMssqlData();
            var mySqlData = new SupermarketChainMySqlData(); 

            var mySqlVendors = mssqlData.Vendors.All().ToList();
            var mySqlMeasure = mssqlData.Measures.All().ToList();
            var mySqlProducts = mssqlData.Products.All().ToList();
            var mySqlIncomes = mssqlData.Sales
                .All()
                .Select(s => new { Income = (s.Quantity * s.Product.Price), ProductId = s.ProductId })
                .ToList();
            foreach (var vendor in mySqlVendors)
            {
                var vendors = new Vendor()
                {
                    Name = vendor.Name
                };
                mySqlData.Vendors.Add(vendors);
                mySqlData.SaveChanges();
            }
            foreach (var measure in mySqlMeasure)
            {
                var measures = new Measure()
                {
                    Name = measure.Name
                };
                mySqlData.Measures.Add(measures);
                mySqlData.SaveChanges();
            }

            foreach (var product in mySqlProducts)
            {
                var products = new Product()
                {
                    Name = product.Name,
                    Price = product.Price,
                    VendorId = mySqlData.Vendors.All().FirstOrDefault(v => v.Name == product.Vendor.Name).Id,
                    MeasureId = mySqlData.Measures.All().FirstOrDefault(m => m.Name == product.Measure.Name).Id
                };
                mySqlData.Products.Add(products);
                mySqlData.SaveChanges();
            }
            foreach (var income in mySqlIncomes)
            {
                var incomes = new Income()
                {
                    IncomeValue = income.Income,
                    ProductId = income.ProductId
                };
                mySqlData.Incomes.Add(incomes);
                mySqlData.SaveChanges();
            }
        }
    }
}
