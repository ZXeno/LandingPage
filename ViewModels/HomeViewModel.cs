using LandingPage.Models;
using System.Collections.Generic;

namespace LandingPage.ViewModels
{
    public class HomeViewModel
    {
        public string ProfileName { get; set; }

        public string DescriptionBlurb { get; set; }

        public string ProfilePicturePath { get; set; }

        public List<PostModel> PaginatedPosts { get; set; } = new List<PostModel>();
    }
}
