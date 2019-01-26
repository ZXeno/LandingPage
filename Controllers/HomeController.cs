using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LandingPage.Models;
using LandingPage.DataLayer.Repository;

namespace LandingPage.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private IRepository repo;

        public HomeController(IRepository repo)
        {
            this.repo = repo;
        }


        public IActionResult Index()
        {
            HomeViewModel viewModel = new HomeViewModel()
            {
                ProfileName = "Jonathan Cain",
                ProfilePicturePath = "/assets/profile.png",
                DescriptionBlurb = "Enthusiastic software developer, passionate learner, solutions engineer, nerd, self-motivated, and father to one amazing son. I build tools and simple games, learn everything I can, and always look for great opportunities to do something interesting. Very much a DIY/maker type and variety gamer in my spare time.",
                PaginatedPosts = repo.GetAllPosts()
            };

            return View(viewModel);
        }

        public IActionResult Contact()
        {
            // Todo: replace
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
