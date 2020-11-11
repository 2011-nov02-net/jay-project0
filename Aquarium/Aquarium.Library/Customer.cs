using System;
using System.Collections.Generic;

namespace Aquarium.Library
{
    public class Customer
    {
        public Customer(string lastName, string firstName, string email)
        {
            LastName = lastName;
            FirstName = firstName;
            EmailAddress = email;
        }
        public int CustomerId { get; private set; }
        public string LastName { get; private set; }
        public string FirstName { get; private set; }
        public string EmailAddress { get; private set; }
    }
}