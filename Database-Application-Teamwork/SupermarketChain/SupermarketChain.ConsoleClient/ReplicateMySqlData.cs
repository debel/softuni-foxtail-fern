using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketChain.ConsoleClient
{
    using Data.Contexts;
    using Data.Data;
    using Models;

    class ReplicateMySqlData
    {
        public static void TransferFromMssqlToMysql(SupermarketChainMySqlData mySqlData, SupermarketChainMssqlData mssqlData)
        {
            var mySqlVendors = mssqlData.Vendors.All().ToList();
            var mySqlMeasure = mssqlData.Measures.All().ToList();
            var mySqlProducts = mssqlData.Products.All().ToList();
            var mySqlIncomes = mssqlData.Sales
                .All()
                .Select(s => new{Income = (s.Quantity * s.Product.Price ), ProductId = s.ProductId})
                .ToList();
            foreach (var vendor in mySqlVendors)
            {
                var vendors = new Vendor()
                {
                    Name = vendor.Name
                };
                mySqlData.Vendors.Add(vendors);
                mySqlData.SaveChanges();
            }
            foreach (var measure in mySqlMeasure)
            {
                var measures = new Measure()
                {
                    Name = measure.Name
                };
                mySqlData.Measures.Add(measures);
                mySqlData.SaveChanges();
            }

            foreach (var product in mySqlProducts)
            {
                var products = new Product()
                {
                    Name = product.Name,
                    Price = product.Price,
                    VendorId = mySqlData.Vendors.All().FirstOrDefault(v =>v.Name == product.Vendor.Name).Id,
                    MeasureId = mySqlData.Measures.All().FirstOrDefault(m => m.Name == product.Measure.Name ).Id
                };
                mySqlData.Products.Add(products);
                mySqlData.SaveChanges();
            }
            foreach (var income in mySqlIncomes)
            {
                var incomes = new Income()
                {
                    IncomeValue = income.Income,
                    ProductId = income.ProductId
                };
                mySqlData.Incomes.Add(incomes);
                mySqlData.SaveChanges();
            }
        }
    }
}
