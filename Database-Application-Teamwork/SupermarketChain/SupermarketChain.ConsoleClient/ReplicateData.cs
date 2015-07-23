namespace SupermarketChain.ConsoleClient
{
    using System.Linq;
    using Data.Data;
    using Models;

    public static class ReplicateData
    {
        public static void Replicate(SupermarketChainOracleData oracleData, SupermarketChainMssqlData myssqlData)
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
                myssqlData.Vendors.Add(a);
                myssqlData.SaveChanges();
            }

            foreach (var oracleMeasure in oracleMeasures)
            {
                var a = new Measure
                {
                    Name = oracleMeasure.Name
                };
                myssqlData.Measures.Add(a);
                myssqlData.SaveChanges();
            }

            foreach (var oracleProduct in oracleProducts)
            {
                var a = new Product
                {
                    Name = oracleProduct.Name,
                    MeasureId = myssqlData.Measures.All().FirstOrDefault(m => m.Name == oracleProduct.Measure.Name).Id,
                    Price = oracleProduct.Price,
                    VendorId = myssqlData.Vendors.All().FirstOrDefault(m => m.Name == oracleProduct.Vendor.Name).Id
                };
                myssqlData.Products.Add(a);
                myssqlData.SaveChanges();
            }
        }
    }
}
