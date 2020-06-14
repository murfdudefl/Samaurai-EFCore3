using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp
{
    internal class Program
    {
        private static SamuraiContext context = new SamuraiContext();

        //	optionsBuilder
        //		.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = SamuraiAppData")
        //		.UseLoggerFactory(ConsoleLoggerFactory);

        private static void Main(string[] args)
        {
            context.Database.EnsureCreated();
            //GetSamurais("Before Add:");
            //AddSamurai();
            //AddMultipleSamurais();
            //AddDifferentObjects();
            GetSomeSamurais();
            //GetSamurais("After Add:");
            Console.Write("Press any key...");
            Console.ReadKey();
        }

        private static void AddMultipleSamurais()
        {
            var busLogic = new BusinessDataLogic();
            string[] names = { "Fred", "Grizelda", "Cindy", "Ollie", "Draco", "Harry" };
            var count = busLogic.AddSamurais(names);
            Console.WriteLine($"Samurais added: {count}");
            //var samurais = new List<Samurai>();
            //samurais.Add(new Samurai() { Name = "Fred" });
            //samurais.Add( new Samurai() { Name = "Grizelda" });
            //samurais.Add(new Samurai() { Name = "Cindy" });
            //samurais.Add( new Samurai() { Name = "Ollie" });
            //samurais.Add(new Samurai() { Name = "Draco" });
            //samurais.Add( new Samurai() { Name = "Harry" });
            //context.Samurais.AddRange(samurais);
            //context.SaveChanges();
        }

        private static void GetSomeSamurais()
        {
            var allSamurais = context.Samurais;
            var some = allSamurais.Where(s => s.Name == "Fred" || s.Name == "Grezelda");
            var someWithHorses = some.Where(s => s.Horse != null);
            // no database calls have executed to this point

            // call to ToList() executes the SQL query with all the where clauses above and returns 1 samurai
            Console.WriteLine("Count of some with horses: " + someWithHorses.ToList().Count());
        }

        private static void AddDifferentObjects()
        {
            var newClan = new Clan() { ClanName = "Wizards" };
            var samuaraiFred = context.Samurais.FirstOrDefault(s => s.Name == "Fred");
            var newHorse = new Horse() { Name = "Silver", SamuraiId = samuaraiFred.Id };
            context.AddRange(newClan, newHorse);
            context.SaveChanges();
        }
        private static void AddSamurai()
        {
            var samurai = new Samurai { Name = "Maureen" };
            context.Samurais.Add(samurai);
            context.SaveChanges();
        }

        private static void GetSamurais(string text)
        {
            var samurais = context.Samurais.ToList();
            Console.WriteLine($"{text}: Samurai count is {samurais.Count}");
            foreach(var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
        }
    }
}