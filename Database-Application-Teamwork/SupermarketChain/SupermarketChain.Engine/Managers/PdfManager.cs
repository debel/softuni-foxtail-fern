namespace SupermarketChain.Engine.Managers
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using Data.Data;
    using Data.Utilities;
    using iTextSharp.text;
    using iTextSharp.text.pdf;

    public class PdfManager
    {
        public static void ExportDataToPdf(DateTime startDate, DateTime endDate)
        {
            var myssqlData = new SupermarketChainMssqlData();

            var document = new Document(PageSize.A4, 50, 50, 10, 10);

            // Create a new PdfWriter object, specifying the output stream
            var output = File.Create(Constants.ReportPath + "PdfReport.pdf");
            var writer = PdfWriter.GetInstance(document, output);

            // Open the Document for writing
            document.Open();

            var salesInfoTable = new PdfPTable(5);
            salesInfoTable.TotalWidth = 100f;
            salesInfoTable.HorizontalAlignment = 0;
            salesInfoTable.SpacingBefore = 5;
            salesInfoTable.SpacingAfter = 5;
            salesInfoTable.DefaultCell.Border = 0;
            salesInfoTable.SetWidths(new float[] { 3f, 1.5f, 2f, 3f, 1f });

            //set fonts
            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            Font normal = new Font(bfTimes, 10);
            Font bold = new Font(bfTimes, 11, Font.BOLD);

            PdfPCell cellHeader = new PdfPCell(new Phrase("Aggregated Sales Report"));
            cellHeader.Colspan = 5;
            cellHeader.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
            cellHeader.BackgroundColor = new BaseColor(135, 196, 28);
            cellHeader.PaddingTop = 10f;
            cellHeader.PaddingBottom = 10f;
            salesInfoTable.AddCell(cellHeader);

            salesInfoTable.AddCell(new Phrase("Product", bold));
            salesInfoTable.AddCell(new Phrase("Quantity", bold));
            salesInfoTable.AddCell(new Phrase("Unit Price", bold));
            salesInfoTable.AddCell(new Phrase("Location", bold));
            salesInfoTable.AddCell(new Phrase("Sum", bold));

            var salesQuery = myssqlData.Sales
                    .All()
                    .Where(s => s.SoldDate >= startDate && s.SoldDate <= endDate)
                    .Select(
                        s => new
                        {
                            productName = s.Product.Name,
                            totalQuantitySold = s.Quantity,
                            unitPrice = s.Product.Price,
                            location = s.Supermarket.Name,
                            totalIncomes = s.Quantity * s.Product.Price
                        }).ToList();

            foreach (var sale in salesQuery)
            {
                salesInfoTable.AddCell(sale.productName);
                salesInfoTable.AddCell(Convert.ToDecimal(sale.totalQuantitySold).ToString(CultureInfo.InvariantCulture));
                salesInfoTable.AddCell(Convert.ToDecimal(sale.unitPrice).ToString(CultureInfo.InvariantCulture));
                salesInfoTable.AddCell(sale.location);
                salesInfoTable.AddCell(Convert.ToDecimal(sale.totalIncomes).ToString(CultureInfo.InvariantCulture));
            }

            document.Add(salesInfoTable);
            document.Close();
        }
    }
}
