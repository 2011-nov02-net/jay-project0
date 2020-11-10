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
        // Private fields
        public decimal Price { get; private set; }
        // Getters
        public string Name { get; }
        // Methods
    }
}