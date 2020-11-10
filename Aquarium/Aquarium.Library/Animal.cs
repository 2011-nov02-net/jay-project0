using System;
using System.Collections.Generic;
using System.Text;

namespace Aquarium.Library
{
    public class Animal
    {   
        // Constructor
        public Animal(string name, double price)
        {
            Name = name;
            _price = price;

        }
        // Private fields
        private double _price;
        // Getters
        public string Name { get; }
        // Methods
    }
}