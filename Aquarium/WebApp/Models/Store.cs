using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Store
    {
        public int StoreId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}