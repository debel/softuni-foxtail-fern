namespace _04.GenerateXmlReports
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    using SupermarketChain.Data.Data;
    using SupermarketChain.Data.Utilities;

    public class GenerateXmlReports
    {
        public static void Generate()
        {
            Console.WriteLine("Enter startDate and endDate separated by space in format(yyyy-mm-dd):");
            string input = Console.ReadLine();
            try
            {
                string[] dates = input.Split(' ');
                DateTime startDate = DateTime.Parse(dates[0]);
                DateTime endDate = DateTime.Parse(dates[1]);
                if (startDate > endDate)
                {
                    throw new ArgumentException("StartDate must be before endDate");
                }
                var msSqlData = new SupermarketChainMssqlData();

                XmlDocument xml = new XmlDocument();
                XmlElement salesElement = xml.CreateElement("sales");
                xml.AppendChild(salesElement);

                var vendors = msSqlData.Sales
                    .SearchFor(s => s.SoldDate >= startDate && s.SoldDate <= endDate)
                    .GroupBy(v => v.Product.Vendor.Name,
                        (key, val) => new { Name = key, Sales = val.Select(d => new { d.SoldDate, Sum = d.Quantity * d.Product.Price }) });

                foreach (var vendor in vendors)
                {
                    XmlElement saleElement = xml.CreateElement("sale");
                    saleElement.SetAttribute("vendor", vendor.Name);

                    Console.WriteLine(vendor.Name);
                    var sales = vendor.Sales.GroupBy(
                        s => s.SoldDate,
                        (key, val) => new { Date = key, Sum = val.Sum(t => t.Sum) });

                    foreach (var sale in sales)
                    {
                        XmlElement summaryElement = xml.CreateElement("summary");
                        summaryElement.SetAttribute("date", sale.Date.ToString("dd-MMM-yyyy"));
                        summaryElement.SetAttribute("total-sum", sale.Sum.ToString(CultureInfo.InvariantCulture));

                        saleElement.AppendChild(summaryElement);

                        Console.WriteLine(sale.Date.ToString("dd-MMM-yyyy"));
                        Console.WriteLine(sale.Sum);
                    }

                    salesElement.AppendChild(saleElement);
                }

                string output = xml.OuterXml;

                StreamWriter file = new StreamWriter(Constants.XmlReportsPath);
                file.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                XDocument doc = XDocument.Parse(output);
                file.WriteLine(doc);

                file.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
};