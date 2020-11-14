using System;
using System.Collections.Generic;

#nullable disable

namespace Aquarium.DataModel
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int StoreId { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public int AnimalId { get; set; }

        public virtual Animal Animal { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Store Store { get; set; }
    }
}
