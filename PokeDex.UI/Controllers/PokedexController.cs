using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PokeDex.Data;
using PokeDex.UI.Models;

namespace PokeDex.UI.Controllers
{
    public class PokedexController : Controller
    {

        public IActionResult Index()
        {
            IEnumerable<CreaturesViewModel> pokemonList = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5000/api/PokeDex/");
                var responseTask = client.GetAsync("GetAllPokemon");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<CreaturesViewModel>>();
                    readTask.Wait();

                    pokemonList = readTask.Result;
                }
                else
                {
                    pokemonList = Enumerable.Empty<CreaturesViewModel>();
                }
            }
            return View(pokemonList);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            CreaturesViewModel ViewModel = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"http://localhost:5000/api/PokeDex/");
                var responseTask = client.GetAsync($"PokemonDetails/{id}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CreaturesViewModel>();
                    readTask.Wait();

                    ViewModel = readTask.Result;
                }
            }

            return View(ViewModel);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            CreaturesViewModel creatures = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"http://localhost:5000/api/PokeDex/");
                var responseTask = client.GetAsync($"PokemonDetails/{id}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CreaturesViewModel>();
                    readTask.Wait();

                    creatures = readTask.Result;
                }
            }
            return View(creatures);
        }

        [HttpPost]
        public IActionResult Update(CreaturesViewModel creatures)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"http://localhost:5000/api/PokeDex/");
                var responseTask = client.GetAsync($"EditPokemon");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CreaturesViewModel>();
                    readTask.Wait();

                    creatures = readTask.Result;
                }
            }
            return RedirectToAction("Update", new { id = creatures.CreatureId });
        }
    }
}