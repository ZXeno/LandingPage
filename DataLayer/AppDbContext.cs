using LandingPage.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandingPage.DataLayer
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<PostModel> Posts { get; set;}

        public DbSet<ProfileModel> ProfileData { get; set; }
    }
}
