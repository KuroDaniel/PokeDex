using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokeDex.UI.Models;

namespace PokeDex.UI.Controllers
{
    public class DetailsController : Controller
    {
        //public IActionResult Details(int id)
        //{
        //    CreaturesViewModel Details = null;

        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri($"http://localhost:5000/api/PokeDex/");
        //        var responseTask = client.GetAsync($"PokemonDetails/{id}");
        //        responseTask.Wait();

        //        var result = responseTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var readTask = result.Content.ReadAsAsync<CreaturesViewModel>();
        //            readTask.Wait();

        //            Details = readTask.Result;
        //        }
        //    }

        //    return View(Details);
        //}
    }
}