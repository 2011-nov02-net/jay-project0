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
            var newAnimal = new Animal(name, price);
            var nyc = new Store("New York City");
            // Act
            nyc.AddToInventory(name, quantity);
            // Assert
            var actual = nyc.SearchInventory("Whale");
            Assert.True(actual == "There are 10 Whale(s) in stock.");
        }
        [Fact]
        public void GetInventoryTest()
        {
            // Arrange
            var name = "Penguin";
            var quantity = 50;
            var price = 100.00;
            var newAnimal = new Animal(name, price);
            var nyc = new Store("New York City");
            nyc.AddToInventory("Penguin", quantity);
            // Act
            var actual = nyc.GetInventory();
            // Assert
            Assert.True(actual[0] == "Penguin - 50") ;
        }
    }
}