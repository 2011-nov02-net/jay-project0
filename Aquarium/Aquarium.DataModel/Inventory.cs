using System;
using System.Collections.Generic;

#nullable disable

namespace Aquarium.DataModel
{
    public partial class Inventory
    {
        public int InventoryId { get; set; }
        public int AnimalId { get; set; }
        public int Quantity { get; set; }
        public int StoreId { get; set; }

        public virtual Animal Animal { get; set; }
        public virtual Store Store { get; set; }
    }
}
