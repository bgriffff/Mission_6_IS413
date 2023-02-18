using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        private MovieApplicationContext MovieContext { get; set; }

        //constructor
        public HomeController(MovieApplicationContext Movie)
        {
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
            ViewBag.Categories = MovieContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult EnterMovie(ApplicationResponse ar)
        {
            MovieContext.Add(ar);
            MovieContext.SaveChanges();

            return View("Index", ar);
        }

        public IActionResult MovieList()
        {
            var application = MovieContext.Responses
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(application);
        }


    }
}
