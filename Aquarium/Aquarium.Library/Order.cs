using System;
using System.Collections.Generic;

namespace Aquarium.Library
{
    public class Order
    {
        public Store _location;
        public Customer _customer;
        public decimal _totalPrice;
        public Dictionary<Animal, int> _cart { get; private set; }
        public List<string> GetCart()
        {
            var result = new List<string>();
            foreach (KeyValuePair<Animal, int> animal in _cart)
            {
                result.Add($"{animal.Key.Name} - {animal.Value} - {animal.Key.Price * animal.Value}"); // Change this to pull data from SQL database
            }
            return result;
        }
        public string CheckoutCart()
        {
            decimal CartTotal = 0.00m;
            foreach (KeyValuePair<Animal, int> animal in _cart)
            {
                _location.RemoveFromInventory(animal.Key.Name, animal.Value); // Removes the number of animals in the store. Need to add availability check
                CartTotal += animal.Key.Price * animal.Value;
            }
            return ($"Your total is ${CartTotal}.");
        }
        public void AddToCart(Animal animal, int quantity)
        {
            bool checkForExisting = _cart.ContainsKey(animal);
            if (checkForExisting)
            {
                _cart[animal] += quantity;
                _totalPrice += animal.Price * quantity;
            }
            else 
            {
                _cart.Add(animal, quantity);
                _totalPrice += animal.Price * quantity;
            }
        }
        public void RemoveFromCart(Animal animal, int quantity)
        {
            bool checkForExisting = _cart.ContainsKey(animal);
            if (checkForExisting)
            {
                _cart[animal] -= quantity;
                _totalPrice -= animal.Price * quantity;

            }
        }
    }
}