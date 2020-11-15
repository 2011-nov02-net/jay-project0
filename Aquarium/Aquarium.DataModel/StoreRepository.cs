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
        public void UpdateInventoryDb(string city, string name, int stock)
        {
            using var context = new AquariumContext(_contextOptions);
            // Checks to see if animal exists in database already, move this login to business?
            bool animalExist = context.Animals
                .Any(a => a.Name == name);
            if(!animalExist)
            {
                Console.WriteLine("Animal does not exist in database. Please update the animal database");
            }
            else
            {
                var currentStore = GetStoreByCity(city);
                var dbInventory = context.Inventories
                    .Include(i => i.Animal)
                    .Where(i => i.StoreId == currentStore.StoreId && i.Animal.Name == name)
                    .First();
                dbInventory.Quantity += stock;
                context.SaveChanges();
            }
        }
        public void AddToInventoryDb(string city, string name, int stock)
        {
            using var context = new AquariumContext(_contextOptions);
            var currentStore = GetStoreByCity(city);
            var currentAnimal = GetAnimalByName(name);
            var newEntry = new DataModel.Inventory()
            {
                StoreId = currentStore.StoreId,
                AnimalId = currentAnimal.AnimalId,
                Quantity = stock
            };
            context.Inventories.Add(newEntry);
            context.SaveChanges();
        }
        // Meant to be used to subtract the quantity of the animal from a processed order
        // Not using Library.order object directly since I want the option to remove from inventory even without a new order subtraction
        public void RemoveFromInventoryDb(int storeid, int animalid, int quantity)
        {
            using var context = new AquariumContext(_contextOptions);
            var dbInventory = context.Inventories
                .Where(i => i.StoreId == storeid)
                .Where(i => i.AnimalId == animalid)
                .First();
            dbInventory.Quantity -= quantity;
            context.SaveChanges();
        }
        public void AddToCustomerDb(Library.Customer customer)
        {
            using var context = new AquariumContext(_contextOptions);
            var newCust = new DataModel.Customer()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email
            };
            context.Customers.Add(newCust);
            context.SaveChanges();
        }
        public void UpdateCustomerDb(Library.Customer customer) {
            using var context = new AquariumContext(_contextOptions);
            var dbCust = context.Customers
                .Where(c => c.CustomerId == customer.CustomerId)
                .First();
            dbCust.FirstName = customer.FirstName;
            dbCust.LastName = customer.LastName;
            dbCust.Email = customer.Email;
            context.SaveChanges();
        }
        public Library.Customer GetCustomerByName(string lastname, string firstname)
        {
            using var context = new AquariumContext(_contextOptions);
            var dbCust = context.Customers
                .Where(c => c.LastName == lastname && c.FirstName == firstname)
                .First();
            var appCust = new Library.Customer()
            {
                CustomerId = dbCust.CustomerId,
                LastName = dbCust.LastName,
                FirstName = dbCust.FirstName,
                Email = dbCust.Email
            };
            return appCust;
        }
        // Get orders from the database
        public IEnumerable<Library.Order> GetCustOrders(Library.Customer customer)
        {
            using var context = new AquariumContext(_contextOptions);
            var dbOrders = context.Orders
                .Where(o => o.CustomerId == customer.CustomerId);
            var orders = new List<Library.Order>();
            foreach (var obj in dbOrders)
            {
                orders.Add(GetOrderById(obj.OrderId));
            }
            return orders;
        }
        public IEnumerable<Library.Order> GetStoreOrders(Library.Store store)
        {
            using var context = new AquariumContext(_contextOptions);
            var dbOrders = context.Orders
                .Where(o => o.StoreId == store.StoreId);
            var orders = new List<Library.Order>();
            foreach (var obj in dbOrders)
            {
                orders.Add(GetOrderById(obj.OrderId));
            }
            return orders;
        }
        // Conversion from DataModel.order to Library.Order
        public Library.Order GetOrderById (int id)
        {
            using var context = new AquariumContext(_contextOptions);
            var dbOrders = context.Orders
                .Where(o => o.OrderId == id)
                .Include(o => o.Store)
                .Include(o => o.Customer)
                .Include(o => o.Animal)
                .First();
            var newOrder = new Library.Order
            {
                OrderId = dbOrders.OrderId,
                StoreId = dbOrders.StoreId,
                CustomerId = dbOrders.CustomerId,
                AnimalId = dbOrders.AnimalId,
                Quantity = dbOrders.Quantity,
                Total = dbOrders.Total,
                Date = dbOrders.Date
            };
            return newOrder;
        }
        public void AddToOrderDb(Library.Order order)
        {
            using var context = new AquariumContext(_contextOptions);
            var newEntry = new DataModel.Order
            {
                StoreId = order.StoreId,
                CustomerId = order.CustomerId,
                AnimalId = order.AnimalId,
                Quantity = order.Quantity,
                Total = order.Total,
                Date = order.Date
            };
            context.Orders.Add(newEntry);
            context.SaveChanges();
        }
        public void UpdateOrderDb(Library.Order order)
        {
            using var context = new AquariumContext(_contextOptions);
            var dbOrders = context.Orders
                .Where(o => o.OrderId == order.OrderId)
                .First();
            dbOrders.StoreId = order.StoreId;
            dbOrders.CustomerId = order.CustomerId;
            dbOrders.Date = order.Date;
            dbOrders.AnimalId = order.AnimalId;
            dbOrders.Quantity = order.Quantity;
            dbOrders.Total = order.Total;
            context.SaveChanges();
        }
        public void AddToAnimalDb(Library.Animal animal) {
            using var context = new AquariumContext(_contextOptions);
            var newEntry = new DataModel.Animal
            {
                Name = animal.Name,
                Price = animal.Price
            };
            context.Animals.Add(newEntry);
            context.SaveChanges();
        }
        public Library.Animal GetAnimalByName(string name)
        {
            using var context = new AquariumContext(_contextOptions);
            var dbAnimal = context.Animals
                .Where(a => a.Name == name)
                .FirstOrDefault();
            var newAnimal = new Library.Animal()
            {
                AnimalId = dbAnimal.AnimalId,
                Name = dbAnimal.Name,
                Price = dbAnimal.Price
            };
            return newAnimal;
        }
        public void UpdateAnimalDb(Library.Animal animal) {
            using var context = new AquariumContext(_contextOptions);
            var dbAnimal = context.Animals
                .Where(a => a.AnimalId == animal.AnimalId)
                .First();
            dbAnimal.Name = animal.Name;
            dbAnimal.Price = animal.Price;
            context.SaveChanges();
        }
    }
}