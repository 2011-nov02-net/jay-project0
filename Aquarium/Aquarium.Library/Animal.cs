using System;
using System.Collections.Generic;
using System.Text;

namespace Aquarium.Library
{
    public class Animal
    {   
        public Animal(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
        public decimal Price { get; private set; }
        public string Name { get; }
    }
}