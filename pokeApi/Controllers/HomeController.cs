using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using pokeApi.Models;
using System.Diagnostics;
using System.Security.Policy;

namespace pokeApi.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public async Task <IActionResult> Index(string ruta = "https://pokeapi.co/api/v2/pokemon/")
		{
			//https://pokeapi.co/api/v2/pokemon/
			var httpClient = new HttpClient();
			var json = await httpClient.GetStringAsync(ruta);
			var result = JsonConvert.DeserializeObject(json);
			return View(result);
		}
	   
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