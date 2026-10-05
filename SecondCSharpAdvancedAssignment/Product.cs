using System;
using System.Collections.Generic;
using System.Text;

namespace SecondCSharpAdvancedAssignment
{
    public delegate void product(string s);
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; } // "Electronics", "Clothing", "Food", "Books"
        public double Price { get; set; }
        public int Stock { get; set; }



       
    }
}
