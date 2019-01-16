using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LandingPage.Models;
using Microsoft.AspNetCore.Mvc;

namespace LandingPage.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewPost()
        {
            return View("EditPost", new PostModel(){ IsNewPost = true });
        }

        [HttpPost]
        public IActionResult NewPost(PostModel post)
        {
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpGet]
        public IActionResult EditPost()
        {
            // For testing purposes only
            PostModel existingPost = new PostModel() 
            {
                Title = "Test Title",
                Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
            };
            return View(existingPost);
        }

        [HttpPost]
        public IActionResult EditPost(PostModel post)
        {
            return RedirectToAction("Index", "Dashboard");
        }
    }
}