using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LandingPage.Models;

namespace LandingPage.DataLayer.Repository
{
    public class Repository : IRepository
    {
        private AppDbContext context;

        public Repository(AppDbContext context)
        {
            this.context = context;
        }

        public void AddPost(PostModel post)
        {
            context.Posts.Add(post);
        }

        public List<PostModel> GetAllPosts()
        {
            return context.Posts.ToList();
        }

        public PostModel GetPost(int id)
        {
            return context.Posts.FirstOrDefault(x => x.Id == id);
        }

        public void RemovePost(int id)
        {
            context.Posts.Remove(GetPost(id));
        }

        public void UpdatePost(PostModel post)
        {
            context.Posts.Update(post);
        }

        public ProfileModel GetProfile()
        {
            ProfileModel profile = context.ProfileData.FirstOrDefault();

            if (profile == null)
            {
                profile = new ProfileModel()
                {
                    ID = 0,
                    ProfileName = "New_User",
                    DescriptionBlurb = "About-Me text."
                };
            }

            return profile;
        }

        public void UpdateProfile(ProfileModel profileData)
        {
            context.ProfileData.Update(profileData);
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await context.SaveChangesAsync() > 0)
            {
                return true;
            }

            return false;
        }
    }
}
