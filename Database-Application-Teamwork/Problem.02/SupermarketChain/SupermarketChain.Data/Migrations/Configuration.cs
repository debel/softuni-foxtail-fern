namespace SupermarketChain.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<SupermarketsChainDbContext>
    {
        
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //AutomaticMigrationDataLossAllowed = true;
            ContextKey = "SupermarketChain.Data.SupermarketChainContext";
        }

        protected override void Seed(SupermarketsChainDbContext context)
        {
            if (context.Products.Any())
            {
                return;
            }

            SeedVendors(context);
            SeedMeasures(context);
            SeedProducts(context);
        }

        private void SeedVendors(SupermarketsChainDbContext context)
        {
            string path = @"C:\Users\user\Desktop\softuni-foxtail-fern.git\trunk\Database-Application-Teamwork\Problem.02\SupermarketChain\SampleData\Vendors.txt";
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

        private void SeedMeasures(SupermarketsChainDbContext context)
        {
            string path = @"C:\Users\user\Desktop\softuni-foxtail-fern.git\trunk\Database-Application-Teamwork\Problem.02\SupermarketChain\SampleData\Measures.txt";
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

        private void SeedProducts(SupermarketsChainDbContext context)
        {
            string path = @"C:\Users\user\Desktop\softuni-foxtail-fern.git\trunk\Database-Application-Teamwork\Problem.02\SupermarketChain\SampleData\Products.txt";
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
