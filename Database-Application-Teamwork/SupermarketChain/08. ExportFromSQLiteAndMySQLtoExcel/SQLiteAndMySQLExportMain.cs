namespace _08.ExportFromSQLiteAndMySQLtoExcel
{
    using System;
    using System.Data.SQLite;
    using SupermarketChain.Data.Utilities;

    class SQLiteAndMySQLExportMain
    {
        static void Main(string[] args)
        {
            GetDataFromSQLite();
        }

        private static void GetDataFromSQLite()
        {
            var query = "select * from ProductTaxes";
            var dataSource = Constants.SqliteDatabasePath;
            var con = new SQLiteConnection("Data Source=" + dataSource);
            var selectCommand = new SQLiteCommand(query, con);
            SQLiteDataReader reader = null;

            try
            {
                con.Open();
                reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    var product = reader["ProductName"];
                    var tax = reader["Tax"];
                    Console.WriteLine("Product: {0}\nTax: {1}",
                        product, tax);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                con.Close();
            }
        }
    }
}
