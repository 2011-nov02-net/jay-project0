using System;
using System.Collections.Generic;

namespace Aquarium.Library
{
    public class Customer
    {
        public Customer(string lastName, string firstName, string email)
        {
            _lastName = lastName;
            _firstName = firstName;
            _email = email;
            _order = new Dictionary<int, Order>();
        }
        private string _lastName;
        private string _firstName;
        private string _email;
        private Dictionary<int, Order> _order;
    }
}