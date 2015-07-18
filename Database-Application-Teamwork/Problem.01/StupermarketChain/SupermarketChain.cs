using System.IO;
using StupermarketChainContext;

public class SupermarketChain
{
    static void Main()
    {
        
        SupermarketChainContext context = new SupermarketChainContext();
       
        //Insert vendors into table
        
        string vendorLine = null;
        StreamReader vendorFile = new StreamReader("Vendors.txt");
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

        string measureLine = null;
        StreamReader measureFile = new StreamReader("Measures.txt");
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

        string productsLine = null;
        StreamReader productsFile = new StreamReader("Products.txt");
        while ((productsLine = productsFile.ReadLine()) != null)
        {
            string[] currentProductLine = productsLine.Split(',');
            int vendorId = int.Parse(currentProductLine[0]);
            string productName = currentProductLine[1];
            int measureId = int.Parse(currentProductLine[2]);
            double price = double.Parse(currentProductLine[3]);
            Product procut = new Product()
            {
                VendorId =  vendorId,
                ProductName = productName,
                MeasureId =  measureId,
                Price = price
            };
            context.Products.Add(procut);


        }

       productsFile.Close();

        context.SaveChanges();
    }
}
