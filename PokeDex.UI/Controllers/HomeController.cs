using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PokeDex.Data;
using PokeDex.Domain.Models;
using PokeDex.UI.Models;

namespace PokeDex.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static PokeDexContext context = new PokeDexContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //context.Database.EnsureCreated();
            //AddPokemon();
            return View();
        }

        //private static void AddPokemon()
        //{
        //    var creature = new Creatures { Name = "Mew" };
        //    context.Creatures.Add(creature);
        //    context.SaveChanges();
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
