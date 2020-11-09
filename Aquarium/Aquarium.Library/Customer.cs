using System;

namespace Aquarium.Library
{
    public class Customer
    {
        public Customer(string lastName, string firstName, string email)
        {
            _lastName = lastName;
            _firstName = firstName;
            _email = email;
        }
        private string _lastName;
        private string _firstName;
        private string _email;
    }
}