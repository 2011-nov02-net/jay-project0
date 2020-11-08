using System;
using Xunit;
using Aquarium.Library;
using System.Collections.Generic;

namespace Aquarium.Tests
{
    public class LocationTests
    {
        [Fact]
        public void AddToInventoryTest()
        {
            // Arrange
            var name = "Whale";
            var quantity = 10;
            var price = 150.00;
            var newAnimal = new Animal(name, quantity, price);
            var nyc = new Store("New York City");
            // Act
            nyc.AddToInventory(name, newAnimal);
            // Assert
            var actual = nyc.Inventory["Whale"].Name;
            Assert.True(actual == "Whale");
        }
        [Fact]
        public void GetInventoryTest()
        {
            // Arrange
            var name = "Whale";
            var quantity = 10;
            var price = 150.00;
            var newAnimal = new Animal(name, quantity, price);
            var nyc = new Store("New York City");
            nyc.AddToInventory("Whale", newAnimal);
            // Act
            nyc.GetInventory();
        }
    }
}