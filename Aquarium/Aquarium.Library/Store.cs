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
        // public void AddToInventory(string name, int stock)
        // {
        //     if (Inventory.ContainsKey(name))
        //     {
        //         Inventory[name] += stock;
        //     }
        //     else
        //     {
        //         Inventory.Add(name, stock);
        //     }
        // }
        // public void RemoveFromInventory(string name, int stock)
        // {
        //     if (stock > Inventory[name]) {
        //         Console.WriteLine($"Not enough {name} in stock.");
        //     }
        //     Inventory[name] -= stock;
        // }
        // public string SearchInventory(string animalName)
        // {
        //     if (Inventory.ContainsKey(animalName))
        //     {
        //         var animalQuantity = Inventory[animalName];
        //         return $"There are {animalQuantity} {animalName}(s) in stock.";
        //     }
        //     else
        //     {
        //         return "Animal not found";
        //     }
        // }
    }
}