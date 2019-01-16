using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandingPage.Models
{
    public class PostModel
    {
        public int ID { get; set; }

        public bool IsNewPost { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

        public DateTime EditedDateTime { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public List<string> Tags { get; set; }

    }
}
