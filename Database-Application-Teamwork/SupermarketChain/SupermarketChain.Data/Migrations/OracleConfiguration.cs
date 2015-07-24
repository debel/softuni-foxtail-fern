namespace SupermarketChain.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using Contexts;
    using Models;
    using Utilities;

    public sealed class OracleConfiguration : DbMigrationsConfiguration<SupermarketChainOracleContext>
    {
        public OracleConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "OracleDbContext";
        }

        protected override void Seed(SupermarketChainOracleContext context)
        {
            if (context.Products.Any())
            {
                return;
            }

            SeedVendors(context);
            SeedMeasures(context);
            SeedProducts(context);
        }

        private void SeedVendors(SupermarketChainOracleContext context)
        {
            string path = Constants.SampleDataPath + "Vendors.txt";
            var reader = new StreamReader(path);
            var line = reader.ReadLine();

            while (line != null)
            {
                Vendor vendor = new Vendor()
                {
                    Name = line
                };

                context.Vendors.Add(vendor);

                line = reader.ReadLine();
            }

            context.SaveChanges();
        }

        private void SeedMeasures(SupermarketChainOracleContext context)
        {
            string path = Constants.SampleDataPath + "Measures.txt";
            var reader = new StreamReader(path);
            var line = reader.ReadLine();

            while (line != null)
            {
                Measure measure = new Measure()
                {
                    Name = line
                };

                context.Measures.Add(measure);

                line = reader.ReadLine();
            }

            context.SaveChanges();
        }

        private void SeedProducts(SupermarketChainOracleContext context)
        {
            string path = Constants.SampleDataPath + "Products.txt";
            var reader = new StreamReader(path);
            var line = reader.ReadLine();

            while (line != null)
            {
                string[] currentProductLine = line.Split(',');
                int vendorId = int.Parse(currentProductLine[0]);
                string productName = currentProductLine[1];
                int measureId = int.Parse(currentProductLine[2]);
                decimal price = decimal.Parse(currentProductLine[3]);
                Product product = new Product()
                {
                    Name = productName,
                    Price = price,
                    VendorId = vendorId,
                    MeasureId = measureId,
                };

                context.Products.Add(product);

                line = reader.ReadLine();
            }

            context.SaveChanges();
        }
    }
}
