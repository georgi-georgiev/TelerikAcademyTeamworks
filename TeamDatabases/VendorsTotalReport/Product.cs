using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace VendorsTotalReport
{
    public class Product
    {
        public ObjectId _id { get; set; }
        public string ProductName { get; set; }
        public string VendorName { get; set; }
        public int Quantity { get; set; }
        public double Incomes { get; set; }
    }
}
