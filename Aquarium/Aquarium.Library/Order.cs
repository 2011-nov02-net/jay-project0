﻿using System;
using System.Collections.Generic;

namespace Aquarium.Library
{
    public class Order
    {
        public int OrderId { get; set; }
        public int StoreId { get; set; }
        public Library.Customer Customer { get; set; }
        public Library.Animal Animal { get; set; }
        public int Quantity { get; set;}
        public decimal Total { get; set; }
        public DateTime Date { get; set; }

        public void GetTotal(){
            int result = Convert.ToInt32(Animal.Price) * Quantity;
            Total = Convert.ToDecimal(result);
        }
        public void GetOrderInfo(){
            Console.WriteLine($"ORDERID: {OrderId}");
            Console.WriteLine($"    Customer Email: {Customer.Email}");
            Console.WriteLine($"    Animal: {Animal.Name}");
            Console.WriteLine($"    Price: {String.Format("{0:C}", Animal.Price)}");
            Console.WriteLine($"    Quantity: {Quantity}");
            Console.WriteLine($"    Total: ${Total}");
            Console.WriteLine($"    Date: {Date}");
        }
    }
}