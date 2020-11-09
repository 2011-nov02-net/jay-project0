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
        // Getters
        public string Location { get; }
        public Dictionary<string, Animal> Inventory { get; }
        // Methods
        public void GetInventory()
        {
            foreach (KeyValuePair<string, Animal> animal in _inventory)
            {
                Console.WriteLine(animal.Key);
            }
        }
        public void AddToInventory(string name, Animal animal)
        {
            _inventory.Add(name, animal);
        }
    }
}