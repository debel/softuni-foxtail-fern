namespace SupermarketChain.Engine.Managers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Xml.Linq;
    using SupermarketChain.Data.Contexts;
    using SupermarketChain.Models;

    public class XmlManager
    {
        public XmlManager(string expensesImportPath, SupermarketsChainMssqlContext context)
        {
            this.ExpensesImportPath = expensesImportPath;
            this.SqlMarketContext = context;
        }

        public string ExpensesImportPath { get; set; }

        public SupermarketsChainMssqlContext SqlMarketContext { get; set; }

        public void TransferData()
        {
            var xmlDoc = XDocument.Load(this.ExpensesImportPath);
            var vendorNamesList = xmlDoc.Root.Elements("vendor");

            foreach (var vendorElement in vendorNamesList)
            {
                var vendorName = vendorElement.Attribute("name").Value;
                var vendorId = this.SqlMarketContext.Vendors
                    .Where(u => u.Name == vendorName)
                    .Select(u => u.Id)
                    .FirstOrDefault();

                var monthExpenses = vendorElement.Elements("expenses");
                foreach (var monthExpense in monthExpenses)
                {
                    var dt = monthExpense.Attribute("month").Value;
                    var parsedDatetime = DateTime.Parse(dt);
                    var expense = monthExpense.Value;       
         
                    var vendorExpense = new Expense
                    {
                        VendorId = vendorId,
                        DateOfExpense = parsedDatetime,
                        ExpenseAmount = decimal.Parse(expense, CultureInfo.InvariantCulture)
                    };

                    this.SqlMarketContext.Expenses.Add(vendorExpense);
                    this.SqlMarketContext.SaveChanges();
                }
            }
        }
    }
}
