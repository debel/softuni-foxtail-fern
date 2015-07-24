namespace _05.ExportToJSON
{
    using System;
    using System.Linq;
    using System.Web.Script.Serialization;
    using SupermarketChain.Data.Data;

    class ExportToJsonMain
    {
        static void Main(string[] args)
        {
            var myssqlData = new SupermarketChainMssqlData();
            var jsSerializer = new JavaScriptSerializer();
            var sales = myssqlData.Sales
                .All()
                .Select(
                    s => new
                    {
                        productId = s.ProductId,
                        productName = s.Product.Name,
                        vendorName = s.Product.Vendor.Name,
                        totalQuantitySold = s.Quantity,
                        totalIncomes = s.SaleCost
                    }).ToList();
            var productsJson = jsSerializer.Serialize(sales);
            Console.WriteLine(productsJson);
        }
    }
}
