using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LandingPage.Models;
using LandingPage.DataLayer.Repository;
using Microsoft.Extensions.Configuration;

namespace LandingPage.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private IRepository repo;
        private IConfiguration config;

        public HomeController(IRepository repo, IConfiguration configuration)
        {
            this.repo = repo;
            this.config = configuration;
        }

        public IActionResult Index()
        {
            ProfileModel profile = repo.GetProfile();

            HomeViewModel viewModel = new HomeViewModel()
            {
                ProfileName = profile.ProfileName,
                ProfilePicturePath = config["Path:ProfilePicture"],
                DescriptionBlurb = profile.DescriptionBlurb,
                PaginatedPosts = repo.GetAllPosts()
            };

            return View(viewModel);
        }

        public IActionResult Contact()
        {
            // Todo: replace
            ViewData["Message"] = config["ContactPageStaticData:PageMessage"];

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
