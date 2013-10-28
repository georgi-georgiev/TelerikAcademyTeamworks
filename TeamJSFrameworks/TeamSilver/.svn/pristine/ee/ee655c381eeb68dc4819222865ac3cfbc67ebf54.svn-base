using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamSilver.Models;

namespace TeamSilver.DataLayer
{
    public class StoreContext : DbContext
    {
        public StoreContext()
            : base("StoreDb")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
