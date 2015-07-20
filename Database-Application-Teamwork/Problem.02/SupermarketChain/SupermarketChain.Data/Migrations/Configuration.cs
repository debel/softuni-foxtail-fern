namespace SupermarketChain.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<SupermarketChainContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //AutomaticMigrationDataLossAllowed = true;
            ContextKey = "SupermarketChain.Data.SupermarketChainContext";
        }

        protected override void Seed(SupermarketChainContext context)
        {
            if (context.Products.Any())
            {
                return;
            }

            SeedVendors(context);
            SeedMeasures(context);
            SeedProducts(context);
        }

        private void SeedVendors(SupermarketChainContext context)
        {
            string path = @"C:\Users\Georgi\Documents\Visual Studio 2013\Projects\DBApps\SupermarketChain\SampleData\Vendors.txt";
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

        private void SeedMeasures(SupermarketChainContext context)
        {
            string path = @"C:\Users\Georgi\Documents\Visual Studio 2013\Projects\DBApps\SupermarketChain\SampleData\Measures.txt";
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

        private void SeedProducts(SupermarketChainContext context)
        {
            string path = @"C:\Users\Georgi\Documents\Visual Studio 2013\Projects\DBApps\SupermarketChain\SampleData\Products.txt";
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
