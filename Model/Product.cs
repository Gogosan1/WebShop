using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Model
{
    public class Product
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public double QuantityAccordingToUnit { get; set; }
        public string Unit { get; set; }

        public Product(int id, string name, double quantity, string unit) 
        {
            Id = id;
            Name = name;
            QuantityAccordingToUnit = quantity;
            Unit = unit;
        }
    }
}
