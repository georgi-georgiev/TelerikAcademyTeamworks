using System.Linq;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System;

namespace GenerateSalesReportXML
{
    public class Raport
    {
        public Raport(string pathToRaports)
        {
            var info = GetExcelFilesInfo(pathToRaports);
            WriteToXml(info);
        }

        private void WriteToXml(Dictionary<string, List<Tuple<string, double>>> info)
        {
            XmlWriter writer = XmlWriter.Create("Sales-by-Vendors-report.xml");

            using (writer)
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("sales");
                foreach (var vendor in info)
                {
                    writer.WriteStartElement("sale");
                    writer.WriteAttributeString("vendor", vendor.Key);

                    foreach (var sale in vendor.Value)
                    {
                        writer.WriteStartElement("summary");
                        writer.WriteAttributeString("date", sale.Item1);
                        writer.WriteAttributeString("total-sum", sale.Item2.ToString());
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            }
        }

        private Dictionary<string, List<Tuple<string, double>>> GetExcelFilesInfo(string dirPath)
        {
            var SalesInfo = new Dictionary<string, List<Tuple<string, double>>>();
            string[] dirs = Directory.GetDirectories(dirPath);
            foreach (var dir in dirs)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dir);
                var date = dirInfo.Name;
                var files = dirInfo.GetFiles();
                foreach (var file in files)
                {
                    var sumAndName = GetSumAndName(dirPath + "\\" + dirInfo.Name + "\\" + file.Name, "sales");
                    var sum = sumAndName.Item1;
                    var fileName = sumAndName.Item2;

                    if(SalesInfo.ContainsKey(fileName))
                    {
                        SalesInfo[fileName].Add(new Tuple<string, double>(date, sum));
                    }
                    else
                    {
                        SalesInfo.Add(fileName, new List<Tuple<string, double>>() { new Tuple<string, double>(date, sum) });
                    }
                }
            }

            return SalesInfo;
        }

        private Tuple<double, string> GetSumAndName(string filename, string sheetName)
        {
            foreach (string connectionStringBase in new[] 
                {
                    "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0;",
                    "Provider=Microsoft.Jet.OLEDB.4.0;Data source={0};Extended Properties=Excel 8.0;"
                })
            {
                try
                {
                    string connectionString = String.Format(connectionStringBase, filename);
                    OleDbDataAdapter adapter = new OleDbDataAdapter(String.Format("select * from [{0}$]", sheetName), connectionString);
                    DataSet dataset = new DataSet();
                    adapter.Fill(dataset, "test");

                    DataTable table = dataset.Tables["test"];

                    return GenerateSumAndName(table);
                }
                catch (Exception)
                {
                    // Try next 
                }
            }

            throw new ArgumentOutOfRangeException("filename", "File does not contain import data in a known format.");
        }

        private Tuple<double, string> GenerateSumAndName(DataTable table)
        {
            var tableRows = table.Rows;
            var lastRow = tableRows[tableRows.Count - 1];
            var name = tableRows[0].ItemArray[0];

            var totalSum = double.Parse(lastRow.ItemArray.Last().ToString());

            return new Tuple<double, string>(totalSum, name.ToString());
        }
    }
}
