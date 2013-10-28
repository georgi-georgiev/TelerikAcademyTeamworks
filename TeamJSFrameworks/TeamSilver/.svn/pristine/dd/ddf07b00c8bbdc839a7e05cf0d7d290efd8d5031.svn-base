using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSilver.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCreation { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Manufacturer { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public Product()
        {
            this.Users = new HashSet<User>();
        }
    }
}
