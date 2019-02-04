using LandingPage.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace LandingPage.ViewModels
{
    public class NewAndEditPostViewModel
    {
        public PostModel Post { get; set; }
        public List<string> ExistingImageFileNames { get; set; } = new List<string>();
        public IList<IFormFile> NewlySubmittedFiles { get; set; } = new List<IFormFile>();
    }
}
