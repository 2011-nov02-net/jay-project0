using System;
using System.Collections.Generic;
using System.Text;

namespace Aquarium.DataModel
{
    public interface IStoreRepository
    {
        Library.Store GetStoreByCity(string location);
        Dictionary<string, int> GetStoreInventory(Library.Store store);
    }
}
