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
        public StoreRepository StoreRepo { get; set; }
        public ConsoleApp()
        {
            // using var logStream = new StreamWriter("ef-logs.txt");
            var connect = System.IO.File.ReadAllText("connection.txt");

            var optionsBuilder = new DbContextOptionsBuilder<AquariumContext>();
            optionsBuilder.UseSqlServer(connect);
            // optionsBuilder.LogTo(logStream.Write, LogLevel.Information);
            var s_dbContextOptions = optionsBuilder.Options;

            StoreRepo = new StoreRepository(s_dbContextOptions);
        }
        // Read
        public Library.Store GetStore(string city)
        {
            return StoreRepo.GetStoreByCity(city);
        }
        public void GetStoreOrders(Library.Store store)
        {
            StoreRepo.GetStoreOrders(store);
        }
        public void GetCustOrders(Library.Customer customer)
        {
            StoreRepo.GetCustOrders(customer);
        }
        public void GetOrderById(int id)
        {
            StoreRepo.GetOrderById(id);
        }
        public void GetCustomerByName(string lastname, string firstname)
        {
            StoreRepo.GetCustomerByName(lastname, firstname);
        }
        public void GetAnimalByName(string name)
        {
            Console.WriteLine("test");
            StoreRepo.GetAnimalByName(name);
        }
        // Create
        public void CreateInventory(string city, string name, int stock)
        {
            StoreRepo.AddToInventoryDb(city, name, stock);
        }
        public void CreateCustomer(Library.Customer customer)
        {
            StoreRepo.AddToCustomerDb(customer);
        }
        public void CreateAnimal(Library.Animal animal)
        {
            StoreRepo.AddToAnimalDb(animal);
        }
        // Update
        public void UpdateInventory(string city, string name, int stock)
        {
            StoreRepo.UpdateInventoryDb(city, name, stock);
        }
        public void UpdateOrder(Library.Order order)
        {
            StoreRepo.UpdateOrderDb(order);
        }
        public void UpdateCustomer(Library.Customer customer)
        {
            StoreRepo.UpdateCustomerDb(customer);
        }
        public void UpdateAnimal(Library.Animal animal)
        {
            StoreRepo.UpdateAnimalDb(animal);
        }
        // Delete
        public void RemoveFromInventory(int storeid, int animalid, int quantity)
        {
            StoreRepo.RemoveFromInventoryDb(storeid, animalid, quantity);
        }
    }
}
