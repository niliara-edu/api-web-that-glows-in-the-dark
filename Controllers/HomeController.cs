using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using Newtonsoft.Json;

namespace mvc.Controllers;


public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


    //EXAMPLE (THAT WORKS)
    //const string apiUrl = "https://newton.now.sh/api/v2/factor/x^2-1";
    //var client = new HttpClient();
    //var response = client.GetAsync(apiUrl).Result;
    //var content = response.Content.ReadAsStringAsync().Result;

    // for one item:
    //SimpleResult model = JsonConvert.DeserializeObject<SimpleResult>(content);
    // for more:
    //List<SimpleResult> model = JsonConvert.DeserializeObject<List<SimpleResult>>(content);

    public IActionResult Index()
    {
        //1232343345455
        //const string apiUrl = "https://newton.now.sh/api/v2/factor/x^2-1";
        const string apiUrl = "https://www.thecocktaildb.com/api/json/v1/1/search.php?s=margarita";
        var client = new HttpClient();
        var response = client.GetAsync(apiUrl).Result;
        var content = response.Content.ReadAsStringAsync().Result;
        Console.WriteLine(content);

        //Cocktail model = JsonConvert.DeserializeObject<Cocktail>(content);
        Root model = JsonConvert.DeserializeObject<Root>(content);
        //List<Cocktail> model = JsonConvert.DeserializeObject<List<Cocktail>>(content);
        return View(model);
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
