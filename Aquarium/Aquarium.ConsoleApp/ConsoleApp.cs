using System;
using System.Collections.Generic;
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
        public List<Library.Order> GetStoreOrders(Library.Store store)
        {
           return StoreRepo.GetStoreOrders(store);
        }
        public List<Library.Order> GetCustOrders(Library.Customer customer)
        {
            return StoreRepo.GetCustOrders(customer);
        }
        public Library.Order GetOrderById(int id)
        {
            return StoreRepo.GetOrderById(id);
        }
        public Library.Customer GetCustomerByEmail(string email)
        {
            return StoreRepo.GetCustomerByEmail(email);
        }
        public Library.Animal GetAnimalByName(string name)
        {
            return StoreRepo.GetAnimalByName(name);
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
        public void CreateOrder(Library.Order order){
            StoreRepo.AddToOrderDb(order);
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
