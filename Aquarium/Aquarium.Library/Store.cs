using System;
using System.Collections.Generic;

namespace Aquarium.Library
{
    public class Store
    {
        // Constructor
        public Store(string location)
        {
            _location = location;
            _inventory = new Dictionary<string, Animal>();
        }
        // Private fields
        private string _location;
        private Dictionary<string, Animal> _inventory;
        // Methods
        public void AddToInventory(string name, Animal animal)
        {
            _inventory.Add(name, animal);
        }
        public List<string> GetInventory()
        {
             var result = new List<string>();
             foreach (KeyValuePair<string, Animal> animal in _inventory)
             {
                result.Add(animal.Value.Name);
             }
             return result;
 
        }
        public string SearchInventory(string animalName)
        {
            if (_inventory.ContainsKey(animalName))
            {
                var animal = _inventory[animalName];
                return $"There are {animal.Stock} {animal.Name}(s) in stock.";
            }
            else
            {
                return "Animal not found";
            }
        }
    }
}