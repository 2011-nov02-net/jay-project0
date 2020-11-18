using System;
using Xunit;
using Aquarium.Library;
using Aquarium.ConsoleApp;
using Aquarium.DataModel;
using System.Collections.Generic;

namespace Aquarium.Tests
{
    public class LocationTests
    {
        [Fact]
        public void AddToInventoryTest()
        {
            // Arrange
            var newAnimal = new Library.Animal();
            newAnimal.Name = "whale";
            var nyc = new Library.Store();
            nyc.Inventory = new Dictionary<Library.Animal, int>();
            // Act
            nyc.AddToInventory(newAnimal, 5);
            // Assert
            var actual = nyc.Inventory[newAnimal];
            Assert.True(actual == 5);
        }
        [Fact]
        public void AddToInventoryTest2()
        {
            // Arrange
            var penguin = new Library.Animal();
            penguin.Name = "penguin";
            var nyc = new Library.Store();
            nyc.Inventory = new Dictionary<Library.Animal, int>();
            nyc.AddToInventory(penguin, 1555);
            // Act
            var actual = nyc.Inventory[penguin];
            // Assert
            Assert.True(actual == 1555);
        }
        [Fact]
        public void RemoveFromInventoryTest()
        {
            var penguin = new Library.Animal();
            penguin.Name = "penguin";
            var nyc = new Library.Store();
            nyc.Inventory = new Dictionary<Library.Animal, int>();
            nyc.AddToInventory(penguin, 20);
            var actual = nyc.RemoveFromInventory(penguin, 10);
            Assert.True(actual == true);
        }
        [Fact]
        public void RemoveFromInventoryTest2()
        {
            var penguin = new Library.Animal();
            penguin.Name = "penguin";
            var nyc = new Library.Store();
            nyc.Inventory = new Dictionary<Library.Animal, int>();
            nyc.AddToInventory(penguin, 20);
            var actual = nyc.RemoveFromInventory(penguin, 100);
            Assert.True(actual == false);
        }
        [Fact]
        public void InventoryContainsTest()
        {
            var shark = new Library.Animal();
            shark.Name = "shark";
            var nyc = new Library.Store();
            nyc.Inventory = new Dictionary<Library.Animal, int>();
            nyc.AddToInventory(shark, 20);
            var actual = nyc.InInventory(shark);
            Assert.True(actual == true);
        }
        [Fact]
        public void InventoryContainsTest2()
        {
            var shark = new Library.Animal();
            shark.Name = "shark";
            var squirrel = new Library.Animal();
            squirrel.Name = "squirrel";
            var nyc = new Library.Store();
            nyc.Inventory = new Dictionary<Library.Animal, int>();
            nyc.AddToInventory(shark, 20);
            var actual = nyc.InInventory(squirrel);
            Assert.True(actual == false);
        }
        [Fact]
        public void InventoryContainsTest0Quant()
        {
            var shark = new Library.Animal();
            shark.Name = "shark";
            var nyc = new Library.Store();
            nyc.Inventory = new Dictionary<Library.Animal, int>();
            nyc.AddToInventory(shark, 0);
            var actual = nyc.InInventory(shark);
            Assert.True(actual == false);
        }
        [Fact]
        public void InventoryTestNegativeQuant()
        {
            var shark = new Library.Animal();
            shark.Name = "shark";
            var nyc = new Library.Store();
            nyc.Inventory = new Dictionary<Library.Animal, int>();
            nyc.AddToInventory(shark, -10);
            var actual = nyc.InInventory(shark);
            Assert.True(actual == false);
        }
        [Fact]
        public void AddInventoryTestFail()
        {
            var shark = new Library.Animal();
            shark.Name = "shark";
            var nyc = new Library.Store();
            nyc.Inventory = new Dictionary<Library.Animal, int>();
            nyc.AddToInventory(shark, 0);
            var actual = nyc.InInventory(shark);
            Assert.True(actual == false);
        }
        [Fact]
        public void RemoveFromInventoryTestFail2()
        {
            var penguin = new Library.Animal();
            penguin.Name = "penguin";
            var nyc = new Library.Store();
            nyc.Inventory = new Dictionary<Library.Animal, int>();
            nyc.AddToInventory(penguin, 20);
            var actual = nyc.RemoveFromInventory(penguin, 150);
            Assert.True(actual == false);
        }
    }
}