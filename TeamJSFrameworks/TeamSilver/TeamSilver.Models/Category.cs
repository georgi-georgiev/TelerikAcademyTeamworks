using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamSilver.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }

        public Category()
        {
            this.Products = new HashSet<Product>();
        }
    }
}
