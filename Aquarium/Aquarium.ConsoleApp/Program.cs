using System;
using Aquarium.Library;
using Aquarium.DataModel;
using System.Linq;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Aquarium.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using var logStream = new StreamWriter("ef-logs.txt");
            var connect = System.IO.File.ReadAllText("connection.txt");

            var optionsBuilder = new DbContextOptionsBuilder<AquariumContext>();
            optionsBuilder.UseSqlServer(connect);
            optionsBuilder.LogTo(logStream.Write, LogLevel.Information);
            var s_dbContextOptions = optionsBuilder.Options;

            // Console inputs
            var StoreRepo = new StoreRepository(s_dbContextOptions);
            var result = StoreRepo.GetStoreByCity("Nyc");
            StoreRepo.AddToInventory("Nyc", "Penguin", 1);
        }
    }
}