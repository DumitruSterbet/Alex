using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alex.Models
{
    public class ProductContext :DbContext
    {
        public DbSet<Country>countries { get; set; }
        public DbSet<Product>products { get; set; }
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
