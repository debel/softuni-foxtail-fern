using System.IO;

namespace StupermarketChainContext.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<SupermarketChainContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "StupermarketChainContext.SupermarketChainContext";
        }

        protected override void Seed(SupermarketChainContext context)
        {
            if (context.Products.Any())
            {
                return;
            }

            //Insert vendors into table
            string path1 = @"C:\Users\Jinjaar-pc\Desktop\softuni-foxtail-fern\Database-Application-Teamwork\Problem.01\DatabaseInformation\Vendors.txt";
            string vendorLine = null;
            StreamReader vendorFile = new StreamReader(path1);
            while ((vendorLine = vendorFile.ReadLine()) != null)
            {
                Vendor vendor = new Vendor()
                {
                    VendorName = vendorLine
                };
                context.Vendors.Add(vendor);
                context.SaveChanges();
            }

            vendorFile.Close();

            //Insert measures into table
            string path2 = @"C:\Users\Jinjaar-pc\Desktop\softuni-foxtail-fern\Database-Application-Teamwork\Problem.01\DatabaseInformation\Measures.txt";
            string measureLine = null;
            StreamReader measureFile = new StreamReader(path2);
            while ((measureLine = measureFile.ReadLine()) != null)
            {
                Measure measure = new Measure()
                {
                    MeasureName = measureLine
                };
                context.Measures.Add(measure);
                context.SaveChanges();
            }

            measureFile.Close();


            //Insert products into table
            string path3 = @"C:\Users\Jinjaar-pc\Desktop\softuni-foxtail-fern\Database-Application-Teamwork\Problem.01\DatabaseInformation\Products.txt";
            string productsLine = null;
            StreamReader productsFile = new StreamReader(path3);
            while ((productsLine = productsFile.ReadLine()) != null)
            {
                string[] currentProductLine = productsLine.Split(',');
                int vendorId = int.Parse(currentProductLine[0]);
                string productName = currentProductLine[1];
                int measureId = int.Parse(currentProductLine[2]);
                double price = double.Parse(currentProductLine[3]);
                Product procut = new Product()
                {
                    VendorId = vendorId,
                    ProductName = productName,
                    MeasureId = measureId,
                    Price = price
                };
                context.Products.Add(procut);


            }

            productsFile.Close();


            context.SaveChanges();
        }
    }
}
