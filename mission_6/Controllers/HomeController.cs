using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mission_6.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace mission_6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private MovieApplicationContext MovieContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieApplicationContext Movie)
        {
            _logger = logger;
            MovieContext= Movie;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcast()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EnterMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnterMovie(ApplicationResponse ar)
        {
            MovieContext.Add(ar);
            MovieContext.SaveChanges();

            return View("Index", ar);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
