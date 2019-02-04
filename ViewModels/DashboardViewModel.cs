using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandingPage.ViewModels
{
    public class DashboardViewModel
    {
        public int ProfileId { get; set; }
        public string ProfileName { get; set; }
        public string DescriptionBlurb { get; set; }
        public IFormFile ProfilePicture { get; set; }
        public string ResponseMessage { get; set; }
    }
}
