using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LandingPage.DataLayer.Repository;
using LandingPage.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LandingPage.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private IRepository repo;

        public PostController(IRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<PostModel> posts = repo.GetAllPosts();

            return View(posts);
        }

        [HttpGet]
        public IActionResult NewPost()
        {
            return View("EditPost", new PostModel());
        }

        [HttpPost]
        public async Task<IActionResult> NewPost(PostModel post)
        {
            repo.AddPost(post);
            await repo.SaveChangesAsync();

            return RedirectToAction("Index", "Dashboard");
        }

        [HttpGet]
        public IActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return View(new PostModel());
            }

            PostModel existingPost = repo.GetPost((int)id);
            return View(existingPost);
        }

        [HttpPost]
        public async Task<IActionResult> EditPost(PostModel post)
        {
            post.EditedDateTime = DateTime.Now;
            repo.UpdatePost(post);
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
    }
}