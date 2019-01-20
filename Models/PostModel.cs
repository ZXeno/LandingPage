using System;
using System.Collections.Generic;

namespace LandingPage.Models
{
    public class PostModel
    {
        public int Id { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

        public DateTime EditedDateTime { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string Tags { get; set; }
    }
}
