using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alex.JoinModels
{
    public class WithCountryName
    {

    
            public int Id { set; get; }
            public string Name { get; set; }
            public int Quantity { get; set; }
            public int Price { get; set; }
            public string Country { get; set; }

        
    }
}
