using System;

namespace ImportToSQLServer
{
    class test
    {
        public static void Main()
        {
            var mySqlDB = new ReadFromMySqlWithOpenAccess();
            foreach (var product in mySqlDB.ProductsTable)
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
