using System;
using Aquarium.Library;

namespace Aquarium.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the aquarium!");
            // Arrange
            var newAnimal = new Animal("Whale", 10, 150.00);
            var nyc = new Store("New York City");
            nyc.AddToInventory("Whale", newAnimal);
            // Act
            var actual = nyc.Inventory["Whale"].Price;
            Console.WriteLine(actual);
        }
    }
}