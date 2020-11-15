using System;
using System.Collections.Generic;

namespace Aquarium.Library
{
    public class Order
    {
        public int OrderId { get; set; }
        public int StoreId { get; set; }
        public int CustomerId { get; set; }
        public int AnimalId { get; set; }
        public int Quantity { get; set;}
        public decimal Total { get; set; }
        public DateTime Date { get; set; }
    }
}