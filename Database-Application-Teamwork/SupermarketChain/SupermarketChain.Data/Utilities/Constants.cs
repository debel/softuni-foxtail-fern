namespace SupermarketChain.Data.Utilities
{
    public static class Constants
    {
        public const string ReportPath = @"C:\Users\user\Desktop\softuni-foxtail-fern\Database-Application-Teamwork\SupermarketChain\Reports\";
        private const string ImportPath = @"C:\Users\user\Desktop\softuni-foxtail-fern\Database-Application-Teamwork\SupermarketChain\Imports\";

        public const string XmlReportsPath = ReportPath + "Sales-by-Vendors-Report.xml";

        public const string MongoDbDatabaseHost = "mongodb://localhost:27017";
        public const string MongoDbDatabaseName = "SupermarketChain";

        public const string SampleDataPath = ImportPath + @"SampleData\";
        public const string SalesImportPath = ImportPath + "Sample-Sales-Reports.zip";
        public const string XmlExpensesPath = ImportPath + "Sample-Vendor-Expenses.xml";
        public const string SqliteDatabasePath = ImportPath + "TaxInformation.sqlite";

        public const string OracleUser = "ROSI";
    }
}
