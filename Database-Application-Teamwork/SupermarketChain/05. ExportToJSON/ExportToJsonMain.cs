namespace _05.ExportToJSON
{
    using System;
    using System.Linq;
    using System.Web.Script.Serialization;
    using SupermarketChain.Data.Data;
    using SupermarketChain.Data.Utilities;
    using System.IO;
    using MongoDB.Bson;
    using MongoDB.Bson.IO;
    using MongoDB.Bson.Serialization;
    using MongoDB.Bson.Serialization.Serializers;
    using MongoDB.Driver;

    class ExportToJsonMain
    {
        static void Main()
        {
            GenerateJsonReports();
        }

        private static IMongoCollection<BsonDocument> GetDatabaseCollection()
        {
            var client = new MongoClient(Constants.MongoDbDatabaseHost);
            var database = client.GetDatabase(Constants.MongoDbDatabaseName);
            var collection = database.GetCollection<BsonDocument>("SalesByProductReports");
            return collection;
        }

        private static void SaveDataInMongoDb(string productJson)
        {
            var reader = new JsonReader(productJson);
            var context = BsonDeserializationContext.CreateRoot(reader);
            BsonDocument doc = BsonDocumentSerializer.Instance.Deserialize(context);
            GetDatabaseCollection().InsertOneAsync(doc).Wait();
        }

        private static void GenerateJsonReports()
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
                    var productJson = jsSerializer.Serialize(sale);

                    SaveDataInMongoDb(productJson);

                    if (!File.Exists(Constants.jsonReportPath + sale.productId + ".json"))
                    {
                        File.WriteAllText(Constants.jsonReportPath + sale.productId + ".json", productJson);
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
