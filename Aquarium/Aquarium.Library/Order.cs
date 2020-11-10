﻿using System;
using System.Collections.Generic;

namespace Aquarium.Library
{
    public class Order
    {
        public Order(Store location, Customer customer, Animal animal, int quantity)
        {
            _location = location;
            _customer = customer;
            _cart = new Dictionary<Animal, int>();
            _cart.Add(animal, quantity);
            _totalPrice = animal.Price * quantity;

        }
        private Store _location;
        private Customer _customer;
        private decimal _totalPrice;
        public Dictionary<Animal, int> _cart { get; private set; }
        public List<string> GetCart()
        {
            var result = new List<string>();
            foreach (KeyValuePair<Animal, int> animal in _cart)
            {
                result.Add($"{animal.Key.Name} - {animal.Value} - {animal.Key.Price * animal.Value}"); // Returns several strings but will change to true list format later
            }
            return result;
        }
        public decimal CheckoutCart()
        {
            decimal CartTotal = 0.00m;
            foreach (KeyValuePair<Animal, int> animal in _cart)
            {
                _location.RemoveFromInventory(animal.Key.Name, animal.Value); // Removes the number of animals in the store. Need to add availability check
                CartTotal += animal.Key.Price * animal.Value;
            }
            return CartTotal;
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