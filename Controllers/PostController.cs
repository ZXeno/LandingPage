﻿using System.Collections.Generic;
using System.Threading.Tasks;
using LandingPage.DataLayer.Repository;
using LandingPage.Models;
using Microsoft.AspNetCore.Mvc;

namespace LandingPage.Controllers
{
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
            return View("EditPost", new PostModel(){ IsNewPost = true });
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
            repo.UpdatePost(post);
            await repo.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}