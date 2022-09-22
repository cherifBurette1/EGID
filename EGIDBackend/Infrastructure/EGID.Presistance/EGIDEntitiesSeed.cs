using EGID.Data.Entities;
using System.Linq;
using System.Collections.Generic;

namespace EGID.Presistance
{
    public class EGIDEntitiesSeed
    {
        public static void ApiInitialize(EGIDEntities context)
        {
            var initializer = new EGIDEntitiesSeed();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(EGIDEntities context)
        {
            context.Database.EnsureCreated();

            if (context.Stocks.Any())
            {
                return; // Db has been seeded
            }
            SeedStocks(context);
            SeedPersons(context);
            SeedBrokers(context);
        }
        public void SeedBrokers(EGIDEntities context)
        {
            var broker = new Broker()
            {
                Name = "firstBroker"
            };
            context.Brokers.Add(broker);
            context.SaveChanges();

        }
        public void SeedStocks(EGIDEntities context)
        {
            List<string> seedStockNames = new List<string>(){
                "Vianet",
                "Agritek",
                "Akamai",
                "Baidu",
                "Blinkx",
                "Blucora",
                "Boingo",
                "Brainybrawn",
                "Carbonite",
                "China Finance",
                "ChinaCache1",
                "ADR",
                "ChitrChatr",
                "Cnova",
                "Cogent",
                "Crexendo",
                "CrowdGather",
                "EarthLink",
                "Eastern",
                "ENDEXX",
                "Envestnet",
                "Epazz",
                "FlashZero",
                "Genesis",
                "InterNAP",
                "MeetMe",
                "Netease",
                "Qihoo" };
            for (int i = 0; i < seedStockNames.Count; i++)
            {
                var stock = new Stock()
                {
                    Name = seedStockNames[i],
                    Price = 50
                };
                context.Stocks.Add(stock);
            }
            context.SaveChanges();

        }
        public void SeedPersons(EGIDEntities context)
        {
            for (int i = 1; i <= 2; i++)
            {
                var p = new Person()
                {
                    Name = "firstPerson",
                };
                context.Persons.Add(p);
            }
            context.SaveChanges();
        }
    }
}
