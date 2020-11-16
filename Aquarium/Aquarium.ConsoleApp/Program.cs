using System;
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
                var CurrentLocation = LocationInput();
                EmployeeMenu(CurrentLocation);
                LocationInput(CurrentLocation);
                var CurrentCustomer = CustomerInput(CurrentLocation);
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
        public static Library.Store LocationInput()
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
                    return LocationInput();
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
        public static void LocationInput(Library.Store store)
        {
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    StoreMenu();
                    break;
                case "2":
                    CustomerMenu();
                    break;
                case "3":
                    OrderMenu();
                    break;
                case "4":
                    AnimalMenu();
                    break;
                default:
                    LocationInput(store);
                    break;
            }
        }
        public static void StoreMenu()
        {
            Console.WriteLine("You've accessed the store menu. Please pick one of the following options");
            Console.WriteLine("(1) Get store inventory");
            Console.WriteLine("(2) Create new store inventory");
            Console.WriteLine("(3) Modify an existing store inventory");
            Console.WriteLine("(4) Delete from store inventory");
            Console.WriteLine("(5) Go back to a previous option");
        }
        public static void CustomerMenu()
        {
            Console.WriteLine("You've accessed the customer menu. Please pick one of the following options");
            Console.WriteLine("(1) Find customer by name");
            Console.WriteLine("(2) Create a new customer");
            Console.WriteLine("(3) Modify an existing customer");
            Console.WriteLine("(4) Go back to a previous option");
        }
        public static void OrderMenu()
        {
            Console.WriteLine("You've accessed the order menu. Please pick one of the following options");
            Console.WriteLine("(1) Find orders by store");
            Console.WriteLine("(2) Find orders by customer");
            Console.WriteLine("(3) Create a new order");
            Console.WriteLine("(4) Modify an existing order");
            Console.WriteLine("(5) Go back to a previous option");
        }
        public static void AnimalMenu()
        {
            Console.WriteLine("You've accessed the animal menu. Please pick one of the following options");
            Console.WriteLine("(1) Find animal by name");
            Console.WriteLine("(2) Add a new animal");
            Console.WriteLine("(3) Modify an existing animal");
            Console.WriteLine("(4) Go back to a previous option");
        }

        public static Library.Customer CustomerInput(Library.Store store)
        {
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("Find customer by name. Please input the customer's first name");
                    input = Console.ReadLine();
                    Console.WriteLine("Please input the customer's last name");
                    var input2 = Console.ReadLine();
                    var ExistingCust = Current.GetCustomerByName(input, input2);
                    Console.WriteLine($"First name: {ExistingCust.FirstName}");
                    Console.WriteLine($"Last name: {ExistingCust.LastName}");
                    Console.WriteLine($"Email Address: {ExistingCust.Email}");
                    return ExistingCust;
                case "2":
                    Console.Write("Create a new customer. Please input new customer's first name");
                    var newCust = new Library.Customer();
                    newCust.FirstName = Console.ReadLine();
                    Console.Write("Please input new customer's last name");
                    newCust.LastName = Console.ReadLine();
                    Console.WriteLine("Please input new customer's E-mail address. If none, press enter");
                    newCust.Email = Console.ReadLine();
                    Console.WriteLine($"First name: {newCust.FirstName} , Last name: {newCust.LastName} , Email: {newCust.Email} has been created.");
                    Current.CreateCustomer(newCust);
                    return newCust;
                case "3":
                    Console.WriteLine("Modify an existing customer. Please input the customer's first name");
                    input = Console.ReadLine();
                    Console.WriteLine("Please input the customer's last name");
                    input2 = Console.ReadLine();
                    var CurrentCust = Current.GetCustomerByName(input, input2);
                    Console.WriteLine("Customer found. Input customer's new email");
                    CurrentCust.Email = Console.ReadLine();
                    Current.UpdateCustomer(CurrentCust);
                    Console.WriteLine($"New Email: {CurrentCust.Email} has been saved.");
                    return CurrentCust;
                default:
                    Console.WriteLine("Please try again.");
                    return CustomerInput(store);
            }
        }
    }
}