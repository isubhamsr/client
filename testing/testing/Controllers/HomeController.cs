using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using testing.Models;

namespace testing.Controllers
{
    public class HomeController : Controller
    {
        //private IHttpClientFactory _httpClientFactory;

        //public HomeController(IHttpClientFactory httpClientFactory)
        //{
        //    _httpClientFactory = httpClientFactory;
        //}

        private HttpClient _client;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

            if (_client == null)
            {
                _client = new HttpClient();
                _client.BaseAddress = new Uri("http://example.com/api/");
            }
        }

        public IActionResult Index()
        {
            return View();
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

        public async Task<string> GetResult()
        {
            //var httpClient = _httpClientFactory.CreateClient();
            //var responce = await httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/todos");
            //return responce;

            var response = await _client.GetStringAsync("https://localhost:5001/api/Store");
            return response;
        }
    }
}
