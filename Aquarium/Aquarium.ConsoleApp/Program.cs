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
                ServiceInput(CurrentLocation);
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
            switch(input)
            { 
                case "1":
                    return Current.GetStore("Nyc");
                case "2":
                    return Current.GetStore("Seoul");
            }
            Console.WriteLine("Please try again.");
            return LocationInput();
        }
        public static void EmployeeMenu(Library.Store store)
        {
            Console.WriteLine($"You are now at the {store.City} store. What would you like to access?");
            Console.WriteLine("(1) Store service");
            Console.WriteLine("(2) Customer service");
            Console.WriteLine("(3) Order service");
            Console.WriteLine("(4) Animal service");
        }
        public static void ServiceInput(Library.Store store)
        {
            var input = Console.ReadLine();
            switch(input)
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
            }
            Console.WriteLine("Please try again.");
            ServiceInput(store);
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
    }
}