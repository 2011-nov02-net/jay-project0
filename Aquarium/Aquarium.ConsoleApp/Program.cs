using System;
using Aquarium.Library;

namespace Aquarium.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console inputs to see flow of application, will remove later
            // New store location created with animals
            var nyc = new Store("nyc");
            var whale = new Animal("whale", 1500.00);
            var penguin = new Animal("penguin", 60.00);
            nyc.AddToInventory("whale", 100);
            nyc.AddToInventory("penguin", 500);

            var Jay = new Customer("S", "Jay", "jay@email.com");

            Console.WriteLine($"Type {"e"} if you are an employee or {"c"} if you are a customer.");
            string userLogin = Console.ReadLine();
            // Employee portal
            if (userLogin == "e")
            {
                var result = nyc.GetInventory();
                Console.Write(result[0]); // returns penguin name property "penguin"
                nyc.AddToInventory("penguin", 100); // Adds 10 penguins to the penguin.Stock property
            }
            // Customer portal
            else if (userLogin == "c")
            {
                Console.WriteLine("Are you a previous customer? y/n");
                string userInput = Console.ReadLine();
                if (userInput == "y")
                {
                    Console.WriteLine("Please input your registered email");
                    string input1 = Console.ReadLine();
                }
                else if (userInput == "n")
                {
                    Console.WriteLine("Please register before placing an order. What is your first name?");
                }
            }
        }
    }
}