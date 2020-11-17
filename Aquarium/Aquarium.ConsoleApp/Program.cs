﻿using System;
using Aquarium.Library;
using Aquarium.DataModel;
using System.Linq;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Aquarium.ConsoleApp
{
    class Program
    {
        public static ConsoleApp Current = new ConsoleApp();
        static void Main(string[] args)
        {
            bool online = true;
            while (online)
            {
                LocationMenu();
                var CurrentLocation = SetStore();
                EmployeeMenu(CurrentLocation);
                var input = LocationInput(CurrentLocation);
                MenuInput(input, CurrentLocation);
            }
        }
        public static void LocationMenu()
        {
            Console.WriteLine("Welcome to the Aquarium.");
            Console.WriteLine("Please input store location based on the following options:");
            Console.WriteLine("(1) New York City, USA");
            Console.WriteLine("(2) Seoul, Korea");
            // Console.WriteLine("(x) Cancel and exit app");
        }
        public static Library.Store SetStore()
        {
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    return Current.GetStore("Nyc");
                case "2":
                    return Current.GetStore("Seoul");
                default:
                    Console.WriteLine("Please try again.");
                    return SetStore();
            }
        }
        public static void EmployeeMenu(Library.Store store)
        {
            Console.WriteLine($"You are now at the {store.City} store. What would you like to access?");
            Console.WriteLine("(1) Store service");
            Console.WriteLine("(2) Customer service");
            Console.WriteLine("(3) Order service");
            Console.WriteLine("(4) Animal service");
        }
        public static string LocationInput(Library.Store store)
        {
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    StoreMenu();
                    return "1";
                case "2":
                    CustomerMenu();
                    return "2";
                case "3":
                    OrderMenu();
                    return "3";
                case "4":
                    AnimalMenu();
                    return "4";
                default:
                    Console.WriteLine("Please try again.");
                    return LocationInput(store);
            }
        }
        public static void StoreMenu()
        {
            Console.WriteLine("You've accessed the store menu. Please pick one of the following options");
            Console.WriteLine("(1) Get store inventory");
            Console.WriteLine("(2) Modify existing store inventory");
            Console.WriteLine("(3) Get all orders made at this store");
            // Console.WriteLine("(4) Delete from store inventory");
            // Console.WriteLine("(5) Go back to a previous option");
        }
        public static void CustomerMenu()
        {
            Console.WriteLine("You've accessed the customer menu. Please pick one of the following options");
            Console.WriteLine("(1) Find customer by name");
            Console.WriteLine("(2) Create a new customer");
            Console.WriteLine("(3) Modify an existing customer");
            // Console.WriteLine("(4) Go back to a previous option");
        }
        public static void OrderMenu()
        {
            Console.WriteLine("You've accessed the order menu. Please pick one of the following options");
            Console.WriteLine("(1) Find orders by store");
            Console.WriteLine("(2) Find orders by customer");
            Console.WriteLine("(3) Create a new order");
            // Console.WriteLine("(4) Modify an existing order");
            // Console.WriteLine("(5) Go back to a previous option");
        }
        public static void AnimalMenu()
        {
            Console.WriteLine("You've accessed the animal menu. Please pick one of the following options");
            Console.WriteLine("(1) Find animal by name");
            Console.WriteLine("(2) Add a new animal");
            // Console.WriteLine("(3) Modify an existing animal");
            // Console.WriteLine("(4) Go back to a previous option");
        }
        public static void MenuInput(string input, Library.Store location)
        {
            switch(input)
            {
                case "1":
                    StoreInput(location);
                    break;
                case "2":
                    CustomerInput(location);
                    break;
                case "3":
                    OrderInput(location);
                    break;
                default:
                    Console.WriteLine("Please try again.");
                    MenuInput(input, location);
                    break;
            }
        }
        public static void StoreInput(Library.Store store)
        {
            var input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    Console.WriteLine($"Searching for all animals at store location ({store.City}).");
                    store.GetStoreInventory();
                    break;
                case "2":
                    Console.WriteLine($"Updating current store inventory. Here is a list of all animals and their quantity at store location ({store.City}). Please type name of animal.");
                    store.GetStoreInventory();
                    input = Console.ReadLine();
                    var CurrentAnimal = Current.GetAnimalByName(input);
                    Console.WriteLine($"How many {CurrentAnimal}s would you like to insert?");
                    var input2 = Console.ReadLine();
                    var quantityInt = Int32.Parse(input2);
                    store.AddToInventory(CurrentAnimal, quantityInt);
                    Current.UpdateInventory(store.City, CurrentAnimal, quantityInt);
                    Console.WriteLine($"{CurrentAnimal.Name} with a quantity of {input2} has been inserted.");
                    break;
                case "3":
                    Console.WriteLine($"Searching for all orders made at store location ({store.City}).");
                    var StoreOrders = Current.GetStoreOrders(store);
                    Console.WriteLine($"Found {StoreOrders.Count} result(s):");
                    foreach (var order in StoreOrders)
                    {
                        order.GetOrderInfo();
                    }
                    break;
                default:
                    Console.WriteLine("Please try again.");
                    StoreInput(store);
                    break;
            }
        }

        public static void CustomerInput(Library.Store store)
        {
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("Find customer by name. Please input the customer's email");
                    input = Console.ReadLine();
                    var ExistingCust = Current.GetCustomerByEmail(input);
                    ExistingCust.GetCustomerInfo();
                    break;
                case "2":
                    Console.WriteLine("Create a new customer. Please input new customer's first name");
                    var newCust = new Library.Customer();
                    input = Console.ReadLine();
                    newCust.FirstName = input;
                    Console.WriteLine("Please input new customer's last name");
                    var input2 = Console.ReadLine();
                    newCust.LastName = input2;
                    Console.WriteLine("Please input new customer's E-mail address.");
                    var input3 = Console.ReadLine();
                    newCust.Email = input3;
                    Console.WriteLine($"Customer has been created with these details:");
                    Current.CreateCustomer(newCust);
                    newCust.GetCustomerInfo();
                    break;
                case "3":
                    Console.WriteLine("Modify an existing customer. Please input the customer's email");
                    input = Console.ReadLine();
                    var CurrentCust = Current.GetCustomerByEmail(input);
                    Console.WriteLine("Customer found. Input customer's new email");
                    CurrentCust.Email = Console.ReadLine();
                    Current.UpdateCustomer(CurrentCust);
                    Console.WriteLine($"New Email: {CurrentCust.Email} has been saved.");
                    break;
                default:
                    Console.WriteLine("Please try again.");
                    CustomerInput(store);
                    break;
            }
        }
        public static void OrderInput(Library.Store store)
        {
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine($"Searching for all orders made in store location ({store.City}).");
                    var StoreOrders = Current.GetStoreOrders(store);
                    Console.WriteLine($"Found {StoreOrders.Count} result(s):");
                    foreach(var order in StoreOrders)
                    {
                        order.GetOrderInfo();
                    }
                    break;
                case "2":
                    Console.WriteLine("Searching for all orders made by a specific customer. Please input customer's email");
                    input = Console.ReadLine();
                    var CurrentCust = Current.GetCustomerByEmail(input);
                    Console.WriteLine($"Searching for all orders for {CurrentCust.FirstName}, {CurrentCust.LastName}...");
                    var CustOrders = Current.GetCustOrders(CurrentCust);
                    Console.WriteLine($"Found {CustOrders.Count} result(s):");
                    foreach (var order in CustOrders)
                    {
                        order.GetOrderInfo();
                    }
                    break;
                case "3":
                    Console.WriteLine($"Creating a new order in store location ({store.City}). Please input customer's email");
                    input = Console.ReadLine();
                    var NewOrder = new Library.Order();
                    NewOrder.Customer = Current.GetCustomerByEmail(input);
                    Console.WriteLine($"Input name of the animal for this purchase. Our store location at ({store.City}) has:");
                    store.GetStoreInventory();
                    var animalNameInput = Console.ReadLine(); // Need to check if animal name exists
                    NewOrder.Animal = Current.GetAnimalByName(animalNameInput);
                    Console.WriteLine($"How many {animalNameInput}s for purchase?");
                    var QuantityInput = Console.ReadLine(); // Need to check if store has enough animals in inventory
                    NewOrder.Quantity = Int32.Parse(QuantityInput);
                    NewOrder.StoreId = store.StoreId;
                    NewOrder.Date = DateTime.Now;
                    NewOrder.GetTotal();
                    Console.WriteLine("Order created. Order receipt:");
                    Current.CreateOrder(NewOrder);
                    NewOrder.GetOrderInfo();
                    break;
                default:
                    Console.WriteLine("Please try again.");
                    OrderInput(store);
                    break;
            }
        }
    }
}