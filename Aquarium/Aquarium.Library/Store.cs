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
        // Checks if animal exists in current inventory then adds the quantity
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
                Console.WriteLine($"{inv.Key.Name} - {String.Format("{0:C}", inv.Key.Price)} - {inv.Value}");
            }
        }
        // check  inventory for existing animal and whether quantity is possible
        public bool RemoveFromInventory(Animal animal, int quantity)
        {
            foreach(KeyValuePair<Library.Animal, int> inv in Inventory)
            {
                if (inv.Key.Name == animal.Name){
                    if (quantity < inv.Value) {
                        return true;
                    }
                    else return false;
                }
            }
            return false;
        }
        public bool InInventory(Animal animal)
        {
            return (Inventory.ContainsKey(animal) && Inventory[animal] > 0);
        }
    }
}