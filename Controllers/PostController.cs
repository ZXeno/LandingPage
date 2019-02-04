using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LandingPage.DataLayer;
using LandingPage.DataLayer.Repository;
using LandingPage.Models;
using LandingPage.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LandingPage.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private IRepository repo;
        private IFileManager fileManager;

        public PostController(IRepository repo, IFileManager fileManager)
        {
            this.repo = repo;
            this.fileManager = fileManager;
        }

        public IActionResult Index()
        {
            List<PostModel> posts = repo.GetAllPosts();

            return View(posts);
        }

        [HttpGet]
        public IActionResult NewPost()
        {
            NewAndEditPostViewModel viewModel = new NewAndEditPostViewModel()
            { 
                Post = new PostModel(),
                ExistingImageFileNames = fileManager.ListUploadedImages()
        };
            return View("EditPost", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> NewPost(NewAndEditPostViewModel viewModel)
        {
            repo.AddPost(viewModel.Post);
            await repo.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditPost(int? id)
        {
            NewAndEditPostViewModel viewModel = new NewAndEditPostViewModel();

            viewModel.Post = (id == null) ? new PostModel() : repo.GetPost((int)id);
            viewModel.ExistingImageFileNames = fileManager.ListUploadedImages();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(NewAndEditPostViewModel viewModel)
        {
            viewModel.Post.EditedDateTime = DateTime.Now;
            repo.UpdatePost(viewModel.Post);
            await repo.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            repo.RemovePost((int)id);
            await repo.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ViewPost(int? id)
        {
            if (id == null)
            {
                return NewPost();
            }

            return View(repo.GetPost((int)id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddImages(NewAndEditPostViewModel viewModel)
        {
            foreach (IFormFile file in viewModel.NewlySubmittedFiles)
            {
                await fileManager.SaveImage(file);
            }

            viewModel.ExistingImageFileNames = fileManager.ListUploadedImages();
            viewModel.NewlySubmittedFiles.Clear();

            return View("EditPost", viewModel);
        }
    }
}