using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using System.Data.SQLite;
using System.Data.OleDb;
using System.Data;

namespace VendorsTotalReport
{
    class Program
    {
        public static MongoDatabase db
        {
            get
            {
                var connectionstring = "mongodb://localhost";
                MongoServer dbServer = new MongoClient(connectionstring).GetServer();
                MongoDatabase dbConnection = dbServer.GetDatabase("vendor");
                return dbConnection;
            }
        }

        public static void Main(string[] args)
        {
            //HardCodeMongoVendorReports();
            //SQLConnection();
            ReadFromSQLite();
        }

        public static void SQLConnection()
        {
            SQLiteConnection dbCon = new SQLiteConnection("Data Source= ..\\..\\Products.db;Version=3;");

            dbCon.Open();

            using (dbCon)
            {
                var reports = GetVendorReports();
                foreach (var report in reports)
	            {
                    SQLiteCommand query = new SQLiteCommand("Insert Into Product(ProductName) VALUES(@ProductName)", dbCon);
                    query.Parameters.AddWithValue("@ProductName", report.ProductName);

                    query.ExecuteNonQuery();
                }
            }
        }

        public static void ReadFromSQLite()
        {
            SQLiteConnection dbCon = new SQLiteConnection("Data Source= ..\\..\\Products.db;Version=3;");

            dbCon.Open();

            using (dbCon)
            {
                SQLiteCommand query = new SQLiteCommand("SELECT * FROM Product", dbCon);

                SQLiteDataReader reader = query.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        InserToExcel((string)reader["ProductName"]);
                    }
                }
            }
        }

        public static void InserToExcel(string productName)
        {
            OleDbConnectionStringBuilder csbuilder = new OleDbConnectionStringBuilder();
            csbuilder.Provider = "Microsoft.ACE.OLEDB.12.0";
            csbuilder.DataSource = @"..\..\Products-Total-Report.xlsx";
            csbuilder.Add("Extended Properties", "Excel 12.0 Xml;HDR=YES");

            DataTable dt = new DataTable("datatable");

            using (OleDbConnection connection = new OleDbConnection(csbuilder.ConnectionString))
            {
                connection.Open();
                string selectSql = @"INSERT INTO [Sheet1$] VALUES('"+productName+"')";
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(selectSql, connection))
                {
                    adapter.FillSchema(dt, SchemaType.Source);
                    adapter.Fill(dt);
                }
                connection.Close();
            }
        }

        public static void HardCodeMongoVendorReports()
        {
            var value = new Product() { ProductName = "Beer zagorka", VendorName = "Zagorka Corp", Quantity = 673, Incomes = 609.24 };
           db.GetCollection<Product>("reports").Save(value);
        }

        public static IQueryable<Product> GetVendorReports()
        {
            return db.GetCollection<Product>("reports").AsQueryable();
        }
    }
}
