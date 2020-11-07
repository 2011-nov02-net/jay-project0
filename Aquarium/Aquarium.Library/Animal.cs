using System;
using System.Collections.Generic;
using System.Text;

namespace Aquarium.Library
{
    public class Animal
    {   
        // Constructor
        public Animal(string name, double price, int stock)
        {
            _name = name;
            _price = price;
            _stock = stock;
        }
        // Private fields
        private string _name;
        private double _price;
        private int _stock;
        // Getters
        public string Name
        {
            get
            {
                return _name;
            }
        }
        public double Price
        {
            get
            {
                return _price;
            }
        }
        public int Stock
        {
            get
            {
                return _stock;
            }
        }
        // Methods
        public void AddAnimal(int amount)
        {
            _stock = _stock + amount;
        }
        public void SellAnimal(int amount)
        {
            if (amount > _stock) 
            {
                Console.Write($"Not enough {_name} in stock!");
            } 
            else 
            {
                _stock = _stock - amount;
            }
        }
    }
}