using System;
using System.Collections.Generic;
using System.Text;

namespace Aquarium.Library
{
    public class Animal
    {   
        // Constructor
        public Animal(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
        public int AnimalId { get; private set; } // For SQL
        public decimal Price { get; private set; }
        public string Name { get; }
    }
}