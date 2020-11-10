using System;
using System.Collections.Generic;

namespace Aquarium.Library
{
    public class Order
    {
        public Order(Store location, Customer name, Animal animal)
        {
            _location = location;
            _name = name;
        }
        private Store _location;
        private Customer _name;
        private Dictionary<string, Animal> _animal;
        private double _price;

        public void AddToOrder()
        {

        }
        public void RemoveFromOrder()
        {

        }
    }
}