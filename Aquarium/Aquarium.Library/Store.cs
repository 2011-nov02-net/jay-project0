using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace Aquarium.Library
{
    public class Store
    {
        // Constructor
        public Store(string location)
        {   
            Location = location;
            Inventory = new Dictionary<string, int>();
            // Finds filepath, then creates new serialize object to serialize this store object to json
            var jsonSerial = new JsonSerial(_storePath);
            jsonSerial.WriteJson(this);
        }
        private string _storePath = @"../Aquarium.Data/store.json"; // Temporary until I figure out proper format
        public string Location { get; }
        public Dictionary<string, int> Inventory { get; private set; }
        // Methods
        public List<string> GetInventory()
        {
            var result = new List<string>();
            foreach (KeyValuePair<string, int> animal in Inventory)
            {
                result.Add($"{animal.Key} - {animal.Value}");
            }
            return result;
        }
        public void AddToInventory(string name, int stock)
        {
            if (Inventory.ContainsKey(name))
            {
                Inventory[name] += stock;
            }
            else
            {
                Inventory.Add(name, stock);
            }
            var jsonSerial = new JsonSerial(_storePath);
            jsonSerial.WriteJson(this);
        }
        public void RemoveFromInventory(string name, int stock)
        { 
             Inventory[name] -= stock;
        }
        public string SearchInventory(string animalName)
        {
            if (Inventory.ContainsKey(animalName))
            {
                var animalQuantity = Inventory[animalName];
                return $"There are {animalQuantity} {animalName}(s) in stock.";
            }
            else
            {
                return "Animal not found";
            }
        }
    }
}