
using LandingPage.DataLayer;
using LandingPage.DataLayer.Repository;
using LandingPage.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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

            try
            {
                ProfileModel profileData = repo.GetProfile();

                viewModel.ProfileId = profileData.ID;
                viewModel.ProfileName = profileData.ProfileName;
                viewModel.DescriptionBlurb = profileData.DescriptionBlurb;
            }
            catch (Exception ex)
            {
                viewModel.ResponseMessage += $"Error loading profile data. <br />Error message: {ex.Message}";
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeProfile(DashboardViewModel viewModel)
        {
            if (viewModel.ProfilePicture != null)
            {
                try
                {
                    await fileManager.SaveProfileImage(viewModel.ProfilePicture);
                }
                catch (Exception ex)
                {
                    viewModel.ResponseMessage = $"Unable to save new profile image.<br />Error message: {ex.Message}";
                }
            }

            ProfileModel profile = new ProfileModel()
            {
                ID = viewModel.ProfileId,
                ProfileName = viewModel.ProfileName,
                DescriptionBlurb = viewModel.DescriptionBlurb
            };

            try
            {
                repo.UpdateProfile(profile);
                await repo.SaveChangesAsync();

                if (string.IsNullOrWhiteSpace(viewModel.ResponseMessage?.ToString()))
                {
                    viewModel.ResponseMessage = "Profile saved.";
                }
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrWhiteSpace(viewModel.ResponseMessage?.ToString()))
                {
                    viewModel.ResponseMessage += "<br /><br />";
                }

                viewModel.ResponseMessage += $"Unable to save profile changes.<br />Error message: {ex.Message}";
            }

            return View("Index", viewModel);
        }
    }
}