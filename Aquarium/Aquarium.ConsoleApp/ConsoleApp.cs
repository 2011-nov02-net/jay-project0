using System;
using Aquarium.Library;
using Aquarium.DataModel;
using System.Linq;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Aquarium.ConsoleApp
{
    public class ConsoleApp
    {
        public ConsoleApp()
        {
            using var logStream = new StreamWriter("ef-logs.txt");
            var connect = System.IO.File.ReadAllText("connection.txt");

            var optionsBuilder = new DbContextOptionsBuilder<AquariumContext>();
            optionsBuilder.UseSqlServer(connect);
            optionsBuilder.LogTo(logStream.Write, LogLevel.Information);
            var s_dbContextOptions = optionsBuilder.Options;

            var StoreRepo = new StoreRepository(s_dbContextOptions);
        }
        public StoreRepository StoreRepo { get; set; }
        // Read
        public void GetStore(string city)
        {
            StoreRepo.GetStoreByCity(city);
        }
        public void GetStoreOrders(Library.Store store)
        {
            StoreRepo.GetStoreOrders(store);
        }
        public void GetCustomerByName(string lastname, string firstname)
        {
            StoreRepo.GetCustomerByName(lastname, firstname);
        }
        public void GetCustOrders(Library.Customer customer)
        {
            StoreRepo.GetCustOrders(customer);
        }
        // Create
        public void AddToInventory(string city, string name, int stock)
        {
            StoreRepo.AddToInventoryDb(city, name, stock);
        }
        public void RemoveFromInventory(int storeid, int animalid, int quantity)
        {
            StoreRepo.RemoveFromInventoryDb(storeid, animalid, quantity);
        }
        // Update
        public void UpdateInventory(string city, string name, int stock)
        {
            StoreRepo.UpdateInventoryDb(city, name, stock);
        }
        // Delete
    }
}
