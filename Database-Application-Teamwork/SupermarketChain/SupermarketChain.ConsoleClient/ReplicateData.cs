namespace SupermarketChain.ConsoleClient
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using Data.Contracts;
    using Data.Data;
    using Models;

    public static class ReplicateData
    {
        public static void Replicate(SupermarketChainOracleData oracleData, SupermarketChainMssqlData myssqlData)
        {
            //var oracleVendors = oracleData.Vendors
            //    .All()
            //    .ToList();

            //var oracleMeasures = oracleData.Measures
            //    .All()
            //    .ToList();

            var oracleProducts = oracleData.Products
                .All()
                .ToList();

            oracleData.Dispose();

            //foreach (var vendor in oracleVendors)
            //{
            //    myssqlData.Vendors.Add(vendor);
            //    myssqlData.SaveChanges();
            //}
            //foreach (var measures in oracleMeasures)
            //{
            //    myssqlData.Measures.Add(measures);
            //    myssqlData.SaveChanges();
            //}
            foreach (var products in oracleProducts)
            {
                myssqlData.Products.Add(products);
                myssqlData.SaveChanges();
            }
        }
    }
}
