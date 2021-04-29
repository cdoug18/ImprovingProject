using ImprovingProject.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ImprovingProject.Controllers
{
    public class BreedController : Controller
    {
        public async Task<IActionResult> Index()
        {
            Breed _breeds = new Breed();

            using (var _httpClient = new HttpClient())
            {
                using var _request = await _httpClient.GetAsync("https://dog.ceo/api/breeds/list");
                string _response = await _request.Content.ReadAsStringAsync();
                _breeds = JsonConvert.DeserializeObject<Breed>(_response);
            }

            return View(_breeds);            
        }
    }
}
