namespace _05.ExportToJSON
{
    using System;
    using System.Linq;
    using System.Web.Script.Serialization;
    using SupermarketChain.Data.Data;
    using SupermarketChain.Data.Utilities;
    using System.IO;

    class ExportToJsonMain
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter startDate and endDate separated by space in format(yyyy-mm-dd):");
            string input = Console.ReadLine();
            try
            {
                string[] dates = input.Split(' ');
                DateTime startDate = DateTime.Parse(dates[0]);
                DateTime endDate = DateTime.Parse(dates[1]);
				if(startDate > endDate){
					throw new ArgumentException("StartDate must be before endDate");
				}
                var myssqlData = new SupermarketChainMssqlData();
                var jsSerializer = new JavaScriptSerializer();
                var sales = myssqlData.Sales
                    .All()
                    .Where(s => s.SoldDate >= startDate && s.SoldDate <= endDate)
                    .Select(
                        s => new
                        {
                            productId = s.ProductId,
                            productName = s.Product.Name,
                            vendorName = s.Product.Vendor.Name,
                            totalQuantitySold = s.Quantity,
                            totalIncomes = s.Quantity * s.Product.Price
                        }).ToList();


                foreach (var sale in sales)
                {
                    var productsJson = jsSerializer.Serialize(sale);
                    Console.WriteLine(productsJson);
                    if (!File.Exists(Constants.jsonReportPath + sale.productId + ".json"))
                    {
                        File.WriteAllText(Constants.jsonReportPath + sale.productId + ".json", productsJson);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}
