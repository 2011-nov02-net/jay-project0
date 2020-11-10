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
            _inventory = new Dictionary<string, int>();
        }
        // Private fields
        private string _location;
        private Dictionary<string, int> _inventory;
        // Methods
        public void AddToInventory(string name, int stock)
        {
            if (_inventory.ContainsKey(name))
            {
                _inventory[name] += stock;
            }
            else
            {
                _inventory.Add(name, stock);
            }
        }
        public void RemoveFromInventory(string name, int stock)
        { 
             _inventory[name] -= stock;
        }
        public List<string> GetInventory()
        {
             var result = new List<string>();
             foreach (KeyValuePair<string, int> animal in _inventory)
             {
                result.Add($"{animal.Key} - {animal.Value}");
             }
             return result;
 
        }
        public string SearchInventory(string animalName)
        {
            if (_inventory.ContainsKey(animalName))
            {
                var animalQuantity = _inventory[animalName];
                return $"There are {animalQuantity} {animalName}(s) in stock.";
            }
            else
            {
                return "Animal not found";
            }
        }
    }
}