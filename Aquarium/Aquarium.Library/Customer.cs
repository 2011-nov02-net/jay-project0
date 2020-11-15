using System;
using System.Collections.Generic;

namespace Aquarium.Library
{
    public class Customer
    {
        public Customer()
        {
            LastName = lastName;
            FirstName = firstName;
            Email = email;
        }
        public int CustomerId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
    }
}