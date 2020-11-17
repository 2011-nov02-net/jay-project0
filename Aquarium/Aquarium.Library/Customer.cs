using System;
using System.Collections.Generic;

namespace Aquarium.Library
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public void GetCustomerInfo() {
            Console.WriteLine($"CUSTOMER:");
            Console.WriteLine($"    First name: {FirstName}");
            Console.WriteLine($"    Last name: {LastName}");
            Console.WriteLine($"    Email Address: {Email}");
        }
    }
}