using System;
using System.Collections.Generic;
using System.Text;

namespace Aquarium.Library
{
    public class Inventory
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public string Animal { get; set; }
        public int Quantity { get; set; }
    }
}
