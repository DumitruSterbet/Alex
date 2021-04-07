using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alex.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
