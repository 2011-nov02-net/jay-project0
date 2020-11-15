using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Aquarium.Library;

namespace Aquarium.DataModel
{
    public class StoreRepository : IStoreRepository
    {
        private readonly DbContextOptions<AquariumContext> _contextOptions;
        public StoreRepository(DbContextOptions<AquariumContext> contextOptions)
        {
            _contextOptions = contextOptions;
        }
        public Library.Store GetStoreByCity(string city)
        {
            using var context = new AquariumContext(_contextOptions);
            var dbStore = context.Stores
                .Where(s => s.City == city)
                .First();
            var appStore = new Library.Store()
            {
                StoreId = dbStore.StoreId,
                City = dbStore.City,
                Country = dbStore.Country,
                Inventory = new Dictionary<string, int>()
            };
            var appInv = GetStoreInventory(appStore); // Seperate method to get a dictionary of animal name and quantity in the inventory
            foreach (var thing in appInv)
            {
                appStore.Inventory.Add(thing.Key, thing.Value);
            }
            return appStore;
        }

        public Dictionary<string, int> GetStoreInventory(Library.Store store)
        {
            using var context = new AquariumContext(_contextOptions);
            var dbInventory = context.Inventories
                .Where(i => i.StoreId == store.StoreId)
                .Include(i => i.Animal)
                .ToList();
            var appInventory = new Dictionary<string, int>(); // Converts dbInventory from a list to a pair of name and quantity per row
            foreach ( var thing in dbInventory)
            {
                appInventory.Add(thing.Animal.Name, thing.Quantity);
            }
            return appInventory;
        }
        public void AddToInventory(string city, string name, int stock)
        {
            using var context = new AquariumContext(_contextOptions);
            // Checks to see if animal exists in database already
            bool animalExist = context.Animals
                .Any(a => a.Name == name);
            if(!animalExist)
            {
                Console.WriteLine("Animal does not exist in database. Please update the animal database");
            }
            else
            {
                var currentStore = GetStoreByCity(city);
                currentStore.AddToInventory(name, stock);
                // Checks to see if animal exists in current store inventory, and if it does update it
                bool inventoryExist = context.Inventories
                    .Include(i => i.Animal)
                    .Any(i => i.StoreId == currentStore.StoreId && i.Animal.Name == name);
                if (inventoryExist) {
                    var dbInventory = context.Inventories
                        .Include(i => i.Animal)
                        .Where(i => i.StoreId == currentStore.StoreId && i.Animal.Name == name)
                        .First();
                    dbInventory.Quantity += stock;
                }
                else
                {
                    // Since it does not exist we create a new entry in the inventory instead of updating an existing one
                    var dbAnimal = context.Animals
                        .Where(a => a.Name == name).First();
                    var newEntry = new DataModel.Inventory()
                    {
                        StoreId = currentStore.StoreId,
                        AnimalId = dbAnimal.AnimalId,
                        Quantity = stock
                    };
                    context.Inventories.Add(newEntry);
                };
            }
            context.SaveChanges();
        }
    }
}