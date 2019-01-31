using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LandingPage.Models;
using LandingPage.DataLayer.Repository;
using Microsoft.Extensions.Configuration;
using LandingPage.DataLayer;

namespace LandingPage.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IRepository repo;
        private readonly IConfiguration config;
        private readonly IFileManager fileManager;

        public HomeController(IRepository repo, IConfiguration configuration, IFileManager fileManager)
        {
            this.repo = repo;
            this.config = configuration;
            this.fileManager = fileManager;
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

        [HttpGet("/Image/{image}")]
        public IActionResult Image(string image)
        {
            string mimeType = image.Substring(image.LastIndexOf(".") + 1);
            return new FileStreamResult(fileManager.ImageStream(image), $"image/{mimeType}");
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
