namespace SupermarketChain.Engine.Managers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Transactions;
    using System.Xml.Linq;
    using GemBox.Spreadsheet;
    using Ionic.Zip;
    using SupermarketChain.Data.Contexts;
    using SupermarketChain.Models;
    using LoadOptions = GemBox.Spreadsheet.LoadOptions;

    public class ZipManager
    {
        public ZipManager(string archivePath, SupermarketsChainMssqlContext context)
        {
            this.ArchivePath = archivePath;
            this.SqlMarketContext = context;
        }

        public string ArchivePath { get; private set; }

        public SupermarketsChainMssqlContext SqlMarketContext { get; private set; }

        public void TransferData()
        {
            using (ZipFile zip = ZipFile.Read(this.ArchivePath))
            {
                var xlsFiles = zip.Where(z => z.FileName.EndsWith(".xls"));

                foreach (var report in xlsFiles)
                {
                    using (TransactionScope tran = new TransactionScope())
                    {
                        this.ParseReportData(report);
                        tran.Complete();
                    }
                }
            }
        }

        private void ParseReportData(ZipEntry report)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                report.Extract(ms);
                ms.Position = 0;

                SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
                ExcelFile file = ExcelFile.Load(ms, LoadOptions.XlsDefault);
                var date = DateTime.Parse(report.FileName.Substring(0, 11));

                this.ParseExcelSheets(report.FileName, file, date);
            }
        }

        private void ParseExcelSheets(string filename, ExcelFile report, DateTime reportDate)
        {
            foreach (ExcelWorksheet sheet in report.Worksheets)
            {
                Console.WriteLine(filename);

                var supermarketName = sheet.Rows[1].AllocatedCells[1].Value.ToString();
                supermarketName = this.ReplaceSpecialCharacters(supermarketName);

                using (TransactionScope tran = new TransactionScope())
                {
                    this.SqlMarketContext.Supermarkets.Add(new Supermarket(){Name = supermarketName});
                    this.SqlMarketContext.SaveChanges();
                    tran.Complete();
                }

                var supermarket =
                    this.SqlMarketContext.Supermarkets.FirstOrDefault(s => s.Name == supermarketName);

                if (supermarket != null)
                {
                    var productsImported = this.ParseRowsData(reportDate, sheet, supermarket.Id);
                    Console.WriteLine("{0}/{1} sales imported.\n", productsImported, sheet.Rows.Count - 4);                    
                }

            }
        }

        private int ParseRowsData(DateTime reportDate, ExcelWorksheet sheet, int dbSupermarketId)
        {
            var productsImported = 0;

            for (var i = 3; i < sheet.Rows.Count - 1; i++)
            {
                var productName = sheet.Rows[i].AllocatedCells[1].Value.ToString().Normalize();
                productName = this.ReplaceSpecialCharacters(productName);

                var product =
                    this.SqlMarketContext.Products.FirstOrDefault(p => p.Name == productName);

                if (product != null)
                {
                    this.GenerateSalesReport(reportDate, sheet.Rows[i], dbSupermarketId, product.Id);
                    productsImported++;
                }
            }

            return productsImported;
        }

        private void GenerateSalesReport(DateTime date, ExcelRow row, int dbSupermarketId, int dbProductId)
        {
            var quantity = int.Parse(row.AllocatedCells[2].Value.ToString());

            var salesReport = new Sale
            {
                SupermarketId = dbSupermarketId,
                ProductId = dbProductId,
                Quantity = quantity,
                SoldDate = date
            };
            using (TransactionScope tran = new TransactionScope())
            {
                this.SqlMarketContext.Sales.Add(salesReport);
                this.SqlMarketContext.SaveChanges();
                tran.Complete();
            }
        }

        private string ReplaceSpecialCharacters(string name)
        {
            var newName = name.Trim();

            newName = newName.Replace('\u2013', '-');
            newName = newName.Replace('\u2014', '-');
            newName = newName.Replace('\u2015', '-');
            newName = newName.Replace('\u2017', '_');
            newName = newName.Replace('\u2018', '\'');
            newName = newName.Replace('\u2019', '\'');
            newName = newName.Replace('\u201a', ',');
            newName = newName.Replace('\u201b', '\'');
            newName = newName.Replace('\u201c', '\"');
            newName = newName.Replace('\u201d', '\"');
            newName = newName.Replace('\u201e', '\"');
            newName = newName.Replace("\u2026", "...");
            newName = newName.Replace('\u2032', '\'');
            newName = newName.Replace('\u2033', '\"');

            return newName;
        }
    }
}
