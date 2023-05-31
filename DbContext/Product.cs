using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.DbContext
{
    public class Product
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public decimal discountPercentage { get; set; }
        public decimal rating { get; set; }
        public int stock { get; set; }
        public int category { get; set; }
        public string brand { get; set; }
        public string thumbnail { get; set; }
        public List<String> images { get; set; }


    }

    public class ProductsVM
    {
        public List<Product> products { get; set; }

        public int total { get; set; }

        public int skip { get; set; }

        public int limit { get; set; }
    }
}
