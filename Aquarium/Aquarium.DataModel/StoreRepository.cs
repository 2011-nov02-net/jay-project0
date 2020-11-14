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
            var appInv = GetStoreInventory(appStore);
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
            var appInventory = new Dictionary<string, int>();
            foreach ( var thing in dbInventory)
            {
                appInventory.Add(thing.Animal.Name, thing.Quantity);
            }
            return appInventory;
        }
    }
}
