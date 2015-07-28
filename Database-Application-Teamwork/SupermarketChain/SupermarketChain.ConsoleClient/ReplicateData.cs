namespace SupermarketChain.ConsoleClient
{
    using System.Linq;
    using Data.Data;
    using Models;

    public static class ReplicateData
    {
        public static void Replicate(SupermarketChainOracleData oracleData, SupermarketChainMssqlData mssqlData)
        {
            var oracleVendors = oracleData.Vendors.All()
                .ToList();
            var oracleMeasures = oracleData.Measures.All()
                .ToList();
            var oracleProducts = oracleData.Products.All()
                .ToList();

            foreach (var oracleVendor in oracleVendors)
            {
                var a = new Vendor
                {
                    Name = oracleVendor.Name
                };
                mssqlData.Vendors.Add(a);
                mssqlData.SaveChanges();
            }

            foreach (var oracleMeasure in oracleMeasures)
            {
                var a = new Measure
                {
                    Name = oracleMeasure.Name
                };
                mssqlData.Measures.Add(a);
                mssqlData.SaveChanges();
            }

            foreach (var oracleProduct in oracleProducts)
            {
                var a = new Product
                {
                    Name = oracleProduct.Name,
                    MeasureId = mssqlData.Measures.All().FirstOrDefault(m => m.Name == oracleProduct.Measure.Name).Id,
                    Price = oracleProduct.Price,
                    VendorId = mssqlData.Vendors.All().FirstOrDefault(m => m.Name == oracleProduct.Vendor.Name).Id
                };
                mssqlData.Products.Add(a);
                mssqlData.SaveChanges();
            }
        }
    }
}
