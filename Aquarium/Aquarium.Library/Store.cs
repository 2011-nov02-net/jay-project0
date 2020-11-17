using System;
using System.Collections.Generic;

namespace Aquarium.Library
{
    public class Store
    {
        // Constructor
        public int StoreId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public Dictionary<Animal, int> Inventory { get; set; }
        public void AddToInventory(Animal animal, int stock)
        {
            if (InInventory(animal))
            {
                Inventory[animal] += stock;
            }
            else
            {
                Inventory.Add(animal, stock);
            }
        }
        public void GetStoreInventory() {
            foreach (var inv in Inventory)
            {
                Console.WriteLine($"{inv.Key.Name} - {inv.Value}");
            }
        }
        public bool RemoveFromInventory(Animal animal, int stock)
        {
            if (stock > Inventory[animal]) {
                    return false;
            }
            Inventory[animal] -= stock;
            return true;
        }
        public bool InInventory(Animal animal)
        {
            if (!(Inventory.ContainsKey(animal)))
            {
                return false;
            }
            return true;
        }
    }
}