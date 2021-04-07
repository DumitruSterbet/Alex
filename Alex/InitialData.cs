using Alex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alex
{
   static public class InitialData
    {
        public static List<Country> countries = new List<Country>
        {
            new Country {Name="Japan",Cod="JP"},
            new Country {Name="SUA",Cod="US"},
            new Country {Name="Moldova",Cod="MD"},
            new Country {Name="Russia",Cod="RS"},
            new Country {Name="Germany",Cod="GR"}
        };

        public static Dictionary<string,Country> DicCountry { get
            {
                Dictionary<string, Country> dic = new Dictionary<string, Country>();
                foreach (var el in countries)
                    dic.Add(el.Cod, el);

                return dic;
            } }

        public static List<Product> products = new List<Product>
        {
            new Product {Name="Phone",Price=300,Quantity=200,Country=DicCountry["JP"]},
             new Product {Name="PC",Price=1000,Quantity=100,Country=DicCountry["US"]},
              new Product {Name="Tablet",Price=250,Quantity=50,Country=DicCountry["RS"]},
               new Product {Name="SmartClock",Price=200,Quantity=1000,Country=DicCountry["GR"]},
                new Product {Name="NoteBook",Price=500,Quantity=50,Country=DicCountry["MD"]},
                 new Product {Name="UltraBook",Price=100,Quantity=700,Country=DicCountry["JP"]}
        };
       public static void Initialize (ProductContext db)
        { if (!db.countries.Any())
                db.countries.AddRange(countries);
            if (!db.products.Any())
                db.products.AddRange(products);

            db.SaveChanges();
        }
    }
}
