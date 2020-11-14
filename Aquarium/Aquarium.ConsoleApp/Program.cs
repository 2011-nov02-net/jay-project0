﻿using System;
using Aquarium.Library;

namespace Aquarium.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console inputs to see flow of application, will remove later
            // New store object created
            var nyc = new Store("nyc");
            // New animal objects created
            var whale = new Animal("whale", 1500.00m);
            var penguin = new Animal("penguin", 60.00m);
            nyc.AddToInventory("whale", 100);
            nyc.AddToInventory("penguin", 500);
            nyc.AddToInventory("penguin", 333330);

            var Jay = new Customer("Shin", "Jay", "jay@email.com");

            Console.WriteLine($"Type {"e"} if you are an employee or {"c"} if you are a customer.");
            string userLogin = Console.ReadLine();
            // Employee portal
            if (userLogin == "e")
            {
                var result = nyc.GetInventory();
                // Console.Write(result[0]); // returns penguin name property "penguin"
                nyc.AddToInventory("penguin", 100); // Adds 10 penguins to the penguin.Stock property
                var newOrder = new Order(nyc, Jay, whale, 10);
                newOrder.AddToCart(penguin, 19);
                Console.Write(newOrder.CheckoutCart());
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