using System;
using System.Collections.Generic;
using System.Text;

namespace Aquarium.DataModel
{
    public interface IStoreRepository
    {
        Library.Store GetStoreByCity(string location);
        Dictionary<string, int> GetStoreInventory(Library.Store store);
        public void AddToInventoryDb(string city, string name, int stock);
        public void RemoveFromInventoryDb(int storeid, int animalid, int quantity);
        public void CreateCustomer(Library.Customer customer);
        public Library.Customer GetCustomerByName(string lastname, string firstname);
        public IEnumerable<Library.Order> GetCustOrders(Library.Customer customer);
        public IEnumerable<Library.Order> GetStoreOrders(Library.Store store);
        public Library.Order ConvertOrdersById(DataModel.Order order);
        public void AddToOrderDb(Library.Order order);
    }
}