using System;
using System.Collections.Generic;

#nullable disable

namespace Aquarium.DataModel
{
    public partial class Animal
    {
        public Animal()
        {
            Inventories = new HashSet<Inventory>();
            Orders = new HashSet<Order>();
        }

        public int AnimalId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
