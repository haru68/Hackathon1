using System;
using System.Collections.Generic;
using System.Text;

namespace EcoConception
{
    public class Product
    {
        public int Id { get; set; }
        public Decimal Price { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public bool isFemale { get; set; }
        public bool hasTeeth { get; set; }
        public int age { get; set; }
        public bool hasOxygenBottle { get; set; }
        public bool isIncontinent { get; set; }
        public bool isHandicaped { get; set; }
        public string Photo { get; set; }
        public Category Category { get; set; }


    }
}