﻿using System;
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
        private int CustomerId; // For SQL
        public string LastName { get; private set; }
        public string FirstName { get; private set; }
        public string EmailAddress { get; private set; }
    }
}