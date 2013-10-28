using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ImportToSQLServer
{
    class ReadFromMySqlWithOpenAccess
    {
        public List<Product> ProductsTable { get; set; }

        public List<Measure> MeasuresTable { get; set; }

        public List<Vendor> VendorsTable { get; set; }

        public ReadFromMySqlWithOpenAccess()
        {
            using (var context = new EntitiesModel())
            {
                ProductsTable = context.Products.ToList();
                MeasuresTable = context.Measures.ToList();
                VendorsTable = context.Vendors.ToList();
            }
        }
    }
}
