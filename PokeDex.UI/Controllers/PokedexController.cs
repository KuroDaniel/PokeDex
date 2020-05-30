using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PokeDex.Data;
using PokeDex.Domain.DTOModels;
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
            CreaturesViewModel viewModel = null;

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

                    viewModel = readTask.Result;
                }
            }

            return View(viewModel);
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

            ViewBag.TypeList1 = GetTypesDropDown();
            ViewBag.TypeList2 = GetTypesDropDown();


            return View(creatures);
        }

        private List<TypesDropDown> GetTypesDropDown()
        {
            List<TypesDropDown> dropDown = null;
            using (var client = new HttpClient())
            {
                
                client.BaseAddress = new Uri($"http://localhost:5000/api/PokeDex/");
                var responseTask = client.GetAsync($"GetAllTypes");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<TypesDropDown>>();
                    readTask.Wait();

                    dropDown = readTask.Result;

                }
            }

            return dropDown;
        }

        [HttpPost]
        public IActionResult Update(CreaturesViewModel creatureVM)
        {
            CreaturesDTO creatureDTO = null;
            creatureDTO.CreatureId = creatureVM.CreatureId;
            creatureDTO.CreaturePic = creatureVM.CreaturePic;
            creatureDTO.Name = creatureVM.Name;
            creatureDTO.DexNum = creatureVM.DexNum;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"http://localhost:5000/api/PokeDex/");
                var responseTask = client.GetAsync($"EditPokemon/{creatureDTO}");
                responseTask.Wait();

                //var result = responseTask.Result;
                //if (result.IsSuccessStatusCode)
                //{
                //    var readTask = result.Content.ReadAsAsync<CreaturesViewModel>();
                //    readTask.Wait();

                //    creatures = readTask.Result;
                //}
            }
            return RedirectToAction("Update", new { id = creatureVM.CreatureId });
        }
    }
}