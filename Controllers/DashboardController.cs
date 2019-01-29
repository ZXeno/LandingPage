
using LandingPage.DataLayer;
using LandingPage.DataLayer.Repository;
using LandingPage.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LandingPage.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IFileManager fileManager;
        private readonly IRepository repo;

        public DashboardController(IRepository repo, IFileManager fileManager)
        {
            this.repo = repo;
            this.fileManager = fileManager;
        }

        public IActionResult Index()
        {
            DashboardViewModel viewModel = new DashboardViewModel();
            ProfileModel profileData = repo.GetProfile();

            viewModel.ProfileName = profileData.ProfileName;
            viewModel.DescriptionBlurb = profileData.DescriptionBlurb;

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeProfile(DashboardViewModel viewModel)
        {
            await fileManager.SaveProfileImage(viewModel.ProfilePicture);

            ProfileModel profile = new ProfileModel()
            {
                ProfileName = viewModel.ProfileName,
                DescriptionBlurb = viewModel.DescriptionBlurb
            };

            repo.UpdateProfile(profile);
            await repo.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}