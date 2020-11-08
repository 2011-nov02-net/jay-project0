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
            _name = name;
            _stock = stock;
            _price = price;

        }
        // Private fields
        private string _name;
        private int _stock;
        private double _price;
        // Getters
        public string Name
        {
            get
            {
                return _name;
            }
        }
        public int Stock
        {
            get
            {
                return _stock;
            }
        }
        public double Price
        {
            get
            {
                return _price;
            }
        }
        // Methods
        public void AddAnimal(int amount)
        {
            _stock += amount;
        }
        public void SellAnimal(int amount)
        {
            if (amount > _stock) 
            {
                Console.Write($"Not enough {_name} in stock!");
            } 
            else 
            {
                _stock -= amount;
            }
        }
    }
}