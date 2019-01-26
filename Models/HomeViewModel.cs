using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandingPage.Models
{
    public class HomeViewModel
    {
        public string ProfileName { get; set; }

        public string DescriptionBlurb { get; set; }

        public string ProfilePicturePath { get; set; }

        public List<PostModel> PaginatedPosts { get; set; } = new List<PostModel>();
    }
}
