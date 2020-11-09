using System;
using System.Collections.Generic;
using System.Text;

namespace Aquarium.Library
{
    public class Animal
    {   
        // Constructor
        public Animal(string name, int stock, double price)
        {
            Name = name;
            Stock = stock;
            _price = price;

        }
        // Private fields
        private double _price;
        // Getters
        public string Name { get; }
        public int Stock { get; private set; }
        // Methods
        public void AddAnimal(int amount)
        {
            Stock += amount;
        }
        public void SellAnimal(int amount)
        {
            if (amount > Stock) 
            {
                Console.Write($"Not enough {Name} in stock!");
            } 
            else 
            {
                Stock -= amount;
            }
        }
    }
}