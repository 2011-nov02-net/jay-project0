using System;
using System.Collections.Generic;
using System.Text;

namespace Aquarium.DataModel
{
    public interface IStoreRepository
    {
        Library.Store GetStoreByCity(string location);
        Dictionary<Library.Animal, int> GetStoreInventory(Library.Store store);
        void UpdateInventoryDb(string city, Library.Animal animal, int stock);
        void AddToInventoryDb(string city, Library.Animal animal, int stock);
        void RemoveFromInventoryDb(int storeid, Library.Animal animal, int quantity);
        void AddToCustomerDb(Library.Customer customer);
        void UpdateCustomerDb(Library.Customer customer);
        Library.Customer GetCustomerByEmail(string email);
        List<Library.Order> GetCustOrders(Library.Customer customer);
        List<Library.Order> GetStoreOrders(Library.Store store);
        Library.Order GetOrderById(int id);
        void UpdateOrderDb(Library.Order order);
        void AddToOrderDb(Library.Order order);
        void AddToAnimalDb(Library.Animal animal);
        Library.Animal GetAnimalByName(string name);
        void UpdateAnimalDb(Library.Animal animal);
    }
}