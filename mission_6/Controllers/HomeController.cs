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
            if (ModelState.IsValid)
            {
                MovieContext.Add(ar);
                MovieContext.SaveChanges();

                return RedirectToAction("MovieList", ar);
            }
            else // If Invalid
            {
                ViewBag.Categories = MovieContext.Categories.ToList();

                return View(ar);
            }

        }

        //SQL statement for Table
        public IActionResult MovieList()
        {
            var application = MovieContext.Responses
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(application);
        }

        //Edit the entries
        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = MovieContext.Categories.ToList();

            //find the single record
            var movie = MovieContext.Responses.Single(x => x.MovieId == movieid);

            return View("EnterMovie", movie);
        }

        [HttpPost]
        public IActionResult Edit(ApplicationResponse edit)
        {
            if (ModelState.IsValid)
            {
                MovieContext.Update(edit);
                MovieContext.SaveChanges();

                // need to send them to the action. not the view
                return RedirectToAction("MovieList");
            }
            else
            {
                ViewBag.Categories = MovieContext.Categories.ToList();
                return View("EnterMovie", edit);
            }
            
        }

        //Delete Movies
        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            ViewBag.Categories = MovieContext.Categories.ToList();

            //find the single record
            var movie = MovieContext.Responses.Single(x => x.MovieId == movieid);

            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(ApplicationResponse delete)
        {
            MovieContext.Remove(delete);
            MovieContext.SaveChanges();

            // need to send them to the action. not the view
            return RedirectToAction("MovieList");
        }

    }
}
