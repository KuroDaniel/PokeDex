using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PokeDex.Data;
using PokeDex.Domain.Models;

namespace PokeDex.UI
{
    public class Program
    {
        //private static PokeDexContext context = new PokeDexContext();

        private static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            //context.Database.EnsureCreated();
            //GetPokemon("Before Add");
            //AddPokemon();
            //GetPokemon("After Add:");
            //Console.WriteLine("Press any key...");
            //Console.ReadKey();
        }

        //private static void AddPokemon()
        //{
        //    var creature = new Creatures { Name = "Mew" };
        //    context.Creatures.Add(creature);
        //    context.SaveChanges();
        //}

        //private static void GetPokemon(string text)
        //{
        //    var creatures = context.Creatures.ToList();
        //    Console.WriteLine($"{text}: Pokemon count is {creatures.Count}");
        //    foreach (var pokemon in creatures)
        //    {
        //        Console.WriteLine(pokemon.Name);
        //    }
        //}

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
